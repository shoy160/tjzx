window.tjzx = window.tjzx || {};
if (window.ActiveXObject) {
    var ua = navigator.userAgent.toLowerCase();
    tjzx.ie = ua.match(/msie ([\d.]+)/)[1];
}
tjzx.EMPTY='';
tjzx.uri = function (uri) {
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
};
tjzx.is=function(obj, type) {
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
};
var bodyClass=(function(){
    return document.getElementsByTagName("body")[0].className;
})();
tjzx.wideMode=function(){
    var w = Math.max(document.documentElement.clientWidth,document.body.clientWidth),
        c = 'wide-0',
        m = 2,
        cls;
    if(w >= 1220) m=1;
    if(w <= 1000) m=3;
    cls=c+m;
    if(bodyClass)
        cls =bodyClass + ' ' + cls;
    document.getElementsByTagName("body")[0].className=cls;
};
String.prototype.trim = function () {
    try {
        return this.replace(/^\s+|\s+$/g, '');
    }
    catch (e) {
        return this;
    }
};
tjzx.format = function () {
    if (arguments.length <= 0) return this;
    var result = this;
    if (1 === arguments.length && tjzx.is(arguments[0],'object')) {
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
};
tjzx.cookie = {
    set: function (name, value, minutes, domain) {
        if ("string" !== typeof name || "" === name.trim()) return;
        var c = name + '=' + encodeURI(value);
        if ("number" === typeof minutes && minutes > 0) {
            var time = (new Date()).getTime() + 1000 * 60 * minutes;
            c += ';expires=' + (new Date(time)).toGMTString();
        }
        if ("string" == typeof domain)
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
};
String.prototype.replaceAll = function (reg, str) {
    var g = new RegExp(reg, "gi");
    return this.replace(g, str);
};
tjzx.favorite=function(title){
    var d = location.host;
    var c = title|| "四川省人民医院-健康体检中心，您的健康管理专家！";
    if (document.all) {
        window.external.AddFavorite(d, c)
    } else {
        if (window.sidebar && "function" === typeof window.sidebar.addPanel) {
            window.sidebar.addPanel(c, d, "")
        } else {
            alert("对不起，您的浏览器不支持此操作！\n请使用菜单栏或按Ctrl+D收藏本站。")
        }
    }
    tjzx.cookie.set("_tjzx_fv", "1", 30, location.host)
};