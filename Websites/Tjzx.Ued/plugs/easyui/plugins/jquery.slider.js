/*! tjzx.ued version:0.1.0 2014-04-25 14:28:37 */
!function($){function _1(a){var b=$('<div class="slider"><div class="slider-inner"><a href="javascript:void(0)" class="slider-handle"></a><span class="slider-tip"></span></div><div class="slider-rule"></div><div class="slider-rulelabel"></div><div style="clear:both"></div><input type="hidden" class="slider-value"></div>').insertAfter(a),c=$(a);c.addClass("slider-f").hide();var d=c.attr("name");return d&&(b.find("input.slider-value").attr("name",d),c.removeAttr("name").attr("sliderName",d)),b}function _5(a,b){var c=$.data(a,"slider"),d=c.options,e=c.slider;b&&(b.width&&(d.width=b.width),b.height&&(d.height=b.height)),"h"==d.mode?(e.css("height",""),e.children("div").css("height",""),isNaN(d.width)||e.width(d.width)):(e.css("width",""),e.children("div").css("width",""),isNaN(d.height)||(e.height(d.height),e.find("div.slider-rule").height(d.height),e.find("div.slider-rulelabel").height(d.height),e.find("div.slider-inner")._outerHeight(d.height))),_b(a)}function _c(a){function b(a){var b=e.find("div.slider-rule"),c=e.find("div.slider-rulelabel");b.empty(),c.empty();for(var f=0;f<a.length;f++){var g=100*f/(a.length-1)+"%",h=$("<span></span>").appendTo(b);h.css("h"==d.mode?"left":"top",g),"|"!=a[f]&&(h=$("<span></span>").appendTo(c),h.html(a[f]),h.css("h"==d.mode?{left:g,marginLeft:-Math.round(h.outerWidth()/2)}:{top:g,marginTop:-Math.round(h.outerHeight()/2)}))}}var c=$.data(a,"slider"),d=c.options,e=c.slider,f="h"==d.mode?d.rule:d.rule.slice(0).reverse();d.reversed&&(f=f.slice(0).reverse()),b(f)}function _16(a){function b(b){var c=Math.abs(b%d.step);c<d.step/2?b-=c:b=b-c+d.step,_22(a,b)}var c=$.data(a,"slider"),d=c.options,e=c.slider;e.removeClass("slider-h slider-v slider-disabled"),e.addClass("h"==d.mode?"slider-h":"slider-v"),e.addClass(d.disabled?"slider-disabled":""),e.find("a.slider-handle").draggable({axis:d.mode,cursor:"pointer",disabled:d.disabled,onDrag:function(c){var f=c.data.left,g=e.width();if("h"!=d.mode&&(f=c.data.top,g=e.height()),0>f||f>g)return!1;var h=_32(a,f);return b(h),!1},onBeforeDrag:function(){c.isDragging=!0},onStartDrag:function(){d.onSlideStart.call(a,d.value)},onStopDrag:function(e){var f=_32(a,"h"==d.mode?e.data.left:e.data.top);b(f),d.onSlideEnd.call(a,d.value),d.onComplete.call(a,d.value),c.isDragging=!1}}),e.find("div.slider-inner").unbind(".slider").bind("mousedown.slider",function(e){if(!c.isDragging){var f=$(this).offset(),g=_32(a,"h"==d.mode?e.pageX-f.left:e.pageY-f.top);b(g),d.onComplete.call(a,d.value)}})}function _22(a,b){var c=$.data(a,"slider"),d=c.options,e=c.slider,f=d.value;b<d.min&&(b=d.min),b>d.max&&(b=d.max),d.value=b,$(a).val(b),e.find("input.slider-value").val(b);var g=_29(a,b),h=e.find(".slider-tip");if(d.showTip?(h.show(),h.html(d.tipFormatter.call(a,d.value))):h.hide(),"h"==d.mode){var i="left:"+g+"px;";e.find(".slider-handle").attr("style",i),h.attr("style",i+"margin-left:"+-Math.round(h.outerWidth()/2)+"px")}else{var i="top:"+g+"px;";e.find(".slider-handle").attr("style",i),h.attr("style",i+"margin-left:"+-Math.round(h.outerWidth())+"px")}f!=b&&d.onChange.call(a,b,f)}function _b(a){var b=$.data(a,"slider").options,c=b.onChange;b.onChange=function(){},_22(a,b.value),b.onChange=c}function _29(a,b){var c=$.data(a,"slider"),d=c.options,e=c.slider;if("h"==d.mode){var f=(b-d.min)/(d.max-d.min)*e.width();d.reversed&&(f=e.width()-f)}else{var f=e.height()-(b-d.min)/(d.max-d.min)*e.height();d.reversed&&(f=e.height()-f)}return f.toFixed(0)}function _32(a,b){var c=$.data(a,"slider"),d=c.options,e=c.slider;if("h"==d.mode)var f=d.min+(d.max-d.min)*(b/e.width());else var f=d.min+(d.max-d.min)*((e.height()-b)/e.height());return d.reversed?d.max-f.toFixed(0):f.toFixed(0)}$.fn.slider=function(a,b){return"string"==typeof a?$.fn.slider.methods[a](this,b):(a=a||{},this.each(function(){var b=$.data(this,"slider");b?$.extend(b.options,a):(b=$.data(this,"slider",{options:$.extend({},$.fn.slider.defaults,$.fn.slider.parseOptions(this),a),slider:_1(this)}),$(this).removeAttr("disabled"));var c=b.options;c.min=parseFloat(c.min),c.max=parseFloat(c.max),c.value=parseFloat(c.value),c.step=parseFloat(c.step),c.originalValue=c.value,_16(this),_c(this),_5(this)}))},$.fn.slider.methods={options:function(a){return $.data(a[0],"slider").options},destroy:function(a){return a.each(function(){$.data(this,"slider").slider.remove(),$(this).remove()})},resize:function(a,b){return a.each(function(){_5(this,b)})},getValue:function(a){return a.slider("options").value},setValue:function(a,b){return a.each(function(){_22(this,b)})},clear:function(a){return a.each(function(){var a=$(this).slider("options");_22(this,a.min)})},reset:function(a){return a.each(function(){var a=$(this).slider("options");_22(this,a.originalValue)})},enable:function(a){return a.each(function(){$.data(this,"slider").options.disabled=!1,_16(this)})},disable:function(a){return a.each(function(){$.data(this,"slider").options.disabled=!0,_16(this)})}},$.fn.slider.parseOptions=function(_40){var t=$(_40);return $.extend({},$.parser.parseOptions(_40,["width","height","mode",{reversed:"boolean",showTip:"boolean",min:"number",max:"number",step:"number"}]),{value:t.val()||void 0,disabled:t.attr("disabled")?!0:void 0,rule:t.attr("rule")?eval(t.attr("rule")):void 0})},$.fn.slider.defaults={width:"auto",height:"auto",mode:"h",reversed:!1,showTip:!1,disabled:!1,value:0,min:0,max:100,step:1,rule:[],tipFormatter:function(a){return a},onChange:function(){},onSlideStart:function(){},onSlideEnd:function(){},onComplete:function(){}}}(jQuery);