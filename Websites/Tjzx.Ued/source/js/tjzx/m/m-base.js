/**
 * 后台管理页面基础js
 * @type {{}|*|window.TJZX}
 */
var tjzx = window.TJZX = window.TJZX || {};
(function ($,S, T) {
    S.mix(T, {
        msg: function (msg,url) {
            if (top.window && top.window.MSG)
                top.window.MSG(msg,url);
            else {
                var content = "";
                if (S.isString(msg))
                    content = msg;
                else if (S.isObject(msg))
                    content = (msg.content || "");
                alert(content);
                if("reload" === url){
                    location.reload(true);
                }else if(url && "string" === typeof url){
                    location.href = url;
                }
            }
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
        getJson: function (url, data, callback, errorCallback) {
            S.mix(data, {t: Math.random()});
            $.ajax({
                url: url,
                type: 'post',
                dataType: 'json',
                data: data,
                success: function (data) {
                    callback && S.isFunction(callback) && callback(data);
                },
                error: function (data) {
                    T.msg('获取数据异常！');
                    errorCallback && S.isFunction(errorCallback) && errorCallback(data);
                }
            });
        },
        setFrameHeight: function () {
            top.window && top.window.SetFrameHeight && top.window.SetFrameHeight();
        }
    });
})(jQuery,SINGER, TJZX);

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
        tjzx.setFrameHeight();
    });