seajs.config({
    alias: {
        "jquery": "jquery-1.10.2.js",
        "dialog": "//ued.tjzx.com/plugs/artDialog/v6/src/dialog"
    }
});
var msg = window.MSG = function (opt,state) {
    if ("string" === typeof opt) {
        opt = {
            title: "操作提示",
            content: opt,
            okValue: "确认",
            ok: function () {
                if (-1 === state) {
                    location.href = "/m/login?return_url="+encodeURI(location.href);
                }
                this.close();
                return false;
            },
            modal: true
        };
    }
    seajs.use("dialog", function (D) {
        var d = D(opt);
        (opt.modal && d.showModal()) || d.show();
    });
};
var callback=window.CALLBACK=function(json){
    if(!json || json.state < 1){
        msg(json.msg || "操作异常！",json.state || 0);
        return false;
    }
    return true;
};
(function ($, S) {
    var fillTop = function (json) {
        if (!S.isArray(json) || !json.length) return false;
        json[0].activeCues = " class=\"active\"";
        var h = new hTemplate({
            tmp: '<li data-id="{id}">' +
                '<a href="#"{active}>' +
                '<i class="{cls}"></i>{name}</a>',
            container: $(".m-nav ul"),
            empty: ''
        });
        h.bind(json);
        $(".m-nav li:eq(0)").click();
        return true;
    };
    var fillMenu = function (json) {
        if (!S.isArray(json) || !json.length) return false;
        var h = new hTemplate({
            tmp: '<li>' +
                '<a href="{link}" title="{name}">' +
                '<i class="{cls}"></i>{name}</a>',
            container: $(".m-menus ul"),
            empty: ''
        });
        h.bind(json);
        $(".m-menus li:eq(0)").click();
        return true;
    };
    var setCrumbs = function () {
        var $top = $(".m-nav li a.active"),
            $menu = $(".m-menus li a.active"),
            $crumbs = $(".m-crumbs");
        $crumbs.find("dd").remove();
        $crumbs.append('<dd><a href="#" data-id="' + $top.parent().data("id") + '">' + $top.text() + '</a></dd>');
        $crumbs.append('<dd class="active">' + $menu.text() + '</dd>');
    };

    var getMenus = function (parendId) {
        $.ajax({
            url: '/m/menus',
            type: 'post',
            dataType: 'json',
            data: { parentId: parendId, t: Math.random() },
            success: function (json) {
                if(!callback(json)) return false;
                if (S.isObject(json) && json.length) {
                    if (parendId == 0)
                        fillTop(json);
                    else
                        fillMenu(json);
                }
            },
            error: function (json) {
                //gotoLogin();
            }
        });
    };
    getMenus(0);
    $(".m-nav,.m-menus")
        .delegate("li", "click", function () {
            var $a = $(this).find(">a");
            if (!$(this).data("id") && $a.hasClass("active")) return false;
            $a.addClass("active");
            $(this).siblings("li").find(">a").removeClass("active");
            var id = ~~$(this).data("id");
            if (id && id > 0) {
                getMenus(id);
            } else {
                var link = $a.attr("href");
                $("#framePage").attr("src", link);
                setCrumbs();
            }
            return false;
        });
    $(".m-crumbs")
        .delegate("a", "click", function () {
            var id = $(this).data("id");
            if (id)
                $(".m-nav li[data-id='" + id + "']").click();
            return false;
        });
})(jQuery, SINGER);
$("#framePage").load(function () {
    var h = 1200;
    try {
        h = $(this).contents().find("body").height();
    } catch (e) {
    }
    $(this).css("height", h+20);
});