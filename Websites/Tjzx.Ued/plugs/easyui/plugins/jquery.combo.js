/*! tjzx.ued version:0.1.0 2014-05-13 09:00:00 */
!function(a){function b(b,c){var d=a.data(b,"combo"),e=d.options,f=d.combo,g=d.panel;if(c&&(e.width=c),isNaN(e.width)){var h=a(b).clone();h.css("visibility","hidden"),h.appendTo("body"),e.width=h.outerWidth(),h.remove()}f.appendTo("body");var i=f.find("input.combo-text"),j=f.find(".combo-arrow"),k=e.hasDownArrow?j._outerWidth():0;f._outerWidth(e.width)._outerHeight(e.height),i._outerWidth(f.width()-k),i.css({height:f.height()+"px",lineHeight:f.height()+"px"}),j._outerHeight(f.height()),g.panel("resize",{width:e.panelWidth?e.panelWidth:f.outerWidth(),height:e.panelHeight}),f.insertAfter(b)}function c(b){a(b).addClass("combo-f").hide();var c=a('<span class="combo"><input type="text" class="combo-text" autocomplete="off"><span><span class="combo-arrow"></span></span><input type="hidden" class="combo-value"></span>').insertAfter(b),d=a('<div class="combo-panel"></div>').appendTo("body");d.panel({doSize:!1,closed:!0,cls:"combo-p",style:{position:"absolute",zIndex:10},onOpen:function(){a(this).panel("resize")},onClose:function(){var c=a.data(b,"combo");c&&c.options.onHidePanel.call(b)}});var e=a(b).attr("name");return e&&(c.find("input.combo-value").attr("name",e),a(b).removeAttr("name").attr("comboName",e)),{combo:c,panel:d}}function d(b){var c=a.data(b,"combo"),d=c.options,e=c.combo;d.hasDownArrow?e.find(".combo-arrow").show():e.find(".combo-arrow").hide(),k(b,d.disabled),l(b,d.readonly)}function e(b){var c=a.data(b,"combo"),d=c.combo.find("input.combo-text");d.validatebox("destroy"),c.panel.panel("destroy"),c.combo.remove(),a(b).remove()}function f(b){a(b).find(".combo-f").each(function(){var b=a(this).combo("panel");b.is(":visible")&&b.panel("close")})}function g(b){function c(){if(g.is(":visible"))f(g),i(b);else{var c=a(this).closest("div.combo-panel");a("div.combo-panel:visible").not(g).not(c).panel("close"),a(b).combo("showPanel")}j.focus()}var d=a.data(b,"combo"),e=d.options,g=d.panel,h=d.combo,j=h.find(".combo-text"),k=h.find(".combo-arrow");a(document).unbind(".combo").bind("mousedown.combo",function(b){var c=a(b.target).closest("span.combo,div.combo-p");return c.length?void f(c):void a("body>div.combo-p>div.combo-panel:visible").panel("close")}),j.unbind(".combo"),k.unbind(".combo"),e.disabled||e.readonly||(j.bind("click.combo",function(){if(e.editable){var b=a(this).closest("div.combo-panel");a("div.combo-panel:visible").not(g).not(b).panel("close")}else c.call(this)}).bind("keydown.combo",function(c){switch(c.keyCode){case 38:e.keyHandler.up.call(b,c);break;case 40:e.keyHandler.down.call(b,c);break;case 37:e.keyHandler.left.call(b,c);break;case 39:e.keyHandler.right.call(b,c);break;case 13:return c.preventDefault(),e.keyHandler.enter.call(b,c),!1;case 9:case 27:i(b);break;default:e.editable&&(d.timer&&clearTimeout(d.timer),d.timer=setTimeout(function(){var f=j.val();d.previousValue!=f&&(d.previousValue=f,a(b).combo("showPanel"),e.keyHandler.query.call(b,j.val(),c),a(b).combo("validate"))},e.delay))}}),k.bind("click.combo",function(){c.call(this)}).bind("mouseenter.combo",function(){a(this).addClass("combo-arrow-hover")}).bind("mouseleave.combo",function(){a(this).removeClass("combo-arrow-hover")}))}function h(b){function c(){var b=f.offset().left;return b+g._outerWidth()>a(window)._outerWidth()+a(document).scrollLeft()&&(b=a(window)._outerWidth()+a(document).scrollLeft()-g._outerWidth()),0>b&&(b=0),b}function d(){var b=f.offset().top+f._outerHeight();return b+g._outerHeight()>a(window)._outerHeight()+a(document).scrollTop()&&(b=f.offset().top-g._outerHeight()),b<a(document).scrollTop()&&(b=f.offset().top+f._outerHeight()),b}var e=a.data(b,"combo").options,f=a.data(b,"combo").combo,g=a.data(b,"combo").panel;a.fn.window&&g.panel("panel").css("z-index",a.fn.window.defaults.zIndex++),g.panel("move",{left:f.offset().left,top:d()}),g.panel("options").closed&&(g.panel("open"),e.onShowPanel.call(b)),function(){g.is(":visible")&&(g.panel("move",{left:c(),top:d()}),setTimeout(arguments.callee,200))}()}function i(b){var c=a.data(b,"combo").panel;c.panel("close")}function j(b){var c=a.data(b,"combo").options,d=a(b).combo("textbox");d.validatebox(a.extend({},c,{deltaX:c.hasDownArrow?c.deltaX:c.deltaX>0?1:-1}))}function k(b,c){var d=a.data(b,"combo"),e=d.options,f=d.combo;c?(e.disabled=!0,a(b).attr("disabled",!0),f.find(".combo-value").attr("disabled",!0),f.find(".combo-text").attr("disabled",!0)):(e.disabled=!1,a(b).removeAttr("disabled"),f.find(".combo-value").removeAttr("disabled"),f.find(".combo-text").removeAttr("disabled"))}function l(b,c){var d=a.data(b,"combo"),e=d.options;e.readonly=void 0==c?!0:c;var f=e.readonly?!0:!e.editable;d.combo.find(".combo-text").attr("readonly",f).css("cursor",f?"pointer":"")}function m(b){var c=a.data(b,"combo"),d=c.options,e=c.combo;d.multiple?e.find("input.combo-value").remove():e.find("input.combo-value").val(""),e.find("input.combo-text").val("")}function n(b){var c=a.data(b,"combo").combo;return c.find("input.combo-text").val()}function o(b,c){var d=a.data(b,"combo"),e=d.combo.find("input.combo-text");e.val()!=c&&(e.val(c),a(b).combo("validate"),d.previousValue=c)}function p(b){var c=[],d=a.data(b,"combo").combo;return d.find("input.combo-value").each(function(){c.push(a(this).val())}),c}function q(b,c){var d=a.data(b,"combo").options,e=p(b),f=a.data(b,"combo").combo;f.find("input.combo-value").remove();for(var g=a(b).attr("comboName"),h=0;h<c.length;h++){var i=a('<input type="hidden" class="combo-value">').appendTo(f);g&&i.attr("name",g),i.val(c[h])}for(var j=[],h=0;h<e.length;h++)j[h]=e[h];for(var k=[],h=0;h<c.length;h++)for(var l=0;l<j.length;l++)if(c[h]==j[l]){k.push(c[h]),j.splice(l,1);break}(k.length!=c.length||c.length!=e.length)&&(d.multiple?d.onChange.call(b,c,e):d.onChange.call(b,c[0],e[0]))}function r(a){var b=p(a);return b[0]}function s(a,b){q(a,[b])}function t(b){var c=a.data(b,"combo").options,d=c.onChange;c.onChange=function(){},c.multiple?(c.value?"object"==typeof c.value?q(b,c.value):s(b,c.value):q(b,[]),c.originalValue=p(b)):(s(b,c.value),c.originalValue=c.value),c.onChange=d}a.fn.combo=function(e,f){if("string"==typeof e){var h=a.fn.combo.methods[e];return h?h(this,f):this.each(function(){var b=a(this).combo("textbox");b.validatebox(e,f)})}return e=e||{},this.each(function(){var f=a.data(this,"combo");if(f)a.extend(f.options,e);else{var h=c(this);f=a.data(this,"combo",{options:a.extend({},a.fn.combo.defaults,a.fn.combo.parseOptions(this),e),combo:h.combo,panel:h.panel,previousValue:null}),a(this).removeAttr("disabled")}d(this),b(this),g(this),j(this),t(this)})},a.fn.combo.methods={options:function(b){return a.data(b[0],"combo").options},panel:function(b){return a.data(b[0],"combo").panel},textbox:function(b){return a.data(b[0],"combo").combo.find("input.combo-text")},destroy:function(a){return a.each(function(){e(this)})},resize:function(a,c){return a.each(function(){b(this,c)})},showPanel:function(a){return a.each(function(){h(this)})},hidePanel:function(a){return a.each(function(){i(this)})},disable:function(a){return a.each(function(){k(this,!0),g(this)})},enable:function(a){return a.each(function(){k(this,!1),g(this)})},readonly:function(a,b){return a.each(function(){l(this,b),g(this)})},isValid:function(b){var c=a.data(b[0],"combo").combo.find("input.combo-text");return c.validatebox("isValid")},clear:function(a){return a.each(function(){m(this)})},reset:function(b){return b.each(function(){var b=a.data(this,"combo").options;b.multiple?a(this).combo("setValues",b.originalValue):a(this).combo("setValue",b.originalValue)})},getText:function(a){return n(a[0])},setText:function(a,b){return a.each(function(){o(this,b)})},getValues:function(a){return p(a[0])},setValues:function(a,b){return a.each(function(){q(this,b)})},getValue:function(a){return r(a[0])},setValue:function(a,b){return a.each(function(){s(this,b)})}},a.fn.combo.parseOptions=function(b){var c=a(b);return a.extend({},a.fn.validatebox.parseOptions(b),a.parser.parseOptions(b,["width","height","separator",{panelWidth:"number",editable:"boolean",hasDownArrow:"boolean",delay:"number",selectOnNavigation:"boolean"}]),{panelHeight:"auto"==c.attr("panelHeight")?"auto":parseInt(c.attr("panelHeight"))||void 0,multiple:c.attr("multiple")?!0:void 0,disabled:c.attr("disabled")?!0:void 0,readonly:c.attr("readonly")?!0:void 0,value:c.val()||void 0})},a.fn.combo.defaults=a.extend({},a.fn.validatebox.defaults,{width:"auto",height:22,panelWidth:null,panelHeight:200,multiple:!1,selectOnNavigation:!0,separator:",",editable:!0,disabled:!1,readonly:!1,hasDownArrow:!0,value:"",delay:200,deltaX:19,keyHandler:{up:function(){},down:function(){},left:function(){},right:function(){},enter:function(){},query:function(){}},onShowPanel:function(){},onHidePanel:function(){},onChange:function(){}})}(jQuery);