define(function (require) {
    var $ = require('jquery');
    var dialog = require('./dialog-plus'),
        call = function (callback) {
            callback && "function" === typeof callback && callback.call(this);
        };
    var init = function (opt) {
        var d = new dialog(opt);
        if (opt.modal) {
            d.showModal();
        } else if (opt.element) {
            d.show(opt.element);
        } else {
            d.show();
        }
        return d;
    };
    /**
     * 抖动
     * @param time
     * @returns {dialog}
     */
    dialog.prototype.snake = function (time) {
        var style = this.node.style,
            p = [4, 8, 4, 0, -4, -8, -4, 0],
            fx = function () {
                style.marginLeft = p.shift() + 'px';
                if (p.length <= 0) {
                    style.marginLeft = 0;
                    clearInterval(timerId);
                }
            },
            timerId;
        p = p.concat(p.concat(p));
        timerId = setInterval(fx, time || 13);
        return this;
    };

    dialog.commonInit = function (opt) {
        return init(opt);
    };
    /**
     * 重写alert
     * @param msg
     * @param callback
     */
    dialog.alert = function (msg, callback) {
        var option = {
            title: "操作提示",
            content: msg,
            padding: 20,
            okValue: "确认",
            ok: true,
            onclose: function () {
                call(callback);
            },
            modal: true
        };
        return init(option);
    };
    /**
     * 重写confirm
     * @param msg
     * @param ok
     * @param cancel
     */
    dialog.confirm = function (msg, ok, cancel) {
        var opt = {
            title: "操作提示",
            content: msg,
            padding: 20,
            okValue: "确认",
            ok: function () {
                call(ok);
            },
            cancelValue: "取消",
            cancel: function () {
                call(cancel);
            },
            modal: true
        };
        return init(opt);
    };
    /**
     * 重写prompt
     * @param content
     * @param yes
     * @param value
     * @returns {*}
     */
    dialog.prompt = function (content, yes, value) {
        value = value || '';
        var input;

        return init({
            id: 'Prompt',
            icon: 'question',
            fixed: true,
            modal: true,
            opacity: .1,
            content: [
                '<div style="margin-bottom:5px;font-size:12px">',
                content,
                '</div>',
                '<div>',
                '<input value="',
                value,
                '" style="width:18em;padding:6px 4px" />',
                '</div>'
            ].join(''),
            onshow: function () {
                input = $(this.node).find('input')[0];
                input.select();
                input.focus();
            },
            ok: function (here) {
                return yes && yes.call(this, input.value, here);
            },
            cancel: true
        });
    };
    return dialog;
});