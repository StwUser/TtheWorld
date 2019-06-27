// site Js
// in comments is Js variant
(function () {
    /*
    //var ele = document.getElementById("username");
    var ele = $("#username");
    //ele.innerHTML = "New Name";
    ele.text("New Name");

    //var main = document.getElementById("main");
    var main = $("#main");
    //main.onmouseenter = function () {
    //  main.style.background = "#888";
    //    alert('hello');
    //};
    
    main.on("mouseenter", function () {
        main.css("background-color", "#888");
    });

    main.on("mouseleave" , function () {
        main.css("background-color", "");
    });

    var menuItems = $("ul.menu li a");
    menuItems.on("click", function () {
        var me = $(this);
        alert(me.text());
    });
    */

    var $side = $("#sidebar");
    var $wrap = $("#wrapper");
    var $icon = $("#sidebarToggle i.fa");

    $("#sidebarToggle").on("click", function () {

        $side.toggleClass("hide-sidebar");
        $wrap.toggleClass("hide-sidebar");

        if ($side.hasClass("hide-sidebar") && $wrap.hasClass("hide-sidebar")) {
            //this.textContent = "Show Sidebar";
            $icon.removeClass("fa-angle-left");
            $icon.addClass("fa-angle-right");
        }
        else {
            //this.textContent = "Hide Sidebar";
            $icon.addClass("fa-angle-left");
            $icon.removeClass("fa-angle-right");
        }
    });
})();

