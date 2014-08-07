(function ($, T, S) {
    S.mix(T, {
        getJson: function (url, data, success, error) {
            S.mix(data, {t: Math.random()});
            $.ajax({
                url: url,
                type: "post",
                dataType: "json",
                data: data,
                success: function (json) {
                    success && S.isFunction(success) && success.call(this, json);
                },
                error: function (json) {
                    error && S.isFunction(error) && error.call(this, json);
                }
            });
        },
        /**
         * 图片加载异常处理
         * @param selector
         * @param callback
         */
        imageError: function (selector, callback) {
            $(selector)
                .unbind("error.imageError")
                .bind("error.imageError", function () {
                    try {
                        this.setAttribute("raw-src", this.src);
                        this.src = "http://ued.tjzx.com/blank.gif";
                        this.style.background = "url(http://ued.tjzx.com/default.gif) no-repeat scroll 50% 50% transparent";
                        this.style.backgroundSize = "contain";
                    } catch (e) {
                    }
                    callback && "function" === typeof callback && callback();
                })
            ;
        },
        /**
         * 返回顶部
         */
        goTop: function () {
            $('body,html').animate({ scrollTop: 0}, $(window).scrollTop() / 5);
        },
        /**
         * 侧边栏
         */
        setFeedback: function () {
            if (!T.feedback) return false;
            var feedback = T.feedback;
            var fixBox = $('<div class="t-feedback" />');
            $("body").append(fixBox);
            var mode = T.wideMode(),
                boxWidth=$(".t-box").width();
            if(mode){
                boxWidth = mode.width;
            }
            var fixRight = ($(document).width() - boxWidth) / 2 - 45;
            fixBox.css("right", fixRight + "px");
            //在线咨询
            fixBox.append('<div class="fb-item" title="在线咨询">' +
                '<div class="fb-box">' +
                '<s class="icon icon-bigger">&#xf075;</s>' +
                '<s class="icon icon-bigger icon-hover">&#xf075;</s>' +
                '</div>' +
                '</div> ');
            //在线预约
            fixBox.append('<div class="fb-item" title="在线预约">' +
                '<div class="fb-box">' +
                '<s class="icon icon-bigger">&#xf0fa;</s>' +
                '<s class="icon icon-bigger icon-hover">&#xf0fa;</s>' +
                '</div>' +
                '</div> ');
            //体检流程
            fixBox.append('<div class="fb-item" title="体检流程">' +
                '<div class="fb-box">' +
                '<s class="icon icon-bigger">&#xf0e8;</s>' +
                '<s class="icon icon-bigger icon-hover">&#xf0e8;</s>' +
                '</div>' +
                '</div> ');
            //返回顶部
            if (feedback.goTop) {
                fixBox.append('<div class="fb-item" title="返回顶部">' +
                    '<div class="fb-box b-goTop"> ' +
                    '<s class="icon icon-bigger">&#xf077;</s>' +
                    '<s class="icon icon-bigger icon-hover">&#xf077;</s>' +
                    '</div>' +
                    '</div>');
                var goTop = fixBox.find(".b-goTop");
                goTop
                    .bind("click.goTop", function () {
                        T.goTop();
                    });
            }
            fixBox.find(".fb-box")
                .bind("mouseenter", function () {
                    $(this).animate({marginLeft:-38},300);
                })
                .bind("mouseleave",function(){
                    $(this).animate({marginLeft:0},300);
                });
            $(window).bind("scroll.feedback", function () {
                var top = $(this).scrollTop();
                if (top > 150) {
                    fixBox.fadeIn();
                }
                else fixBox.fadeOut();
            });
        }
    });
    /**
     * 顶部菜单栏
     */
    $(".j-menu").hover(function () {
        $(this).toggleClass("menu-hover");
    });
    T.setFeedback();
})(jQuery, TJZX, SINGER);
