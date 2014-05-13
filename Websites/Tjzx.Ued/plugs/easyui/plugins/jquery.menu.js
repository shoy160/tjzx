/*! tjzx.ued version:0.1.0 2014-05-13 09:00:00 */
!function($){function _1(a){function b(c){var d=[];return c.addClass("menu"),d.push(c),c.hasClass("menu-content")||c.children("div").each(function(){var c=$(this).children("div");if(c.length){c.insertAfter(a),this.submenu=c;var e=b(c);d=d.concat(e)}}),d}function c(b){var c=$.parser.parseOptions(b[0],["width"]).width;b.hasClass("menu-content")?b[0].originalWidth=c||b._outerWidth():(b[0].originalWidth=c||0,b.children("div").each(function(){var b=$(this),c=$.extend({},$.parser.parseOptions(this,["name","iconCls","href",{separator:"boolean"}]),{disabled:b.attr("disabled")?!0:void 0});if(c.separator&&b.addClass("menu-sep"),!b.hasClass("menu-sep")){b[0].itemName=c.name||"",b[0].itemHref=c.href||"";var d=b.addClass("menu-item").html();b.empty().append($('<div class="menu-text"></div>').html(d)),c.iconCls&&$('<div class="menu-icon"></div>').addClass(c.iconCls).appendTo(b),c.disabled&&_f(a,b[0],!0),b[0].submenu&&$('<div class="menu-rightarrow"></div>').appendTo(b),_10(a,b)}}),$('<div class="menu-line"></div>').prependTo(b)),_11(a,b),b.hide(),_12(a,b)}$(a).appendTo("body"),$(a).addClass("menu-top"),$(document).unbind(".menu").bind("mousedown.menu",function(a){var b=$("body>div.menu:visible"),c=$(a.target).closest("div.menu",b);c.length||$("body>div.menu-top:visible").menu("hide")});for(var d=b($(a)),e=0;e<d.length;e++)c(d[e])}function _11(a,b){var c=$.data(a,"menu").options,d=b.attr("style");b.css({display:"block",left:-1e4,height:"auto",overflow:"hidden"});var e=0;b.find("div.menu-text").each(function(){e<$(this)._outerWidth()&&(e=$(this)._outerWidth()),$(this).closest("div.menu-item")._outerHeight($(this)._outerHeight()+2)}),e+=65,b._outerWidth(Math.max(b[0].originalWidth||0,e,c.minWidth)),b.children("div.menu-line")._outerHeight(b.outerHeight()),b.attr("style",d)}function _12(a,b){var c=$.data(a,"menu");b.unbind(".menu").bind("mouseenter.menu",function(){c.timer&&(clearTimeout(c.timer),c.timer=null)}).bind("mouseleave.menu",function(){c.options.hideOnUnhover&&(c.timer=setTimeout(function(){_1b(a)},100))})}function _10(a,b){b.hasClass("menu-item")&&(b.unbind(".menu"),b.bind("click.menu",function(){if(!$(this).hasClass("menu-item-disabled")){if(!this.submenu){_1b(a);var b=$(this).attr("href");b&&(location.href=b)}var c=$(a).menu("getItem",this);$.data(a,"menu").options.onClick.call(a,c)}}).bind("mouseenter.menu",function(){if(b.siblings().each(function(){this.submenu&&_22(this.submenu),$(this).removeClass("menu-active")}),b.addClass("menu-active"),$(this).hasClass("menu-item-disabled"))return void b.addClass("menu-active-disabled");var c=b[0].submenu;c&&$(a).menu("show",{menu:c,parent:b})}).bind("mouseleave.menu",function(a){b.removeClass("menu-active menu-active-disabled");var c=b[0].submenu;c?a.pageX>=parseInt(c.css("left"))?b.addClass("menu-active"):_22(c):b.removeClass("menu-active")}))}function _1b(a){var b=$.data(a,"menu");return b&&$(a).is(":visible")&&(_22($(a)),b.options.onHide.call(a)),!1}function _25(a,b){var c,d;b=b||{};var e=$(b.menu||a);if(e.hasClass("menu-top")){var f=$.data(a,"menu").options;if($.extend(f,b),c=f.left,d=f.top,f.alignTo){var g=$(f.alignTo);c=g.offset().left,d=g.offset().top+g._outerHeight()}c+e.outerWidth()>$(window)._outerWidth()+$(document)._scrollLeft()&&(c=$(window)._outerWidth()+$(document).scrollLeft()-e.outerWidth()-5),d+e.outerHeight()>$(window)._outerHeight()+$(document).scrollTop()&&(d=$(window)._outerHeight()+$(document).scrollTop()-e.outerHeight()-5)}else{var h=b.parent;c=h.offset().left+h.outerWidth()-2,c+e.outerWidth()+5>$(window)._outerWidth()+$(document).scrollLeft()&&(c=h.offset().left-e.outerWidth()+2);var d=h.offset().top-3;d+e.outerHeight()>$(window)._outerHeight()+$(document).scrollTop()&&(d=$(window)._outerHeight()+$(document).scrollTop()-e.outerHeight()-5)}e.css({left:c,top:d}),e.show(0,function(){e[0].shadow||(e[0].shadow=$('<div class="menu-shadow"></div>').insertAfter(e)),e[0].shadow.css({display:"block",zIndex:$.fn.menu.defaults.zIndex++,left:e.css("left"),top:e.css("top"),width:e.outerWidth(),height:e.outerHeight()}),e.css("z-index",$.fn.menu.defaults.zIndex++),e.hasClass("menu-top")&&$.data(e[0],"menu").options.onShow.call(e[0])})}function _22(a){function b(a){a.stop(!0,!0),a[0].shadow&&a[0].shadow.hide(),a.hide()}a&&(b(a),a.find("div.menu-item").each(function(){this.submenu&&_22(this.submenu),$(this).removeClass("menu-active")}))}function _2e(a,b){function c(f){f.children("div.menu-item").each(function(){var f=$(a).menu("getItem",this),g=e.empty().html(f.text).text();b==$.trim(g)?d=f:this.submenu&&!d&&c(this.submenu)})}var d=null,e=$("<div></div>");return c($(a)),e.remove(),d}function _f(a,b,c){var d=$(b);d.hasClass("menu-item")&&(c?(d.addClass("menu-item-disabled"),b.onclick&&(b.onclick1=b.onclick,b.onclick=null)):(d.removeClass("menu-item-disabled"),b.onclick1&&(b.onclick=b.onclick1,b.onclick1=null)))}function _38(_39,_3a){var _3b=$(_39);if(_3a.parent){if(!_3a.parent.submenu){var _3c=$('<div class="menu"><div class="menu-line"></div></div>').appendTo("body");_3c.hide(),_3a.parent.submenu=_3c,$('<div class="menu-rightarrow"></div>').appendTo(_3a.parent)}_3b=_3a.parent.submenu}if(_3a.separator)var _3d=$('<div class="menu-sep"></div>').appendTo(_3b);else{var _3d=$('<div class="menu-item"></div>').appendTo(_3b);$('<div class="menu-text"></div>').html(_3a.text).appendTo(_3d)}_3a.iconCls&&$('<div class="menu-icon"></div>').addClass(_3a.iconCls).appendTo(_3d),_3a.id&&_3d.attr("id",_3a.id),_3a.name&&(_3d[0].itemName=_3a.name),_3a.href&&(_3d[0].itemHref=_3a.href),_3a.onclick&&("string"==typeof _3a.onclick?_3d.attr("onclick",_3a.onclick):_3d[0].onclick=eval(_3a.onclick)),_3a.handler&&(_3d[0].onclick=eval(_3a.handler)),_3a.disabled&&_f(_39,_3d[0],!0),_10(_39,_3d),_12(_39,_3b),_11(_39,_3b)}function _3e(a,b){function c(a){if(a.submenu){a.submenu.children("div.menu-item").each(function(){c(this)});var b=a.submenu[0].shadow;b&&b.remove(),a.submenu.remove()}$(a).remove()}c(b)}function _43(a){$(a).children("div.menu-item").each(function(){_3e(a,this)}),a.shadow&&a.shadow.remove(),$(a).remove()}$.fn.menu=function(a,b){return"string"==typeof a?$.fn.menu.methods[a](this,b):(a=a||{},this.each(function(){var b=$.data(this,"menu");b?$.extend(b.options,a):(b=$.data(this,"menu",{options:$.extend({},$.fn.menu.defaults,$.fn.menu.parseOptions(this),a)}),_1(this)),$(this).css({left:b.options.left,top:b.options.top})}))},$.fn.menu.methods={options:function(a){return $.data(a[0],"menu").options},show:function(a,b){return a.each(function(){_25(this,b)})},hide:function(a){return a.each(function(){_1b(this)})},destroy:function(a){return a.each(function(){_43(this)})},setText:function(a,b){return a.each(function(){$(b.target).children("div.menu-text").html(b.text)})},setIcon:function(a,b){return a.each(function(){var a=$(this).menu("getItem",b.target);a.iconCls?$(a.target).children("div.menu-icon").removeClass(a.iconCls).addClass(b.iconCls):$('<div class="menu-icon"></div>').addClass(b.iconCls).appendTo(b.target)})},getItem:function(a,b){var c=$(b),d={target:b,id:c.attr("id"),text:$.trim(c.children("div.menu-text").html()),disabled:c.hasClass("menu-item-disabled"),name:b.itemName,href:b.itemHref,onclick:b.onclick},e=c.children("div.menu-icon");if(e.length){for(var f=[],g=e.attr("class").split(" "),h=0;h<g.length;h++)"menu-icon"!=g[h]&&f.push(g[h]);d.iconCls=f.join(" ")}return d},findItem:function(a,b){return _2e(a[0],b)},appendItem:function(a,b){return a.each(function(){_38(this,b)})},removeItem:function(a,b){return a.each(function(){_3e(this,b)})},enableItem:function(a,b){return a.each(function(){_f(this,b,!1)})},disableItem:function(a,b){return a.each(function(){_f(this,b,!0)})}},$.fn.menu.parseOptions=function(a){return $.extend({},$.parser.parseOptions(a,["left","top",{minWidth:"number",hideOnUnhover:"boolean"}]))},$.fn.menu.defaults={zIndex:11e4,left:0,top:0,minWidth:120,hideOnUnhover:!0,onShow:function(){},onHide:function(){},onClick:function(){}}}(jQuery);