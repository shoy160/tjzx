/*! tjzx.ued version:0.1.0 2014-05-10 09:49:49 */
!function(a){function b(b){var d=a.data(b,"treegrid"),e=d.options;if(a(b).datagrid(a.extend({},e,{url:null,data:null,loader:function(){return!1},onBeforeLoad:function(){return!1},onLoadSuccess:function(){},onResizeColumn:function(a,d){c(b),e.onResizeColumn.call(b,a,d)},onSortColumn:function(c,d){if(e.sortName=c,e.sortOrder=d,e.remoteSort)h(b);else{var f=a(b).treegrid("getData");g(b,0,f)}e.onSortColumn.call(b,c,d)},onBeforeEdit:function(a,c){return 0==e.onBeforeEdit.call(b,c)?!1:void 0},onAfterEdit:function(a,c,d){e.onAfterEdit.call(b,c,d)},onCancelEdit:function(a,c){e.onCancelEdit.call(b,c)},onSelect:function(a){e.onSelect.call(b,p(b,a))},onUnselect:function(a){e.onUnselect.call(b,p(b,a))},onSelectAll:function(){e.onSelectAll.call(b,a.data(b,"treegrid").data)},onUnselectAll:function(){e.onUnselectAll.call(b,a.data(b,"treegrid").data)},onCheck:function(a){e.onCheck.call(b,p(b,a))},onUncheck:function(a){e.onUncheck.call(b,p(b,a))},onCheckAll:function(){e.onCheckAll.call(b,a.data(b,"treegrid").data)},onUncheckAll:function(){e.onUncheckAll.call(b,a.data(b,"treegrid").data)},onClickRow:function(a){e.onClickRow.call(b,p(b,a))},onDblClickRow:function(a){e.onDblClickRow.call(b,p(b,a))},onClickCell:function(a,c){e.onClickCell.call(b,c,p(b,a))},onDblClickCell:function(a,c){e.onDblClickCell.call(b,c,p(b,a))},onRowContextMenu:function(a,c){e.onContextMenu.call(b,a,p(b,c))}})),!e.columns){var f=a.data(b,"datagrid").options;e.columns=f.columns,e.frozenColumns=f.frozenColumns}if(d.dc=a.data(b,"datagrid").dc,e.pagination){var i=a(b).datagrid("getPager");i.pagination({pageNumber:e.pageNumber,pageSize:e.pageSize,pageList:e.pageList,onSelectPage:function(a,c){e.pageNumber=a,e.pageSize=c,h(b)}}),e.pageSize=i.pagination("options").pageSize}}function c(b,c){function d(a){var c=e.finder.getTr(b,a,"body",1),d=e.finder.getTr(b,a,"body",2);c.css("height",""),d.css("height","");var f=Math.max(c.height(),d.height());c.css("height",f),d.css("height",f)}var e=a.data(b,"datagrid").options,f=a.data(b,"datagrid").dc;if(!f.body1.is(":empty")&&(!e.nowrap||e.autoRowHeight)&&void 0!=c)for(var g=l(b,c),h=0;h<g.length;h++)d(g[h][e.idField]);a(b).datagrid("fixRowHeight",c)}function d(b){var c=a.data(b,"datagrid").dc,d=a.data(b,"treegrid").options;d.rownumbers&&c.body1.find("div.datagrid-cell-rownumber").each(function(b){a(this).html(b+1)})}function e(b){var c=a.data(b,"datagrid").dc,d=c.body1.add(c.body2),e=(a.data(d[0],"events")||a._data(d[0],"events")).click[0].handler;c.body1.add(c.body2).bind("mouseover",function(b){var c=a(b.target),d=c.closest("tr.datagrid-row");d.length&&(c.hasClass("tree-hit")&&c.addClass(c.hasClass("tree-expanded")?"tree-expanded-hover":"tree-collapsed-hover"),b.stopPropagation())}).bind("mouseout",function(b){var c=a(b.target),d=c.closest("tr.datagrid-row");d.length&&(c.hasClass("tree-hit")&&c.removeClass(c.hasClass("tree-expanded")?"tree-expanded-hover":"tree-collapsed-hover"),b.stopPropagation())}).unbind("click").bind("click",function(c){var d=a(c.target),f=d.closest("tr.datagrid-row");f.length&&(d.hasClass("tree-hit")?s(b,f.attr("node-id")):e(c),c.stopPropagation())})}function f(b,c){function d(b,c){a('<tr class="treegrid-tr-tree"><td style="border:0px" colspan="'+c+'"><div></div></td></tr>').insertAfter(b)}var e=a.data(b,"treegrid").options,f=e.finder.getTr(b,c,"body",1),g=e.finder.getTr(b,c,"body",2),h=a(b).datagrid("getColumnFields",!0).length+(e.rownumbers?1:0),i=a(b).datagrid("getColumnFields",!1).length;d(f,h),d(g,i)}function g(b,e,f,g){var h=a.data(b,"treegrid"),i=h.options,j=h.dc;f=i.loadFilter.call(b,f,e);var k=p(b,e);if(k){var l=i.finder.getTr(b,e,"body",1),m=i.finder.getTr(b,e,"body",2),n=l.next("tr.treegrid-tr-tree").children("td").children("div"),o=m.next("tr.treegrid-tr-tree").children("td").children("div");g||(k.children=[])}else{var n=j.body1,o=j.body2;g||(h.data=[])}if(g||(n.empty(),o.empty()),i.view.onBeforeRender&&i.view.onBeforeRender.call(i.view,b,e,f),i.view.render.call(i.view,b,n,!0),i.view.render.call(i.view,b,o,!1),i.showFooter&&(i.view.renderFooter.call(i.view,b,j.footer1,!0),i.view.renderFooter.call(i.view,b,j.footer2,!1)),i.view.onAfterRender&&i.view.onAfterRender.call(i.view,b),i.onLoadSuccess.call(b,k,f),!e&&i.pagination){var q=a.data(b,"treegrid").total,r=a(b).datagrid("getPager");r.pagination("options").total!=q&&r.pagination({total:q})}c(b),d(b),a(b).treegrid("autoSizeColumn")}function h(b,c,d,e,f){var h=a.data(b,"treegrid").options,i=a(b).datagrid("getPanel").find("div.datagrid-body");d&&(h.queryParams=d);var j=a.extend({},h.queryParams);h.pagination&&a.extend(j,{page:h.pageNumber,rows:h.pageSize}),h.sortName&&a.extend(j,{sort:h.sortName,order:h.sortOrder});var k=p(b,c);if(0!=h.onBeforeLoad.call(b,k,j)){var l=i.find('tr[node-id="'+c+'"] span.tree-folder');l.addClass("tree-loading"),a(b).treegrid("loading");var m=h.loader.call(b,j,function(d){l.removeClass("tree-loading"),a(b).treegrid("loaded"),g(b,c,d,e),f&&f()},function(){l.removeClass("tree-loading"),a(b).treegrid("loaded"),h.onLoadError.apply(b,arguments),f&&f()});0==m&&(l.removeClass("tree-loading"),a(b).treegrid("loaded"))}}function i(a){var b=j(a);return b.length?b[0]:null}function j(b){return a.data(b,"treegrid").data}function k(a,b){var c=p(a,b);return c._parentId?p(a,c._parentId):null}function l(b,c){function d(a){var c=p(b,a);if(c&&c.children)for(var g=0,h=c.children.length;h>g;g++){var i=c.children[g];f.push(i),d(i[e.idField])}}var e=a.data(b,"treegrid").options,f=(a(b).datagrid("getPanel").find("div.datagrid-view2 div.datagrid-body"),[]);if(c)d(c);else for(var g=j(b),h=0;h<g.length;h++)f.push(g[h]),d(g[h][e.idField]);return f}function m(a){var b=n(a);return b.length?b[0]:null}function n(b){var c=[],d=a(b).datagrid("getPanel");return d.find("div.datagrid-view2 div.datagrid-body tr.datagrid-row-selected").each(function(){var d=a(this).attr("node-id");c.push(p(b,d))}),c}function o(b,c){if(!c)return 0;var d=a.data(b,"treegrid").options,e=a(b).datagrid("getPanel").children("div.datagrid-view"),f=e.find('div.datagrid-body tr[node-id="'+c+'"]').children('td[field="'+d.treeField+'"]');return f.find("span.tree-indent,span.tree-hit").length}function p(b,c){for(var d=a.data(b,"treegrid").options,e=a.data(b,"treegrid").data,f=[e];f.length;)for(var g=f.shift(),h=0;h<g.length;h++){var i=g[h];if(i[d.idField]==c)return i;i.children&&f.push(i.children)}return null}function q(b,d){var e=a.data(b,"treegrid").options,f=p(b,d),g=e.finder.getTr(b,d),h=g.find("span.tree-hit");if(0!=h.length&&!h.hasClass("tree-collapsed")&&0!=e.onBeforeCollapse.call(b,f)){h.removeClass("tree-expanded tree-expanded-hover").addClass("tree-collapsed"),h.next().removeClass("tree-folder-open"),f.state="closed",g=g.next("tr.treegrid-tr-tree");var i=g.children("td").children("div");e.animate?i.slideUp("normal",function(){a(b).treegrid("autoSizeColumn"),c(b,d),e.onCollapse.call(b,f)}):(i.hide(),a(b).treegrid("autoSizeColumn"),c(b,d),e.onCollapse.call(b,f))}}function r(b,d){function e(e){k.state="open",g.animate?e.slideDown("normal",function(){a(b).treegrid("autoSizeColumn"),c(b,d),g.onExpand.call(b,k)}):(e.show(),a(b).treegrid("autoSizeColumn"),c(b,d),g.onExpand.call(b,k))}var g=a.data(b,"treegrid").options,i=g.finder.getTr(b,d),j=i.find("span.tree-hit"),k=p(b,d);if(0!=j.length&&!j.hasClass("tree-expanded")&&0!=g.onBeforeExpand.call(b,k)){j.removeClass("tree-collapsed tree-collapsed-hover").addClass("tree-expanded"),j.next().addClass("tree-folder-open");var l=i.next("tr.treegrid-tr-tree");if(l.length){var m=l.children("td").children("div");e(m)}else{f(b,k[g.idField]);var l=i.next("tr.treegrid-tr-tree"),m=l.children("td").children("div");m.hide();var n=a.extend({},g.queryParams||{});n.id=k[g.idField],h(b,k[g.idField],n,!0,function(){m.is(":empty")?l.remove():e(m)})}}}function s(b,c){var d=a.data(b,"treegrid").options,e=d.finder.getTr(b,c),f=e.find("span.tree-hit");f.hasClass("tree-expanded")?q(b,c):r(b,c)}function t(b,c){var d=a.data(b,"treegrid").options,e=l(b,c);c&&e.unshift(p(b,c));for(var f=0;f<e.length;f++)q(b,e[f][d.idField])}function u(b,c){var d=a.data(b,"treegrid").options,e=l(b,c);c&&e.unshift(p(b,c));for(var f=0;f<e.length;f++)r(b,e[f][d.idField])}function v(b,c){for(var d=a.data(b,"treegrid").options,e=[],f=k(b,c);f;){var g=f[d.idField];e.unshift(g),f=k(b,g)}for(var h=0;h<e.length;h++)r(b,e[h])}function w(b,c){var d=a.data(b,"treegrid").options;if(c.parent){var e=d.finder.getTr(b,c.parent);0==e.next("tr.treegrid-tr-tree").length&&f(b,c.parent);var h=e.children('td[field="'+d.treeField+'"]').children("div.datagrid-cell"),i=h.children("span.tree-icon");if(i.hasClass("tree-file")){i.removeClass("tree-file").addClass("tree-folder tree-folder-open");var j=a('<span class="tree-hit tree-expanded"></span>').insertBefore(i);j.prev().length&&j.prev().remove()}}g(b,c.parent,c.data,!0)}function x(b,c){function e(a){var d=a?1:2,e=g.finder.getTr(b,c.data[g.idField],"body",d),h=e.closest("table.datagrid-btable");e=e.parent().children();var i=g.finder.getTr(b,f,"body",d);if(c.before)e.insertBefore(i);else{var j=i.next("tr.treegrid-tr-tree");e.insertAfter(j.length?j:i)}h.remove()}var f=c.before||c.after,g=a.data(b,"treegrid").options,h=k(b,f);w(b,{parent:h?h[g.idField]:null,data:[c.data]}),e(!0),e(!1),d(b)}function y(b,c){function e(d){var e,g=k(b,c);e=g?g.children:a(b).treegrid("getData");for(var h=0;h<e.length;h++)if(e[h][f.idField]==d){e.splice(h,1);break}return g}var f=a.data(b,"treegrid").options,g=f.finder.getTr(b,c);g.next("tr.treegrid-tr-tree").remove(),g.remove();var h=e(c);if(h&&0==h.children.length){g=f.finder.getTr(b,h[f.idField]),g.next("tr.treegrid-tr-tree").remove();var i=g.children('td[field="'+f.treeField+'"]').children("div.datagrid-cell");i.find(".tree-icon").removeClass("tree-folder").addClass("tree-file"),i.find(".tree-hit").remove(),a('<span class="tree-indent"></span>').prependTo(i)}d(b)}a.fn.treegrid=function(c,d){if("string"==typeof c){var f=a.fn.treegrid.methods[c];return f?f(this,d):this.datagrid(c,d)}return c=c||{},this.each(function(){var d=a.data(this,"treegrid");d?a.extend(d.options,c):d=a.data(this,"treegrid",{options:a.extend({},a.fn.treegrid.defaults,a.fn.treegrid.parseOptions(this),c),data:[]}),b(this),d.options.data&&a(this).treegrid("loadData",d.options.data),h(this),e(this)})},a.fn.treegrid.methods={options:function(b){return a.data(b[0],"treegrid").options},resize:function(b,c){return b.each(function(){a(this).datagrid("resize",c)})},fixRowHeight:function(a,b){return a.each(function(){c(this,b)})},loadData:function(a,b){return a.each(function(){g(this,b.parent,b)})},load:function(b,c){return b.each(function(){a(this).treegrid("options").pageNumber=1,a(this).treegrid("getPager").pagination({pageNumber:1}),a(this).treegrid("reload",c)})},reload:function(b,c){return b.each(function(){var b=a(this).treegrid("options"),d={};if("object"==typeof c?d=c:(d=a.extend({},b.queryParams),d.id=c),d.id){var e=a(this).treegrid("find",d.id);e.children&&e.children.splice(0,e.children.length),b.queryParams=d;var f=b.finder.getTr(this,d.id);f.next("tr.treegrid-tr-tree").remove(),f.find("span.tree-hit").removeClass("tree-expanded tree-expanded-hover").addClass("tree-collapsed"),r(this,d.id)}else h(this,null,d)})},reloadFooter:function(b,c){return b.each(function(){var b=a.data(this,"treegrid").options,d=a.data(this,"datagrid").dc;c&&(a.data(this,"treegrid").footer=c),b.showFooter&&(b.view.renderFooter.call(b.view,this,d.footer1,!0),b.view.renderFooter.call(b.view,this,d.footer2,!1),b.view.onAfterRender&&b.view.onAfterRender.call(b.view,this),a(this).treegrid("fixRowHeight"))})},getData:function(b){return a.data(b[0],"treegrid").data},getFooterRows:function(b){return a.data(b[0],"treegrid").footer},getRoot:function(a){return i(a[0])},getRoots:function(a){return j(a[0])},getParent:function(a,b){return k(a[0],b)},getChildren:function(a,b){return l(a[0],b)},getSelected:function(a){return m(a[0])},getSelections:function(a){return n(a[0])},getLevel:function(a,b){return o(a[0],b)},find:function(a,b){return p(a[0],b)},isLeaf:function(b,c){var d=a.data(b[0],"treegrid").options,e=d.finder.getTr(b[0],c),f=e.find("span.tree-hit");return 0==f.length},select:function(b,c){return b.each(function(){a(this).datagrid("selectRow",c)})},unselect:function(b,c){return b.each(function(){a(this).datagrid("unselectRow",c)})},collapse:function(a,b){return a.each(function(){q(this,b)})},expand:function(a,b){return a.each(function(){r(this,b)})},toggle:function(a,b){return a.each(function(){s(this,b)})},collapseAll:function(a,b){return a.each(function(){t(this,b)})},expandAll:function(a,b){return a.each(function(){u(this,b)})},expandTo:function(a,b){return a.each(function(){v(this,b)})},append:function(a,b){return a.each(function(){w(this,b)})},insert:function(a,b){return a.each(function(){x(this,b)})},remove:function(a,b){return a.each(function(){y(this,b)})},pop:function(a,b){var c=a.treegrid("find",b);return a.treegrid("remove",b),c},refresh:function(b,c){return b.each(function(){var b=a.data(this,"treegrid").options;b.view.refreshRow.call(b.view,this,c)})},update:function(b,c){return b.each(function(){var b=a.data(this,"treegrid").options;b.view.updateRow.call(b.view,this,c.id,c.row)})},beginEdit:function(b,c){return b.each(function(){a(this).datagrid("beginEdit",c),a(this).treegrid("fixRowHeight",c)})},endEdit:function(b,c){return b.each(function(){a(this).datagrid("endEdit",c)})},cancelEdit:function(b,c){return b.each(function(){a(this).datagrid("cancelEdit",c)})}},a.fn.treegrid.parseOptions=function(b){return a.extend({},a.fn.datagrid.parseOptions(b),a.parser.parseOptions(b,["treeField",{animate:"boolean"}]))};var z=a.extend({},a.fn.datagrid.defaults.view,{render:function(b,c,d){function e(a,c,d){for(var k=['<table class="datagrid-btable" cellspacing="0" cellpadding="0" border="0"><tbody>'],l=0;l<d.length;l++){var m=d[l];"open"!=m.state&&"closed"!=m.state&&(m.state="open");var n=f.rowStyler?f.rowStyler.call(b,m):"",o="",p="";"string"==typeof n?p=n:n&&(o=n["class"]||"",p=n.style||"");var q='class="datagrid-row '+(i++%2&&f.striped?"datagrid-row-alt ":" ")+o+'"',r=p?'style="'+p+'"':"",s=h+"-"+(a?1:2)+"-"+m[f.idField];if(k.push('<tr id="'+s+'" node-id="'+m[f.idField]+'" '+q+" "+r+">"),k=k.concat(j.renderRow.call(j,b,g,a,c,m)),k.push("</tr>"),m.children&&m.children.length){var t=e(a,c+1,m.children),u="closed"==m.state?"none":"block";k.push('<tr class="treegrid-tr-tree"><td style="border:0px" colspan='+(g.length+(f.rownumbers?1:0))+'><div style="display:'+u+'">'),k=k.concat(t),k.push("</div></td></tr>")}}return k.push("</tbody></table>"),k}var f=a.data(b,"treegrid").options,g=a(b).datagrid("getColumnFields",d),h=a.data(b,"datagrid").rowIdPrefix;if(!d||f.rownumbers||f.frozenColumns&&f.frozenColumns.length){var i=0,j=this,k=e(d,this.treeLevel,this.treeNodes);a(c).append(k.join(""))}},renderFooter:function(b,c,d){for(var e=a.data(b,"treegrid").options,f=a.data(b,"treegrid").footer||[],g=a(b).datagrid("getColumnFields",d),h=['<table class="datagrid-ftable" cellspacing="0" cellpadding="0" border="0"><tbody>'],i=0;i<f.length;i++){var j=f[i];j[e.idField]=j[e.idField]||"foot-row-id"+i,h.push('<tr class="datagrid-row" node-id="'+j[e.idField]+'">'),h.push(this.renderRow.call(this,b,g,d,0,j)),h.push("</tr>")}h.push("</tbody></table>"),a(c).html(h.join(""))},renderRow:function(b,c,d,e,f){var g=a.data(b,"treegrid").options,h=[];d&&g.rownumbers&&h.push('<td class="datagrid-td-rownumber"><div class="datagrid-cell-rownumber">0</div></td>');for(var i=0;i<c.length;i++){var j=c[i],k=a(b).datagrid("getColumnOption",j);if(k){var l=k.styler?k.styler(f[j],f)||"":"",m="",n="";"string"==typeof l?n=l:h&&(m=l["class"]||"",n=l.style||"");var o=m?'class="'+m+'"':"",p=k.hidden?'style="display:none;'+n+'"':n?'style="'+n+'"':"";if(h.push('<td field="'+j+'" '+o+" "+p+">"),k.checkbox)var p="";else{var p=n;k.align&&(p+=";text-align:"+k.align+";"),g.nowrap?g.autoRowHeight&&(p+=";height:auto;"):p+=";white-space:normal;height:auto;"}if(h.push('<div style="'+p+'" '),h.push(k.checkbox?'class="datagrid-cell-check ':'class="datagrid-cell '+k.cellClass),h.push('">'),k.checkbox)h.push(f.checked?'<input type="checkbox" checked="checked"':'<input type="checkbox"'),h.push(' name="'+j+'" value="'+(void 0!=f[j]?f[j]:"")+'"/>');else{var q=null;if(q=k.formatter?k.formatter(f[j],f):f[j],j==g.treeField){for(var r=0;e>r;r++)h.push('<span class="tree-indent"></span>');"closed"==f.state?(h.push('<span class="tree-hit tree-collapsed"></span>'),h.push('<span class="tree-icon tree-folder '+(f.iconCls?f.iconCls:"")+'"></span>')):f.children&&f.children.length?(h.push('<span class="tree-hit tree-expanded"></span>'),h.push('<span class="tree-icon tree-folder tree-folder-open '+(f.iconCls?f.iconCls:"")+'"></span>')):(h.push('<span class="tree-indent"></span>'),h.push('<span class="tree-icon tree-file '+(f.iconCls?f.iconCls:"")+'"></span>')),h.push('<span class="tree-title">'+q+"</span>")}else h.push(q)}h.push("</div>"),h.push("</td>")}}return h.join("")},refreshRow:function(a,b){this.updateRow.call(this,a,b,{})},updateRow:function(b,c,d){function e(d){var e=a(b).treegrid("getColumnFields",d),j=f.finder.getTr(b,c,"body",d?1:2),k=j.find("div.datagrid-cell-rownumber").html(),l=j.find("div.datagrid-cell-check input[type=checkbox]").is(":checked");j.html(this.renderRow(b,e,d,h,g)),j.attr("style",i||""),j.find("div.datagrid-cell-rownumber").html(k),l&&j.find("div.datagrid-cell-check input[type=checkbox]")._propAttr("checked",!0)}var f=a.data(b,"treegrid").options,g=a(b).treegrid("find",c);a.extend(g,d);var h=a(b).treegrid("getLevel",c)-1,i=f.rowStyler?f.rowStyler.call(b,g):"";e.call(this,!0),e.call(this,!1),a(b).treegrid("fixRowHeight",c)},onBeforeRender:function(b,c,d){function e(a,b){for(var c=0;c<a.length;c++){var d=a[c];d._parentId=b,d.children&&d.children.length&&e(d.children,d[g.idField])}}if(a.isArray(c)&&(d={total:c.length,rows:c},c=null),!d)return!1;var f=a.data(b,"treegrid"),g=f.options;void 0==d.length?(d.footer&&(f.footer=d.footer),d.total&&(f.total=d.total),d=this.transfer(b,c,d.rows)):e(d,c);var h=p(b,c);h?h.children=h.children?h.children.concat(d):d:f.data=f.data.concat(d),this.sort(b,d),this.treeNodes=d,this.treeLevel=a(b).treegrid("getLevel",c)},sort:function(b,c){function d(c){c.sort(function(c,d){for(var e=0,h=0;h<f.length;h++){var i=f[h],j=g[h],k=a(b).treegrid("getColumnOption",i),l=k.sorter||function(a,b){return a==b?0:a>b?1:-1};if(e=l(c[i],d[i])*("asc"==j?1:-1),0!=e)return e}return e});for(var e=0;e<c.length;e++){var h=c[e].children;h&&h.length&&d(h)}}var e=a.data(b,"treegrid").options;if(!e.remoteSort&&e.sortName){var f=e.sortName.split(","),g=e.sortOrder.split(",");d(c)}},transfer:function(b,c,d){for(var e=a.data(b,"treegrid").options,f=[],g=0;g<d.length;g++)f.push(d[g]);for(var h=[],g=0;g<f.length;g++){var i=f[g];c?i._parentId==c&&(h.push(i),f.splice(g,1),g--):i._parentId||(h.push(i),f.splice(g,1),g--)}for(var j=[],g=0;g<h.length;g++)j.push(h[g]);for(;j.length;)for(var k=j.shift(),g=0;g<f.length;g++){var i=f[g];i._parentId==k[e.idField]&&(k.children?k.children.push(i):k.children=[i],j.push(i),f.splice(g,1),g--)}return h}});a.fn.treegrid.defaults=a.extend({},a.fn.datagrid.defaults,{treeField:null,animate:!1,singleSelect:!0,view:z,loader:function(b,c,d){var e=a(this).treegrid("options");return e.url?void a.ajax({type:e.method,url:e.url,data:b,dataType:"json",success:function(a){c(a)},error:function(){d.apply(this,arguments)}}):!1},loadFilter:function(a){return a},finder:{getTr:function(b,c,d,e){d=d||"body",e=e||0;var f=a.data(b,"datagrid").dc;if(0==e){var g=a.data(b,"treegrid").options,h=g.finder.getTr(b,c,d,1),i=g.finder.getTr(b,c,d,2);return h.add(i)}if("body"==d){var j=a("#"+a.data(b,"datagrid").rowIdPrefix+"-"+e+"-"+c);return j.length||(j=(1==e?f.body1:f.body2).find('tr[node-id="'+c+'"]')),j}return"footer"==d?(1==e?f.footer1:f.footer2).find('tr[node-id="'+c+'"]'):"selected"==d?(1==e?f.body1:f.body2).find("tr.datagrid-row-selected"):"highlight"==d?(1==e?f.body1:f.body2).find("tr.datagrid-row-over"):"checked"==d?(1==e?f.body1:f.body2).find("tr.datagrid-row-checked"):"last"==d?(1==e?f.body1:f.body2).find("tr:last[node-id]"):"allbody"==d?(1==e?f.body1:f.body2).find("tr[node-id]"):"allfooter"==d?(1==e?f.footer1:f.footer2).find("tr[node-id]"):void 0},getRow:function(b,c){var d="object"==typeof c?c.attr("node-id"):c;return a(b).treegrid("find",d)}},onBeforeLoad:function(){},onLoadSuccess:function(){},onLoadError:function(){},onBeforeCollapse:function(){},onCollapse:function(){},onBeforeExpand:function(){},onExpand:function(){},onClickRow:function(){},onDblClickRow:function(){},onClickCell:function(){},onDblClickCell:function(){},onContextMenu:function(){},onBeforeEdit:function(){},onAfterEdit:function(){},onCancelEdit:function(){}})}(jQuery);