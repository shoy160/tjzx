/*! tjzx.ued version:0.1.0 2014-05-10 09:49:49 */
$.fn.pagination&&($.fn.pagination.defaults.beforePageText="Страница",$.fn.pagination.defaults.afterPageText="от {pages}",$.fn.pagination.defaults.displayMsg="Показани {from} за {to} от {total} продукти"),$.fn.datagrid&&($.fn.datagrid.defaults.loadMsg="Обработка, моля изчакайте ..."),$.fn.treegrid&&$.fn.datagrid&&($.fn.treegrid.defaults.loadMsg=$.fn.datagrid.defaults.loadMsg),$.messager&&($.messager.defaults.ok="Добре",$.messager.defaults.cancel="Задрасквам"),$.fn.validatebox&&($.fn.validatebox.defaults.missingMessage="Това поле е задължително.",$.fn.validatebox.defaults.rules.email.message="Моля, въведете валиден имейл адрес.",$.fn.validatebox.defaults.rules.url.message="Моля въведете валиден URL.",$.fn.validatebox.defaults.rules.length.message="Моля, въведете стойност между {0} и {1}."),$.fn.numberbox&&($.fn.numberbox.defaults.missingMessage="Това поле е задължително."),$.fn.combobox&&($.fn.combobox.defaults.missingMessage="Това поле е задължително."),$.fn.combotree&&($.fn.combotree.defaults.missingMessage="Това поле е задължително."),$.fn.combogrid&&($.fn.combogrid.defaults.missingMessage="Това поле е задължително."),$.fn.calendar&&($.fn.calendar.defaults.weeks=["S","M","T","W","T","F","S"],$.fn.calendar.defaults.months=["Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec"]),$.fn.datebox&&($.fn.datebox.defaults.currentText="Днес",$.fn.datebox.defaults.closeText="Близо",$.fn.datebox.defaults.okText="Добре",$.fn.datebox.defaults.missingMessage="Това поле е задължително."),$.fn.datetimebox&&$.fn.datebox&&$.extend($.fn.datetimebox.defaults,{currentText:$.fn.datebox.defaults.currentText,closeText:$.fn.datebox.defaults.closeText,okText:$.fn.datebox.defaults.okText,missingMessage:$.fn.datebox.defaults.missingMessage});