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
                    ps = $.extend({},opts);
                if (data && "string" === typeof data) {
                    try {
                        data = eval('(' + data + ')');
                    } catch (e) {
                    }
                }
                if ("object" === typeof data)
                    ps = $.extend(ps, data);
                $(ps.container).data("state", ps.state);
                $item.data("ps", ps);
                var toggleFn = function (obj, toggle) {
                    var $h = $(obj),
                        ops= $h.data("ps"),
                        $c = $(ops.container),
                        cls = ops.toggleClass,
                        time = ops.time,
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
                    htm = ops.toggleHtml;
                    if (htm != null) {
                        ops.toggleHtml = $h.html();
                        $h.html(htm);
                    }
                    $joint = $(ops.joint);
                    if (toggle && $joint) {
                        toggleFn($joint, false);
                    }
                    $h.data("ps",ops)
                };
                $item.bind("click", function () {
                    toggleFn(this, true);
                    return false;
                });
            });
        },
        /**
         * 自适应高度
         * @param opt
         */
        autoHeight: function (options) {
            var opts = $.extend({
                    leftHeight: 314,
                    minHeight: 350
                }, options || {}),
                $t = $(this);
            var setHeight = function () {
                var sh = $(window).height();
                $t.each(function(i){
                    var $item=$t.eq(i),
                        left=$item.data("left") || opts.leftHeight,
                        min = $item.data("min") || opts.minHeight,
                        h = sh - left;
                    if (h <= min) h = min;
                    $item.css({"height": h});
                });
            };
            setHeight();
            $(window).bind("resize.autoHeight", function () {
                setHeight();
            });
        }
    });
    $(".j-hiddenAway").hiddenAway();
    $(".j-autoHeight").autoHeight();
})(jQuery);