/*! tjzx.ued version:0.1.0 2014-04-25 14:28:37 */
$.fn.pagination&&($.fn.pagination.defaults.beforePageText="Sida",$.fn.pagination.defaults.afterPageText="av {pages}",$.fn.pagination.defaults.displayMsg="Visar {from} till {to} av {total} poster"),$.fn.datagrid&&($.fn.datagrid.defaults.loadMsg="Bearbetar, vänligen vänta ..."),$.fn.treegrid&&$.fn.datagrid&&($.fn.treegrid.defaults.loadMsg=$.fn.datagrid.defaults.loadMsg),$.messager&&($.messager.defaults.ok="Ok",$.messager.defaults.cancel="Avbryt"),$.fn.validatebox&&($.fn.validatebox.defaults.missingMessage="Detta fält är obligatoriskt.",$.fn.validatebox.defaults.rules.email.message="Vänligen ange en korrekt e-post adress.",$.fn.validatebox.defaults.rules.url.message="Vänligen ange en korrekt URL.",$.fn.validatebox.defaults.rules.length.message="Vänligen ange ett nummer mellan {0} och {1}.",$.fn.validatebox.defaults.rules.remote.message="Vänligen åtgärda detta fält."),$.fn.numberbox&&($.fn.numberbox.defaults.missingMessage="Detta fält är obligatoriskt."),$.fn.combobox&&($.fn.combobox.defaults.missingMessage="Detta fält är obligatoriskt."),$.fn.combotree&&($.fn.combotree.defaults.missingMessage="Detta fält är obligatoriskt."),$.fn.combogrid&&($.fn.combogrid.defaults.missingMessage="Detta fält är obligatoriskt."),$.fn.calendar&&($.fn.calendar.defaults.weeks=["Sön","Mån","Tis","Ons","Tors","Fre","Lör"],$.fn.calendar.defaults.months=["Jan","Feb","Mar","Apr","Maj","Jun","Jul","Aug","Sep","Okt","Nov","Dec"]),$.fn.datebox&&($.fn.datebox.defaults.currentText="I dag",$.fn.datebox.defaults.closeText="Stäng",$.fn.datebox.defaults.okText="Ok",$.fn.datebox.defaults.missingMessage="Detta fält är obligatoriskt."),$.fn.datetimebox&&$.fn.datebox&&$.extend($.fn.datetimebox.defaults,{currentText:$.fn.datebox.defaults.currentText,closeText:$.fn.datebox.defaults.closeText,okText:$.fn.datebox.defaults.okText,missingMessage:$.fn.datebox.defaults.missingMessage});