/*! tjzx.ued version:0.1.0 2014-05-13 09:00:00 */
!function(a){function b(b){var d=a.data(b,"menubutton").options,e=a(b);if(e.removeClass(d.cls.btn1+" "+d.cls.btn2).addClass("m-btn"),e.linkbutton(a.extend({},d,{text:d.text+'<span class="'+d.cls.arrow+'">&nbsp;</span>'})),d.menu){a(d.menu).menu();var f=a(d.menu).menu("options"),g=f.onShow,h=f.onHide;a.extend(f,{onShow:function(){var b=a(this).menu("options"),c=a(b.alignTo),d=c.menubutton("options");c.addClass(1==d.plain?d.cls.btn2:d.cls.btn1),g.call(this)},onHide:function(){var b=a(this).menu("options"),c=a(b.alignTo),d=c.menubutton("options");c.removeClass(1==d.plain?d.cls.btn2:d.cls.btn1),h.call(this)}})}c(b,d.disabled)}function c(b,c){var e=a.data(b,"menubutton").options;e.disabled=c;var f=a(b),g=f.find("."+e.cls.trigger);if(g.length||(g=f),g.unbind(".menubutton"),c)f.linkbutton("disable");else{f.linkbutton("enable");var h=null;g.bind("click.menubutton",function(){return d(b),!1}).bind("mouseenter.menubutton",function(){return h=setTimeout(function(){d(b)},e.duration),!1}).bind("mouseleave.menubutton",function(){h&&clearTimeout(h)})}}function d(b){var c=a.data(b,"menubutton").options;if(!c.disabled&&c.menu){a("body>div.menu-top").menu("hide");var d=a(b),e=a(c.menu);e.length&&(e.menu("options").alignTo=d,e.menu("show",{alignTo:d})),d.blur()}}a.fn.menubutton=function(c,d){if("string"==typeof c){var e=a.fn.menubutton.methods[c];return e?e(this,d):this.linkbutton(c,d)}return c=c||{},this.each(function(){var d=a.data(this,"menubutton");d?a.extend(d.options,c):(a.data(this,"menubutton",{options:a.extend({},a.fn.menubutton.defaults,a.fn.menubutton.parseOptions(this),c)}),a(this).removeAttr("disabled")),b(this)})},a.fn.menubutton.methods={options:function(b){var c=b.linkbutton("options"),d=a.data(b[0],"menubutton").options;return d.toggle=c.toggle,d.selected=c.selected,d},enable:function(a){return a.each(function(){c(this,!1)})},disable:function(a){return a.each(function(){c(this,!0)})},destroy:function(b){return b.each(function(){var b=a(this).menubutton("options");b.menu&&a(b.menu).menu("destroy"),a(this).remove()})}},a.fn.menubutton.parseOptions=function(b){a(b);return a.extend({},a.fn.linkbutton.parseOptions(b),a.parser.parseOptions(b,["menu",{plain:"boolean",duration:"number"}]))},a.fn.menubutton.defaults=a.extend({},a.fn.linkbutton.defaults,{plain:!0,menu:null,duration:100,cls:{btn1:"m-btn-active",btn2:"m-btn-plain-active",arrow:"m-btn-downarrow",trigger:"m-btn"}})}(jQuery);