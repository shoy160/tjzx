/*! tjzx.ued version:0.1.0 2014-05-13 09:00:00 */
!function(a){function b(b){function c(c,d){f.remainText=!1,e(),g.multiple||a(b).combo("hidePanel"),g.onClickRow.call(this,c,d)}function e(){for(var c=h.datagrid("getSelections"),d=[],e=[],i=0;i<c.length;i++)d.push(c[i][g.idField]),e.push(c[i][g.textField]);g.multiple?a(b).combo("setValues",d):a(b).combo("setValues",d.length?d:[""]),f.remainText||a(b).combo("setText",e.join(g.separator))}var f=a.data(b,"combogrid"),g=f.options,h=f.grid;a(b).addClass("combogrid-f").combo(g);var i=a(b).combo("panel");h||(h=a("<table></table>").appendTo(i),f.grid=h),h.datagrid(a.extend({},g,{border:!1,fit:!0,singleSelect:!g.multiple,onLoadSuccess:function(){var c=a(b).combo("getValues"),e=g.onSelect;g.onSelect=function(){},d(b,c,f.remainText),g.onSelect=e,g.onLoadSuccess.apply(b,arguments)},onClickRow:c,onSelect:function(a,b){e(),g.onSelect.call(this,a,b)},onUnselect:function(a,b){e(),g.onUnselect.call(this,a,b)},onSelectAll:function(a){e(),g.onSelectAll.call(this,a)},onUnselectAll:function(a){g.multiple&&e(),g.onUnselectAll.call(this,a)}}))}function c(b,c){var d=a.data(b,"combogrid"),e=d.options,f=d.grid,g=f.datagrid("getRows").length;if(g){var h=e.finder.getTr(f[0],null,"highlight");h.length||(h=e.finder.getTr(f[0],null,"selected"));var i;if(h.length){var i=parseInt(h.attr("datagrid-row-index"));i+="next"==c?1:-1,0>i&&(i=g-1),i>=g&&(i=0)}else i="next"==c?0:g-1;f.datagrid("highlightRow",i),e.selectOnNavigation&&(d.remainText=!1,f.datagrid("selectRow",i))}}function d(b,c,d){var e=a.data(b,"combogrid"),f=e.options,g=e.grid,h=g.datagrid("getRows"),i=[],j=a(b).combo("getValues"),k=a(b).combo("options"),l=k.onChange;k.onChange=function(){},g.datagrid("clearSelections");for(var m=0;m<c.length;m++){var n=g.datagrid("getRowIndex",c[m]);n>=0?(g.datagrid("selectRow",n),i.push(h[n][f.textField])):i.push(c[m])}if(a(b).combo("setValues",j),k.onChange=l,a(b).combo("setValues",c),!d){var o=i.join(f.separator);a(b).combo("getText")!=o&&a(b).combo("setText",o)}}function e(b,c){var e=a.data(b,"combogrid"),f=e.options,g=e.grid;if(e.remainText=!0,f.multiple&&!c?d(b,[],!0):d(b,[c],!0),"remote"==f.mode)g.datagrid("clearSelections"),g.datagrid("load",a.extend({},f.queryParams,{q:c}));else{if(!c)return;for(var h=g.datagrid("getRows"),i=0;i<h.length;i++)if(f.filter.call(b,c,h[i]))return g.datagrid("clearSelections"),void g.datagrid("selectRow",i)}}function f(b){var c=a.data(b,"combogrid"),d=c.options,e=c.grid,f=d.finder.getTr(e[0],null,"highlight");if(f.length||(f=d.finder.getTr(e[0],null,"selected")),f.length){c.remainText=!1;var g=parseInt(f.attr("datagrid-row-index"));d.multiple?f.hasClass("datagrid-row-selected")?e.datagrid("unselectRow",g):e.datagrid("selectRow",g):(e.datagrid("selectRow",g),a(b).combogrid("hidePanel"))}}a.fn.combogrid=function(c,d){if("string"==typeof c){var e=a.fn.combogrid.methods[c];return e?e(this,d):this.combo(c,d)}return c=c||{},this.each(function(){var d=a.data(this,"combogrid");d?a.extend(d.options,c):d=a.data(this,"combogrid",{options:a.extend({},a.fn.combogrid.defaults,a.fn.combogrid.parseOptions(this),c)}),b(this)})},a.fn.combogrid.methods={options:function(b){var c=b.combo("options");return a.extend(a.data(b[0],"combogrid").options,{originalValue:c.originalValue,disabled:c.disabled,readonly:c.readonly})},grid:function(b){return a.data(b[0],"combogrid").grid},setValues:function(a,b){return a.each(function(){d(this,b)})},setValue:function(a,b){return a.each(function(){d(this,[b])})},clear:function(b){return b.each(function(){a(this).combogrid("grid").datagrid("clearSelections"),a(this).combo("clear")})},reset:function(b){return b.each(function(){var b=a(this).combogrid("options");b.multiple?a(this).combogrid("setValues",b.originalValue):a(this).combogrid("setValue",b.originalValue)})}},a.fn.combogrid.parseOptions=function(b){a(b);return a.extend({},a.fn.combo.parseOptions(b),a.fn.datagrid.parseOptions(b),a.parser.parseOptions(b,["idField","textField","mode"]))},a.fn.combogrid.defaults=a.extend({},a.fn.combo.defaults,a.fn.datagrid.defaults,{loadMsg:null,idField:null,textField:null,mode:"local",keyHandler:{up:function(a){c(this,"prev"),a.preventDefault()},down:function(a){c(this,"next"),a.preventDefault()},left:function(){},right:function(){},enter:function(){f(this)},query:function(a){e(this,a)}},filter:function(b,c){var d=a(this).combogrid("options");return 0==c[d.textField].indexOf(b)}})}(jQuery);