/**
 * 后台管理-预约管理
 */
(function ($, T) {
    //calendar
    $(".j-startTime,.j-endTime").calendar();
    //form
    var vForm = $(".j-form").valid(),
        sForm = $(".s-form").valid({
            submit: function () {
                $(".j-search").click();
            }
        });
    vForm.init();

    T.stateArray["0"] = "未处理";
    T.stateArray["1"] = "已处理";
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
                json.links += singer.format('<a href="#" class="j-state" data-state="1">{0}</a>', T.stateArray["1"]);
            } else if (json.state == 1) {
                json.links += singer.format('<a href="#" class="j-state" data-state="0">{0}</a>', T.stateArray["0"]);
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
        T.getJson("/m/reservation/list", data, function (json) {
            if (json.state) {
                h.bind(json.data.list, json.data.count);
                $(".m-table caption em").html(json.data.count);
            }
            $t.hasClass("btn") && T.setBtn($t, true);
        }, function (data) {
            Alert(data.statusText || "获取数据异常!");
            h.bind();
        });
    };
    var loadItem = function (id) {
        if (!id || id <= 0) {
            vForm.reset();
            return false;
        }
        T.getJson("/m/reservation/item", {
            reservationId: id
        }, function (json) {
            if (!json.state) {
                T.msg(json.msg || "获取套餐预约信息失败！");
                return false;
            }
            $(".m-panel-title li").removeClass("active");
            $(".m-panel-title ul").append("<li class=\"m-panel-add active\">处理套餐预约</li>");
            $(".j-back").show();
            vForm.bind(json.data);
            $(".m-panel-item").hide().eq(1).fadeIn();
            T.setFrameHeight();
            return false;
        });
    };
    getList(0);
    if ("#send" === location.hash) {
        $(".m-panel-title li:eq(1)").click();
    }

    $(".j-htemplate")
        .delegate(".j-send", "click", function () {
            $(".m-panel-title li:eq(1)").click();
            return false;
        });
    var stateColor = ["Gray", "Green"];
    $(document)
        .delegate(".m-panel-title li:eq(1)", "click.form", function () {
            loadItem();
        })
        .delegate(".j-search", "click", function () {
            if ($(this).hasClass("disabled")) return false;
            T.setBtn(this, false);
            getList.call(this, 0);
            return false;
        })
        .delegate(".j-submit", "click", function () {
            if ($(this).hasClass("disabled") || !vForm.check()) return false;
            T.setBtn(this, false);
            var formData = vForm.json();
            formData.details = encodeURIComponent(editor.getContent());
            T.getJson("/m/reservation/add", formData, function (json) {
                if (json.state) {
                    T.msg(formData.packageId > 0 ? "编辑成功！" : "添加成功！", "reload");
                } else {
                    T.msg(json.msg || "操作异常！");
                    T.setBtn(".j-submit", true);
                }
            }, function () {
                T.setBtn(".j-submit", true);
            });
            return false;
        })
        .delegate(".j-edit", "click", function () {
            var id = $(this).parents("td").data("id");
            loadItem(id);
            return false;
        })
        .delegate(".j-state", "click", function () {
            var $t = $(this),
                id = $t.parents("td").data("id"),
                state = $t.data("state");
            if (!id || "" === state) return false;
            T.setStateBtn.call($t, false);
            T.getJson("/m/reservation/updateState", {
                packageId: id,
                state: state
            }, function (json) {
                if (json.state) {
                    $t.parent().prev().html(
                        singer.format('<span style="color:{color}">{text}</font>',
                            {
                                color: stateColor[state],
                                text: T.stateArray[state + ""]
                            })
                    );
                    var nState = Math.abs(state - 1);
                    T.setStateBtn.call($t, json, nState);
                } else {
                    T.setStateBtn.call($t, json, state);
                }
            });
            return false;
        });
})(jQuery, TJZX);