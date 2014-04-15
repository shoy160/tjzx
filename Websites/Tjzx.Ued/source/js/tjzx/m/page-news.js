/**
 * 后台管理-新闻资讯
 */
(function ($, T) {
    //form
    var vForm = $(".j-form").valid(),
        sForm = $(".s-form").valid({
            submit: function () {
                $(".j-search").click();
            }
        });
    vForm.init();

    var h = new hTemplate({
        tmp: $("#h-temp").html(),
        empty: $("#h-empty").html(),
        container: $(".j-htemplate"),
        size: 15,
        pager: $(".h-pager"),
        pageClick: function (page) {
            getList(page - 1);
        },
        filter: function (json) {
            json.links = '<a href="#" class="j-edit">编辑</a>';
            if (json.state == 0) {
                json.links += '<a href="#" class="j-state" data-state="1">显示</a>';
            } else if (json.state == 1) {
                json.links += '<a href="#" class="j-state" data-state="0">隐藏</a>';
            }
            return json;
        },
        complete: function () {
            T.setFrameHeight();
        }
    });
    var getList = function (page) {
        var data = sForm.json(),
            $t = $(this);
        singer.mix(data, { page: page });
        T.getJson("/m/news/list", data, function (json) {
            if (json.state) {
                h.bind(json.data.list, json.data.count);
                $(".m-table caption em").html(json.data.count);
            }
            $t.hasClass("btn") && T.setBtn($t, true);
        });
    };
    var loadNews = function (id) {
        if (!id || id <= 0) {
            vForm.reset();
            editor.setContent("");
            $(".j-back").hide();
            return false;
        }
        T.getJson("/m/news/item", {
            newsId: id
        }, function (json) {
            if (!json.state) {
                T.msg(json.msg || "获取资讯信息失败！");
                return false;
            }
            $(".m-panel-title li").removeClass("active");
            $(".m-panel-title ul").append("<li class=\"m-panel-add active\">编辑资讯</li>");
            $(".j-back").show();
            vForm.bind(json.data);
            editor.setContent(json.data.content);
            $(".m-panel-item").hide().eq(1).fadeIn();
            T.setFrameHeight();
            return false;
        });
    };
    getList(0);
    window.UEDITOR_CONFIG.autoHeightEnabled = false;
    var editor = UE.getEditor("content");

    if ("#send" === location.hash) {
        $(".m-panel-title li:eq(1)").click();
    }

    $(".j-htemplate")
        .delegate(".j-send", "click", function () {
            $(".m-panel-title li:eq(1)").click();
            return false;
        });
    var stateArray = ["隐藏", "显示"], stateColor = ["Gray", "Green"];
    $(document)
        .delegate(".m-panel-title li:eq(1)", "click.form", function () {
            loadNews();
        })
        .delegate(".j-search", "click", function () {
            if ($(this).hasClass("disabled")) return false;
            T.setBtn(this, false);
            getList.call(this, 0);
            return false;
        })
        .delegate(".j-release", "click", function () {
            if ($(this).hasClass("disabled") || !vForm.check()) return false;
            var content = encodeURIComponent(editor.getContent());
            if (content == "" || content == null) {
                T.msg("请填写资讯内容！");
                return false;
            }
            T.setBtn(this, false);
            var formData = vForm.json();
            formData.content = content;
            T.getJson("/m/news/add", formData, function (json) {
                if (json.state) {
                    T.msg(formData.newsId > 0 ? "编辑成功！" : "发布成功！", "reload");
                } else {
                    T.msg(json.msg || "操作异常！");
                    T.setBtn(".j-release", true);
                }
            }, function () {
                T.setBtn(".j-release", true);
            });
            return false;
        })
        .delegate(".j-edit", "click", function () {
            var id = $(this).parents("td").data("id");
            loadNews(id);
            return false;
        })
        .delegate(".j-state", "click", function () {
            var $t = $(this),
                id = $t.parents("td").data("id"),
                state = $t.data("state");
            if (!id || "" === state) return false;
            T.setStateBtn.call($t, false);
            T.getJson("/m/news/updateState", {
                newsId: id,
                state: state
            }, function (json) {
                if (json.state) {
                    $t.parent().prev().html(
                        singer.format('<span style="color:{color}">{text}</font>',
                            {
                                color: stateColor[state],
                                text: stateArray[state]
                            })
                    );
                    var nState = Math.abs(state - 1);
                    T.setStateBtn.call($t, json, nState);
                } else {
                    T.setStateBtn.call($t, json, state);
                }
            });
            return false;
        })
        .delegate(".j-delete", "click", function () {
            var id = $(this).parents("td").data("id");
            if (!confirm("确认删除该资讯？")) return false;
            T.getJson("/m/news/delete", {
                newsId: id
            }, function (json) {
                if (json.state) {
                    T.msg(json.msg || "删除成功！");
                    location.reload(true);
                } else {
                    T.msg(json.msg || "删除失败，请稍候重试！");
                }
            });
            return false;
        })
        .delegate(".j-restore", "click", function () {
            var id = $(this).parents("td").data("id");
            if (!confirm("确认还原该资讯？")) return false;
            T.getJson("/m/news/restore", {
                newsId: id
            }, function (json) {
                if (json.state) {
                    T.msg(json.msg || "还原成功！");
                    location.reload(true);
                } else {
                    T.msg(json.msg || "还原失败，请稍候重试！");
                }
            });
            return false;
        });
})(jQuery, TJZX);