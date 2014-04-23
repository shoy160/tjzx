(function ($, T) {
    var size = 10;
    var h = new hTemplate({
        tmp: $("#h-temp").html(),
        empty: $("#h-empty").html(),
        container: $(".t-package-list"),
        pager: $(".h-pager"),
        size: size,
        pageClick: function (page) {
            getList(page - 1);
            $("body,html").animate({scrollTop: 0}.$(window).scrollTop() / 5);
            return false;
        }
    });
    var getList = function (page) {
        /\/packages\/(\d+)/.exec(location.href);
        var id = RegExp.$1 || 0;
        T.getJson("/package_list", {
            id: id,
            page: page,
            size: size
        }, function (json) {
            if (json && json.state) {
                var list = [];
                for (var i = 0; i < 32; i++)
                    list.push(json.data.list[0]);
                h.bind(list, 259);
            }
        });
    };
    getList(0);
    $(".t-package-list")
        .delegate("li", "mouseover", function () {
            $(this).addClass("active");
        })
        .delegate("li", "mouseout", function () {
            $(this).removeClass("active");
        })
    ;
})(jQuery, TJZX);