(function ($) {
    $.fn.extend({
        /**
         * 收起/隐藏插件
         * @param options
         * @returns {*}
         */
        hiddenAway: function (options) {
            var opts = $.extend({
                    toggleClass: 'ha-show',     //切换的class
                    container: 'ha-content',    //切换的容器
                    state: 0,                   //初始状态
                    toggleHtml: null,          //切换的html
                    joint: null,               //协同控制
                    time: 300                   //切换时间(秒)
                }, options || {}),
                $t = $(this);
            return $.each($t, function (i) {
                var $item = $t.eq(i),
                    data = $item.data("hiddenaway") || $item.attr("data-hiddenaway"),
                    ps = opts;
                if (data && "string" === typeof data) {
                    try {
                        data = eval('(' + data + ')');
                    } catch (e) {
                    }
                }
                if ("object" === typeof data)
                    ps = $.extend(ps, data);
                $(ps.container).data("state", ps.state);
                $item
                    .data("container", ps.container)
                    .data("toggleClass", ps.toggleClass)
                    .data("toggleHtml", ps.toggleHtml)
                    .data("joint", $(ps.joint))
                    .data("time",ps.time);
                var toggleFn = function (obj, toggle) {
                    var $h = $(obj),
                        $c = $($h.data("container")),
                        cls = $h.data("toggleClass"),
                        time=$h.data("time"),
                        htm, $joint;
                    cls && $h.toggleClass(cls);
                    if (toggle) {
                        var state = $c.data("state");
                        if (state) {
                            $c.fadeOut(time).data("state", 0);
                        } else {
                            $c.fadeIn(time).data("state", 1);
                        }
                    }
                    htm = $h.data("toggleHtml");
                    if (htm != null) {
                        $h.data("toggleHtml", $h.html()).html(htm);
                    }
                    $joint = $h.data("joint");
                    if (toggle && $joint) {
                        toggleFn($joint, false);
                    }
                };
                $item.bind("click", function () {
                    toggleFn(this, true);
                    return false;
                });
            });
        }
    });
    $(".j-hiddenAway").hiddenAway({});
})(jQuery);