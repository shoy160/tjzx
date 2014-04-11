/**
 * 后台管理中心 模板页面基础js
 */
seajs.config({
    alias: {
        "jquery": "jquery-1.10.2.js",
        "dialog": "//ued.tjzx.com/plugs/artDialog/v6/src/dialog"
    }
});
var msg = window.MSG = function (opt, url) {
    if ("string" === typeof opt || "number" === typeof opt) {
        opt = {
            title: "操作提示",
            content: opt,
            okValue: "确认",
            ok: function () {
                if (-1 === url) {
                    location.href = "/m/login?return_url=" + encodeURI(location.href);
                } else if ("reload" === url) {
                    frameLoad();
                } else if ("string" === typeof url && url) {
                    frameLoad(url);
                }
                this.close().remove();
                return false;
            },
            modal: true
        };
    }
    seajs.use("dialog", function (D) {
        var d = D(opt);
        (opt.modal && d.showModal()) || (opt.obj && d.show(opt.obj)) || d.show();
    });
};
var callback = window.CALLBACK = function (json) {
    if (!json || json.state < 1) {
        msg(json.msg || "操作异常！", json.state || 0);
        return false;
    }
    return true;
};
(function ($, S) {
    var topTemp = new hTemplate({
        tmp: $("#h-topMenu").html(),
        container: $(".m-nav ul"),
        empty: ''
    });
    var menuTemp = new hTemplate({
        tmp: $("#h-menu").html(),
        container: $(".m-menus ul"),
        empty: ''
    });
    var fillTop = function (json) {
        if (!S.isArray(json) || !json.length) return false;
        json[0].active = " class=\"active\"";
        topTemp.bind(json);
        $(".m-nav li:eq(0)").click();
        return true;
    };
    var fillMenu = function (json) {
        if (!S.isArray(json) || !json.length) return false;
        menuTemp.bind(json);
        $(".m-menus li:eq(0)").click();
        return true;
    };
    var setCrumbs = function () {
        var $top = $(".m-nav li a.active"),
            $menu = $(".m-menus li a.active"),
            $crumbs = $(".m-crumbs");
        $crumbs.find("dd").remove();
        $crumbs.append(
            S.format('<dd><a href="#" data-id="{id}">{text}</a></dd>',
                {id: $top.parent().data("id"), text: $top.text()}
            )
        );
        $crumbs.append(S.format('<dd class="active">{text}</dd>', {text: $menu.text()}));
    };

    var getMenus = function (parentId) {
        $.ajax({
            url: '/m/menus',
            type: 'post',
            dataType: 'json',
            data: { parentId: parentId, t: Math.random() },
            success: function (json) {
                if (!callback(json)) return false;
                if (S.isArray(json) && json.length) {
                    if (parentId == 0)
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
var setFrameHeight = window.SetFrameHeight = function () {
    var h = 1200,
        $frame = $("#framePage");
    try {
        h = $frame.contents().find("body").height();
    } catch (e) {
    }
    $frame.css("height", h + 20);
};
var frameLoad = function (url) {
    if (!url)
        window.frames['framePage'].location.reload();
    $("#framePage").attr("src", url);
};
$("#framePage").load(function () {
    setFrameHeight();
});