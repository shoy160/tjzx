/*! tjzx.ued version:0.1.0 2014-04-25 14:28:37 */
$.fn.pagination&&($.fn.pagination.defaults.beforePageText="Page",$.fn.pagination.defaults.afterPageText="af {pages}",$.fn.pagination.defaults.displayMsg="Viser {from} til {to} af {total} poster"),$.fn.datagrid&&($.fn.datagrid.defaults.loadMsg="Behandling, vent venligst ..."),$.fn.treegrid&&$.fn.datagrid&&($.fn.treegrid.defaults.loadMsg=$.fn.datagrid.defaults.loadMsg),$.messager&&($.messager.defaults.ok="Ok",$.messager.defaults.cancel="Annuller"),$.fn.validatebox&&($.fn.validatebox.defaults.missingMessage="Dette felt er påkrævet.",$.fn.validatebox.defaults.rules.email.message="Angiv en gyldig e-mail-adresse.",$.fn.validatebox.defaults.rules.url.message="Angiv en gyldig webadresse.",$.fn.validatebox.defaults.rules.length.message="Angiv en værdi mellem {0} og {1}."),$.fn.numberbox&&($.fn.numberbox.defaults.missingMessage="Dette felt er påkrævet."),$.fn.combobox&&($.fn.combobox.defaults.missingMessage="Dette felt er påkrævet."),$.fn.combotree&&($.fn.combotree.defaults.missingMessage="Dette felt er påkrævet."),$.fn.combogrid&&($.fn.combogrid.defaults.missingMessage="Dette felt er påkrævet."),$.fn.calendar&&($.fn.calendar.defaults.weeks=["S","M","T","W","T","F","S"],$.fn.calendar.defaults.months=["Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec"]),$.fn.datebox&&($.fn.datebox.defaults.currentText="I dag",$.fn.datebox.defaults.closeText="Luk",$.fn.datebox.defaults.okText="Ok",$.fn.datebox.defaults.missingMessage="Dette felt er påkrævet."),$.fn.datetimebox&&$.fn.datebox&&$.extend($.fn.datetimebox.defaults,{currentText:$.fn.datebox.defaults.currentText,closeText:$.fn.datebox.defaults.closeText,okText:$.fn.datebox.defaults.okText,missingMessage:$.fn.datebox.defaults.missingMessage});