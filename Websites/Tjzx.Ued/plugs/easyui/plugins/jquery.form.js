/*! tjzx.ued version:0.1.0 2014-04-02 15:42:53 */
!function(a){function b(b,c){function d(){var b=a("#"+h);if(b.length)try{var c=b.contents()[0].readyState;c&&"uninitialized"==c.toLowerCase()&&setTimeout(d,100)}catch(f){e()}}function e(){var b=a("#"+h);if(b.length){b.unbind();var d="";try{var f=b.contents().find("body");if(d=f.html(),""==d&&--o)return void setTimeout(e,100);var g=f.find(">textarea");if(g.length)d=g.val();else{var i=f.find(">pre");i.length&&(d=i.html())}}catch(j){}c.success&&c.success(d),setTimeout(function(){b.unbind(),b.remove()},100)}}c=c||{};var f={};if(!c.onSubmit||0!=c.onSubmit.call(b,f)){var g=a(b);c.url&&g.attr("action",c.url);var h="easyui_frame_"+(new Date).getTime(),i=a("<iframe id="+h+" name="+h+"></iframe>").attr("src",window.ActiveXObject?"javascript:false":"about:blank").css({position:"absolute",top:-1e3,left:-1e3}),j=g.attr("target"),k=g.attr("action");g.attr("target",h);var l=a();try{i.appendTo("body"),i.bind("load",e);for(var m in f){var n=a('<input type="hidden" name="'+m+'">').val(f[m]).appendTo(g);l=l.add(n)}d(),g[0].submit()}finally{g.attr("action",k),j?g.attr("target",j):g.removeAttr("target"),l.remove()}var o=10}}function c(b,c){function d(c){var d=a(b);for(var j in c){var k=c[j],l=e(j,k);if(!l.length){var m=f(j,k);m||(a('input[name="'+j+'"]',d).val(k),a('textarea[name="'+j+'"]',d).val(k),a('select[name="'+j+'"]',d).val(k))}h(j,k)}i.onLoadSuccess.call(b,c),g(b)}function e(c,d){var e=a(b).find('input[name="'+c+'"][type=radio], input[name="'+c+'"][type=checkbox]');return e._propAttr("checked",!1),e.each(function(){var b=a(this);(b.val()==String(d)||a.inArray(b.val(),a.isArray(d)?d:[d])>=0)&&b._propAttr("checked",!0)}),e}function f(c,d){for(var e=0,f=["numberbox","slider"],g=0;g<f.length;g++){var h=f[g],i=a(b).find("input["+h+'Name="'+c+'"]');i.length&&(i[h]("setValue",d),e+=i.length)}return e}function h(c,d){var e=a(b),f=["combobox","combotree","combogrid","datetimebox","datebox","combo"],g=e.find('[comboName="'+c+'"]');if(g.length)for(var h=0;h<f.length;h++){var i=f[h];if(g.hasClass(i+"-f"))return void(g[i]("options").multiple?g[i]("setValues",d):g[i]("setValue",d))}}a.data(b,"form")||a.data(b,"form",{options:a.extend({},a.fn.form.defaults)});var i=a.data(b,"form").options;if("string"==typeof c){var j={};if(0==i.onBeforeLoad.call(b,j))return;a.ajax({url:c,data:j,dataType:"json",success:function(a){d(a)},error:function(){i.onLoadError.apply(b,arguments)}})}else d(c)}function d(b){a("input,select,textarea",b).each(function(){var b=this.type,c=this.tagName.toLowerCase();if("text"==b||"hidden"==b||"password"==b||"textarea"==c)this.value="";else if("file"==b){var d=a(this);d.after(d.clone().val("")),d.remove()}else"checkbox"==b||"radio"==b?this.checked=!1:"select"==c&&(this.selectedIndex=-1)});for(var c=a(b),d=["combo","combobox","combotree","combogrid","slider"],e=0;e<d.length;e++){var f=d[e],h=c.find("."+f+"-f");h.length&&h[f]&&h[f]("clear")}g(b)}function e(b){b.reset();for(var c=a(b),d=["combo","combobox","combotree","combogrid","datebox","datetimebox","spinner","timespinner","numberbox","numberspinner","slider"],e=0;e<d.length;e++){var f=d[e],h=c.find("."+f+"-f");h.length&&h[f]&&h[f]("reset")}g(b)}function f(c){var d=a.data(c,"form").options,e=a(c);e.unbind(".form").bind("submit.form",function(){return setTimeout(function(){b(c,d)},0),!1})}function g(b){if(a.fn.validatebox){var c=a(b);c.find(".validatebox-text:not(:disabled)").validatebox("validate");var d=c.find(".validatebox-invalid");return d.filter(":not(:disabled):first").focus(),0==d.length}return!0}function h(b,c){a(b).find(".validatebox-text:not(:disabled)").validatebox(c?"disableValidation":"enableValidation")}a.fn.form=function(b,c){return"string"==typeof b?a.fn.form.methods[b](this,c):(b=b||{},this.each(function(){a.data(this,"form")||a.data(this,"form",{options:a.extend({},a.fn.form.defaults,b)}),f(this)}))},a.fn.form.methods={submit:function(c,d){return c.each(function(){b(this,a.extend({},a.fn.form.defaults,d||{}))})},load:function(a,b){return a.each(function(){c(this,b)})},clear:function(a){return a.each(function(){d(this)})},reset:function(a){return a.each(function(){e(this)})},validate:function(a){return g(a[0])},disableValidation:function(a){return a.each(function(){h(this,!0)})},enableValidation:function(a){return a.each(function(){h(this,!1)})}},a.fn.form.defaults={url:null,onSubmit:function(){return a(this).form("validate")},success:function(){},onBeforeLoad:function(){},onLoadSuccess:function(){},onLoadError:function(){}}}(jQuery);