/*! tjzx.ued version:0.1.0 2014-04-02 15:42:53 */
$.fn.pagination&&($.fn.pagination.defaults.beforePageText="Strona",$.fn.pagination.defaults.afterPageText="z {pages}",$.fn.pagination.defaults.displayMsg="Wyświetlono elementy od {from} do {to} z {total}"),$.fn.datagrid&&($.fn.datagrid.defaults.loadMsg="Przetwarzanie, proszę czekać ..."),$.fn.treegrid&&$.fn.datagrid&&($.fn.treegrid.defaults.loadMsg=$.fn.datagrid.defaults.loadMsg),$.messager&&($.messager.defaults.ok="Ok",$.messager.defaults.cancel="Cancel"),$.fn.validatebox&&($.fn.validatebox.defaults.missingMessage="To pole jest wymagane.",$.fn.validatebox.defaults.rules.email.message="Wprowadź poprawny adres email.",$.fn.validatebox.defaults.rules.url.message="Wprowadź poprawny adres URL.",$.fn.validatebox.defaults.rules.length.message="Wprowadź wartość z zakresu od {0} do {1}.",$.fn.validatebox.defaults.rules.remote.message="Proszę poprawić to pole."),$.fn.numberbox&&($.fn.numberbox.defaults.missingMessage="To pole jest wymagane."),$.fn.combobox&&($.fn.combobox.defaults.missingMessage="To pole jest wymagane."),$.fn.combotree&&($.fn.combotree.defaults.missingMessage="To pole jest wymagane."),$.fn.combogrid&&($.fn.combogrid.defaults.missingMessage="To pole jest wymagane."),$.fn.calendar&&($.fn.calendar.defaults.weeks=["N","P","W","Ś","C","P","S"],$.fn.calendar.defaults.months=["Sty","Lut","Mar","Kwi","Maj","Cze","Lip","Sie","Wrz","Paź","Lis","Gru"]),$.fn.datebox&&($.fn.datebox.defaults.currentText="Dzisiaj",$.fn.datebox.defaults.closeText="Zamknij",$.fn.datebox.defaults.okText="Ok",$.fn.datebox.defaults.missingMessage="To pole jest wymagane."),$.fn.datetimebox&&$.fn.datebox&&$.extend($.fn.datetimebox.defaults,{currentText:$.fn.datebox.defaults.currentText,closeText:$.fn.datebox.defaults.closeText,okText:$.fn.datebox.defaults.okText,missingMessage:$.fn.datebox.defaults.missingMessage});