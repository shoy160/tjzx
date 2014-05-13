/**
 * 后台管理页面基础js
 * @type {{}|*|window.TJZX}
 */
var tjzx = window.TJZX = window.TJZX || {};

/**
 *  重载Dialog
 */
if (!top.window || !top.window.Dialog) {
    var Dialog, Alert, Confirm;
    seajs.use(["plus"], function (D) {
        Dialog = window.Dialog = D.commonInit;
        Alert = window.Alert = D.alert;
        Confirm = window.Confirm = D.confirm;
    });
} else {
    window.Dialog = top.window.Dialog;
    window.Alert = top.window.Alert;
    window.Confirm = top.window.Confirm;
}
(function ($, S, T) {
    var logger = S.getLogger("m-base");
    $(".btn").removeAttr("disabled");
    S.mix(T, {
        msg: function (msg, url) {
            Alert(msg, function () {
                if ("reload" === url) {
                    location.reload(true);
                } else if (url && "string" === typeof url) {
                    location.href = url;
                }
            });
        },
        setBtn: function (obj, state) {
            var $btns = $(obj);
            if (state) {
                $btns.removeAttr("disabled").removeClass("disabled");
            } else {
                $btns.attr("disabled", "disabled").addClass("disabled");
            }
            $btns.each(function (i) {
                var $item = $btns.eq(i);
                if ($item.data("state") != state) {
                    var tag = $item.html();
                    $item.html($item.data("tag") || tag + "中...");
                    $item.data("tag", tag).data("state", state);
                }
            });
        },
        stateArray: {
            "0": "隐藏",
            "1": "显示",
            "2": "删除"
        },
        /**
         * 设置状态更新链接
         * @param json
         * @param state
         * @returns {boolean}
         */
        setStateBtn: function (json, state) {
            var t = this;
            if (!t || !t.is("a")) return false;
            if (S.isBoolean(json) && !json) {
                t.data("state", "").css("color", "#333").html("正在提交...");
            } else if (S.isObject(json)) {
                var color = (json.state ? "Green" : "Red"),
                    msg = (json.state ? "更新成功" : (json.msg || "更新失败！"));
                t.data("state", "").css("color", color).html(msg);
                setTimeout(function () {
                    t.data("state", state).css("color", "#428BCA").html(T.stateArray[state]);
                }, 1200);
            }
        },
        getJson: function (url, data, callback, errorCallback) {
            S.mix(data, {t: Math.random()});
            $.ajax({
                url: url,
                type: 'post',
                dataType: 'json',
                data: data,
                success: function (data) {
                    if (data && data.state == -1) {
                        Alert(data.msg || "操作异常！", function () {
                            top.window.location.href = "/m/login?return_url=" + encodeURIComponent(top.window.location.href);
                            T.setFrameHeight();
                        });
                        return false;
                    }
                    callback && S.isFunction(callback) && callback(data);
                },
                error: function (data) {
                    if (!errorCallback)
                        Alert(data.statusText || '获取数据异常！');
                    else
                        S.isFunction(errorCallback) && errorCallback(data);
                }
            });
        },
        setFrameHeight: function () {
            top.window && top.window.SetFrameHeight && top.window.SetFrameHeight();
        }
    });
})(jQuery, SINGER, TJZX);

/**
 *  绑定模板事件
 */
$(".m-panel-title")
    .delegate("li", "click", function () {
        if ($(this).hasClass("active")) return false;
        var $t = $(this),
            $lis = $t.parents(".m-panel").find(".m-panel-item"),
            index = $t.parent().find("li").index($t);
        $t.parent().find(".m-panel-add").remove();
        $t.addClass("active").siblings("li").removeClass("active");
        $lis.hide().eq(index).fadeIn();
        TJZX.setFrameHeight();
    });