/*! tjzx.ued version:0.1.0 2014-05-10 09:49:49 */
$.fn.pagination&&($.fn.pagination.defaults.beforePageText="Seite",$.fn.pagination.defaults.afterPageText="von {pages}",$.fn.pagination.defaults.displayMsg="{from} bis {to} von {total} Datensätzen"),$.fn.datagrid&&($.fn.datagrid.defaults.loadMsg="Verarbeitung läuft, bitte warten ..."),$.fn.treegrid&&$.fn.datagrid&&($.fn.treegrid.defaults.loadMsg=$.fn.datagrid.defaults.loadMsg),$.messager&&($.messager.defaults.ok="OK",$.messager.defaults.cancel="Abbruch"),$.fn.validatebox&&($.fn.validatebox.defaults.missingMessage="Dieses Feld wird benötigt.",$.fn.validatebox.defaults.rules.email.message="Bitte geben Sie eine gültige E-Mail-Adresse ein.",$.fn.validatebox.defaults.rules.url.message="Bitte geben Sie eine gültige URL ein.",$.fn.validatebox.defaults.rules.length.message="Bitte geben Sie einen Wert zwischen {0} und {1} ein."),$.fn.numberbox&&($.fn.numberbox.defaults.missingMessage="Dieses Feld wird benötigt."),$.fn.combobox&&($.fn.combobox.defaults.missingMessage="Dieses Feld wird benötigt."),$.fn.combotree&&($.fn.combotree.defaults.missingMessage="Dieses Feld wird benötigt."),$.fn.combogrid&&($.fn.combogrid.defaults.missingMessage="Dieses Feld wird benötigt."),$.fn.calendar&&($.fn.calendar.defaults.firstDay=1,$.fn.calendar.defaults.weeks=["S","M","D","M","D","F","S"],$.fn.calendar.defaults.months=["Jan","Feb","Mär","Apr","Mai","Jun","Jul","Aug","Sep","Okt","Nov","Dez"]),$.fn.datebox&&($.fn.datebox.defaults.currentText="Heute",$.fn.datebox.defaults.closeText="Schließen",$.fn.datebox.defaults.okText="OK",$.fn.datebox.defaults.missingMessage="Dieses Feld wird benötigt.",$.fn.datebox.defaults.formatter=function(a){var b=a.getFullYear(),c=a.getMonth()+1,d=a.getDate();return(10>d?"0"+d:d)+"."+(10>c?"0"+c:c)+"."+b},$.fn.datebox.defaults.parser=function(a){if(!a)return new Date;var b=a.split("."),c=parseInt(b[1],10),d=parseInt(b[0],10),e=parseInt(b[2],10);return isNaN(e)||isNaN(c)||isNaN(d)?new Date:new Date(e,c-1,d)}),$.fn.datetimebox&&$.fn.datebox&&$.extend($.fn.datetimebox.defaults,{currentText:$.fn.datebox.defaults.currentText,closeText:$.fn.datebox.defaults.closeText,okText:$.fn.datebox.defaults.okText,missingMessage:$.fn.datebox.defaults.missingMessage});