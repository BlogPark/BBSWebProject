(function ($) {
    $("#main-nav  li").each(function (index) {
        $(this).click(function () {
            var date = new Date();
            date.setTime(date.getTime() + 180 * 1000);
            document.cookie = "liindex=" + index + ";expires=" + date.toGMTString();
        })
    })
    var acookie = document.cookie.split("; ");
    var cookvalue = getcookie('liindex');
    if (cookvalue != '') {
        $("#main-nav .active").removeClass("active");
        var element = $("#main-nav li").eq(cookvalue);
        element.addClass("active");
    }
    else {
        $("#main-nav .active").removeClass("active");
        var element = $("#main-nav li").eq(0);
        element.addClass("active");
    }

    function getcookie(sname) {
        for (var i = 0; i < acookie.length; i++) {
            var arr = acookie[i].split("=");
            if (sname == arr[0]) {
                if (arr.length > 1)
                    return unescape(arr[1]);
                else
                    return "";
            }
        }
        return "";
    }
})(jQuery);