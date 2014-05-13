var decToHex = function(str) {
    var res = [];
    for (var i = 0; i < str.length; i++)
        res[i] = ("00" + str.charCodeAt(i).toString(16)).slice(-4);
    return "\\u" + res.join("\\u");
};
var hexToDec = function(str) {
    str = str.replace(/\\/g, "%");
    return unescape(str);
};
(function ($, T, S) {
    var logger = S.getLogger("homeConfig");
    $(".m-table")
        .delegate(".j-edit", "click", function () {
            var $t = $(this),
                $tr = $t.parents("tr"),
                $tds = $tr.find("td");
            for (var i = 1; i < $tds.length - 1; i++) {
                var $td = $tds.eq(i);
                $td.data("html", $td.html());
                var val = "",
                    child = $td.children().get(0);
                if (!child)
                    val = $td.text();
                else {
                    switch (child.tagName.toLowerCase()) {
                        case "img":
                            val = child.getAttribute("src");
                            break;
                        case "i":
                            val = decToHex(child.innerHTML);
                            break;
                        default:
                    }
                }
                $td.html('<input type="text" class="text" name="' + $td.data("name") + '" value="' + val + '" />');
            }
            $t.parent().html('<a href="#" class="j-save">保存</a><a href="#" class="j-cancel">取消编辑</a>');
        })
        .delegate(".j-cancel", "click", function () {
            var $t = $(this),
                $tr = $t.parents("tr"),
                $tds = $tr.find("td");
            for (var i = 1; i < $tds.length - 1; i++) {
                var $td = $tds.eq(i);
                $td.html($td.data("html"));
            }
            $t.parent().html('<a href="#" class="j-edit">编辑</a>');
        })
        .delegate(".j-save", "click", function () {
            var $t = $(this),
                $tr = $t.parents("tr"),
                vform = $tr.valid();
            var data = vform.json();
            data.Id = $tr.data("id");
            if (data.Icon) {
                data.Icon = encodeURIComponent(data.Icon.replace(/\\u/i, "&#x"));
            }
            var action = "update_" + $tr.parents("table").data("type");
            T.getJson("/m/homeconfig/" + action, data, function (json) {
                if (json && 1 === json.state) {
                    Alert(json.msg || "更新成功！",function() {
                        location.reload(true);
                    });
                } else {
                    Alert(json.msg || "更新异常！");
                }
            });
        });
})(jQuery, TJZX, SINGER);