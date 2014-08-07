/*! tjzx.ued version:0.1.0 2014-05-13 09:00:00 */
!function(a){a.fn.resizable=function(b,c){function d(b){var c=b.data,d=a.data(c.target,"resizable").options;if(-1!=c.dir.indexOf("e")){var e=c.startWidth+b.pageX-c.startX;e=Math.min(Math.max(e,d.minWidth),d.maxWidth),c.width=e}if(-1!=c.dir.indexOf("s")){var f=c.startHeight+b.pageY-c.startY;f=Math.min(Math.max(f,d.minHeight),d.maxHeight),c.height=f}if(-1!=c.dir.indexOf("w")){var e=c.startWidth-b.pageX+c.startX;e=Math.min(Math.max(e,d.minWidth),d.maxWidth),c.width=e,c.left=c.startLeft+c.startWidth-c.width}if(-1!=c.dir.indexOf("n")){var f=c.startHeight-b.pageY+c.startY;f=Math.min(Math.max(f,d.minHeight),d.maxHeight),c.height=f,c.top=c.startTop+c.startHeight-c.height}}function e(b){var c=b.data,d=a(c.target);d.css({left:c.left,top:c.top}),d.outerWidth()!=c.width&&d._outerWidth(c.width),d.outerHeight()!=c.height&&d._outerHeight(c.height)}function f(b){return a.fn.resizable.isResizing=!0,a.data(b.data.target,"resizable").options.onStartResize.call(b.data.target,b),!1}function g(b){return d(b),0!=a.data(b.data.target,"resizable").options.onResize.call(b.data.target,b)&&e(b),!1}function h(b){return a.fn.resizable.isResizing=!1,d(b,!0),e(b),a.data(b.data.target,"resizable").options.onStopResize.call(b.data.target,b),a(document).unbind(".resizable"),a("body").css("cursor",""),!1}return"string"==typeof b?a.fn.resizable.methods[b](this,c):this.each(function(){function c(b){var c=a(b.data.target),e="",f=c.offset(),g=c.outerWidth(),h=c.outerHeight(),i=d.edge;b.pageY>f.top&&b.pageY<f.top+i?e+="n":b.pageY<f.top+h&&b.pageY>f.top+h-i&&(e+="s"),b.pageX>f.left&&b.pageX<f.left+i?e+="w":b.pageX<f.left+g&&b.pageX>f.left+g-i&&(e+="e");for(var j=d.handles.split(","),k=0;k<j.length;k++){var l=j[k].replace(/(^\s*)|(\s*$)/g,"");if("all"==l||l==e)return e}return""}var d=null,e=a.data(this,"resizable");e?(a(this).unbind(".resizable"),d=a.extend(e.options,b||{})):(d=a.extend({},a.fn.resizable.defaults,a.fn.resizable.parseOptions(this),b||{}),a.data(this,"resizable",{options:d})),1!=d.disabled&&a(this).bind("mousemove.resizable",{target:this},function(b){if(!a.fn.resizable.isResizing){var d=c(b);""==d?a(b.data.target).css("cursor",""):a(b.data.target).css("cursor",d+"-resize")}}).bind("mouseleave.resizable",{target:this},function(b){a(b.data.target).css("cursor","")}).bind("mousedown.resizable",{target:this},function(b){function d(c){var d=parseInt(a(b.data.target).css(c));return isNaN(d)?0:d}var e=c(b);if(""!=e){var i={target:b.data.target,dir:e,startLeft:d("left"),startTop:d("top"),left:d("left"),top:d("top"),startX:b.pageX,startY:b.pageY,startWidth:a(b.data.target).outerWidth(),startHeight:a(b.data.target).outerHeight(),width:a(b.data.target).outerWidth(),height:a(b.data.target).outerHeight(),deltaWidth:a(b.data.target).outerWidth()-a(b.data.target).width(),deltaHeight:a(b.data.target).outerHeight()-a(b.data.target).height()};a(document).bind("mousedown.resizable",i,f),a(document).bind("mousemove.resizable",i,g),a(document).bind("mouseup.resizable",i,h),a("body").css("cursor",e+"-resize")}})})},a.fn.resizable.methods={options:function(b){return a.data(b[0],"resizable").options},enable:function(b){return b.each(function(){a(this).resizable({disabled:!1})})},disable:function(b){return b.each(function(){a(this).resizable({disabled:!0})})}},a.fn.resizable.parseOptions=function(b){var c=a(b);return a.extend({},a.parser.parseOptions(b,["handles",{minWidth:"number",minHeight:"number",maxWidth:"number",maxHeight:"number",edge:"number"}]),{disabled:c.attr("disabled")?!0:void 0})},a.fn.resizable.defaults={disabled:!1,handles:"n, e, s, w, ne, se, sw, nw, all",minWidth:10,minHeight:10,maxWidth:1e4,maxHeight:1e4,edge:5,onStartResize:function(){},onResize:function(){},onStopResize:function(){}},a.fn.resizable.isResizing=!1}(jQuery);