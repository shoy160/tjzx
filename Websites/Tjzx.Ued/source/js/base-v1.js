var singer = window.SINGER = window.SINGER || {};
if (window.ActiveXObject) {
    var ua = navigator.userAgent.toLowerCase();
    singer.ie = ua.match(/msie ([\d.]+)/)[1];
    if(singer.ie)
        singer.ie=~~singer.ie;
}
singer.bodyClass=(function(){
    return document.getElementsByTagName("body")[0].className;
})();
if(!String.prototype.trim){
    String.prototype.trim = function () {
        try {
            return this.replace(/^\s+|\s+$/g, '');
        }
        catch (e) {
            return this;
        }
    };
}
String.prototype.replaceAll = function (reg, str) {
    var g = new RegExp(reg, "gi");
    return this.replace(g, str);
};
singer.mix=function(source){
    if("object" === typeof source){
        for(var property in source)
            singer[property]=source[property];
    }
    return singer;
};
singer.mix({
    EMPTY : '',
    is:function(obj, type) {
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
        return (singer.isString(obj) && singer.EMPTY === obj.trim()) || singer.isNull(obj);
    },
    uri:function (uri) {
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
    wideMode:function(){
        if(!singer.compatible) return false;
        var w = Math.max(document.documentElement.clientWidth,document.body.clientWidth),
            c = 'wide-0',
            m = 2,
            cls;
        if(w >= 1220) m=1;
        if(w <= 1000) m=3;
        cls=c+m;
        if(singer.bodyClass)
            cls =singer.bodyClass + ' ' + cls;
        document.getElementsByTagName("body")[0].className=cls;
    },
    format:function () {
        if (arguments.length <= 0) return this;
        var result = this;
        if (1 === arguments.length && singer.isObject(arguments[0])) {
            for (var key in arguments[0]) {
                var reg = new RegExp("\\{" + key + "\\}", "gi");
                result = result.replace(reg, arguments[0][key]);
            }
        } else {
            for (var i = 0; i < arguments.length; i++) {
                var reg = new RegExp("\\{" + i + "\\}", "gi");
                result = result.replace(reg, arguments[i]);
            }
        }
        return result;
    },
    cookie:{
        set: function (name, value, minutes, domain) {
            if (!singer.isString(name) || singer.isEmpty(name)) return;
            var c = name + '=' + encodeURI(value);
            if (singer.isNumber(minutes) && minutes > 0) {
                var time = (new Date()).getTime() + 1000 * 60 * minutes;
                c += ';expires=' + (new Date(time)).toGMTString();
            }
            if (singer.isString(domain) && !singer.isEmpty(domain))
                c += ';domain=' + domain;
            document.cookie = c + '; path=/';
        },
        get: function (name) {
            var b = document.cookie;
            var d = name + '=';
            var c = b.indexOf('; ' + d);
            if (c == -1) {
                c = b.indexOf(d);
                if (c != 0) {
                    return null;
                }
            }
            else {
                c += 2;
            }
            var a = b.indexOf(';', c);
            if (a == -1) {
                a = b.length;
            }
            return decodeURI(b.substring(c + d.length, a));
        },
        clear: function (name, domain) {
            if (this.get(name)) {
                document.cookie = name + '=' + (domain ? '; domain=' + domain : '') + '; expires=Thu, 01-Jan-70 00:00:01 GMT';
            }
        }
    },
    favorite:function(title){
        var d = location.host;
        var c = title|| "四川省人民医院-健康体检中心，您的健康管理专家！";
        if (document.all) {
            window.external.AddFavorite(d, c);
        } else {
            if (window.sidebar && singer.isFunction(window.sidebar.addPanel)) {
                window.sidebar.addPanel(c, d, "");
            } else {
                alert("对不起，您的浏览器不支持此操作！\n请使用菜单栏或按Ctrl+D收藏本站。");
            }
        }
        singer.cookie.set("_singer_fv", "1", 30, location.host);
    }
});