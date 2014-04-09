var singer = window.SINGER = {
    EMPTY: '',
    is: function (obj, type) {
        var isNan = {"NaN": 1, "Infinity": 1, "-Infinity": 1}
        type = type.toLowerCase();
        if (type == "finite") {
            return !isNan["hasOwnProperty"](+obj);
        }
        if (type == "array") {
            return obj instanceof Array;
        }
        return  (type == "null" && obj === null) ||
            (type == typeof obj && obj !== null) ||
            (type == "object" && obj === Object(obj)) ||
            (type == "array" && Array.isArray && Array.isArray(obj)) ||
            Object.prototype.toString.call(obj).slice(8, -1).toLowerCase() == type;
    },
    isObject: function (obj) {
        return singer.is(obj, "object");
    },
    isArray: function (obj) {
        return singer.is(obj, "array");
    },
    isNumber: function (obj) {
        return singer.is(obj, "number");
    },
    isFunction: function (obj) {
        return singer.is(obj, "function");
    },
    isNull: function (obj) {
        return singer.is(obj, "null");
    },
    isString: function (obj) {
        return singer.is(obj, "string");
    },
    isEmpty: function (obj) {
        return (singer.isString(obj) && singer.EMPTY === $.trim(obj)) || singer.isNull(obj);
    },
    uri: function (uri) {
        var q = [], qs;
        qs = (uri ? uri + "" : location.search);
        if (qs.indexOf('?') >= 0) {
            qs = qs.substring(1);
        }
        if (qs) {
            qs = qs.split('&');
        }
        if (qs.length > 0) {
            for (var i = 0; i < qs.length; i++) {
                var qt = qs[i].split('=');
                q[qt[0]] = decodeURIComponent(qt[1]);
            }
        }
        return q;
    },
    msg: function (msg) {
        if (top.window && top.window.MSG)
            top.window.MSG(msg);
        else {
            var content = "";
            if (singer.isString(msg))
                content = msg;
            else if(singer.isObject(msg))
                content = (msg.content || "");
            alert(content);
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
        $.ajax({
            url: url,
            type: 'post',
            dataType: 'json',
            data: data,
            success: function (data) {
                callback && singer.isFunction(callback) && callback(data);
            },
            error: function (data) {
                singer.msg('获取数据异常！');
                errorCallback && singer.isFunction(errorCallback) && errorCallback(data);
            }
        });
    },
    setFrameHeight:function(){
        top.window && top.window.SetFrameHeight && top.window.SetFrameHeight();
    }
};

/**
 *  绑定模板事件
 */
$(".m-panel-title")
    .delegate("li", "click", function () {
        if ($(this).hasClass("active")) return false;
        var $t = $(this),
            $lis = $t.parents(".m-panel").find(".m-panel-item"),
            index = $t.parent().find("li").index($t);
        $t.addClass("active").siblings("li").removeClass("active");
        $lis.hide().eq(index).fadeIn();
        singer.setFrameHeight();
        return false;
    });