/*! tjzx.ued version:0.1.0 2014-04-25 14:28:37 */
$.fn.pagination&&($.fn.pagination.defaults.beforePageText="Sayfa",$.fn.pagination.defaults.afterPageText=" / {pages}",$.fn.pagination.defaults.displayMsg="{from} ile {to} arası gösteriliyor, toplam {total} kayıt"),$.fn.datagrid&&($.fn.panel.defaults.loadingMessage="Yükleniyor..."),$.fn.datagrid&&($.fn.datagrid.defaults.loadingMessage="Yükleniyor...",$.fn.datagrid.defaults.loadMsg="İşleminiz Yapılıyor, lütfen bekleyin ..."),$.fn.treegrid&&$.fn.datagrid&&($.fn.treegrid.defaults.loadMsg=$.fn.datagrid.defaults.loadMsg),$.messager&&($.messager.defaults.ok="Tamam",$.messager.defaults.cancel="İptal"),$.fn.validatebox&&($.fn.validatebox.defaults.missingMessage="Bu alan zorunludur.",$.fn.validatebox.defaults.rules.email.message="Lütfen geçerli bir email adresi giriniz.",$.fn.validatebox.defaults.rules.url.message="Lütfen geçerli bir URL giriniz.",$.fn.validatebox.defaults.rules.length.message="Lütfen {0} ile {1} arasında bir değer giriniz.",$.fn.validatebox.defaults.rules.remote.message="Lütfen bu alanı düzeltiniz."),$.fn.numberbox&&($.fn.numberbox.defaults.missingMessage="Bu alan zorunludur."),$.fn.combobox&&($.fn.combobox.defaults.missingMessage="Bu alan zorunludur."),$.fn.combotree&&($.fn.combotree.defaults.missingMessage="Bu alan zorunludur."),$.fn.combogrid&&($.fn.combogrid.defaults.missingMessage="Bu alan zorunludur."),$.fn.calendar&&($.fn.calendar.defaults.weeks=["Pz","Pt","Sa","Ça","Pe","Cu","Ct"],$.fn.calendar.defaults.months=["Oca","Şub","Mar","Nis","May","Haz","Tem","Ağu","Eyl","Eki","Kas","Ara"]),$.fn.datebox&&($.fn.datebox.defaults.currentText="Bugün",$.fn.datebox.defaults.closeText="Kapat",$.fn.datebox.defaults.okText="Tamam",$.fn.datebox.defaults.missingMessage="Bu alan zorunludur."),$.fn.datetimebox&&$.fn.datebox&&($.extend($.fn.datetimebox.defaults,{currentText:$.fn.datebox.defaults.currentText,closeText:$.fn.datebox.defaults.closeText,okText:$.fn.datebox.defaults.okText,missingMessage:$.fn.datebox.defaults.missingMessage}),$.fn.datebox.defaults.formatter=function(a){var b=a.getFullYear(),c=a.getMonth()+1,d=a.getDate();return 10>c&&(c="0"+c),10>d&&(d="0"+d),d+"."+c+"."+b});