
// @source core/net/StringUtils.js

Ext.net.StringUtils = function () {
    return {
        startsWith : function (str, value) {
            return str.match("^" + value) !== null;
        },

        endsWith : function (str, value) {
            return str.match(value + "$") !== null;
        },
        
        format : function (format) {
            var args = Ext.toArray(arguments, 1);
            return format.replace(/\{(\d+)\}/g, function (m, i) {
                return args[i];
            });
        }
    };
}();