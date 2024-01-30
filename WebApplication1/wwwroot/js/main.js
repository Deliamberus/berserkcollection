$(function () {
    $(".minus").click(function () {
        let countlabel = $(this).siblings('label.count');
        let countinput = $(this).siblings('input.count');
        let img = $(this).siblings('img');
        let newValue = parseInt(countlabel.text()) - 1;

        if (newValue <= 0) {
            newValue = 0;
            img.addClass("gray");
        }

        countlabel.text(newValue);
        countinput.val(newValue);
    });

    $(".plus").click(function () {
        let countlabel = $(this).siblings('label.count');
        let countinput = $(this).siblings('input.count');
        let img = $(this).siblings('img');
        let newValue = parseInt(countlabel.text()) + 1;

        img.removeClass("gray");
        countlabel.text(newValue);
        countinput.val(newValue);
    });

    $(".filter").click(function () {
        let filterName = $(this).attr('id');
        let filterType = $(this).attr('type');
        if ($(this).hasClass("gray")) {
            $("." + filterName).removeClass("displayNone" + filterType);
            $(this).removeClass("gray");
        }
        else {
            $("." + filterName).addClass("displayNone" + filterType);
            $(this).addClass("gray");
        }
    });

    $("[type='availability']").click(function () {
        let filterName = $(this).attr('id');
        let filterType = $(this).attr('type');

        if (filterName == "check") {
            $(this).removeClass("gray");
            $("#cross").addClass("gray");
            $(".card-img.gray").parent().addClass("displayNone" + filterType);
        }
        else {
            $(this).removeClass("gray");
            $("#check").addClass("gray");
            $(".card-img").parent().removeClass("displayNone" + filterType);
        }
    });

    $("[type='screen']").click(function () {
        let filterName = $(this).attr('id');

        if (filterName == "full") {
            $(this).removeClass("gray");
            $("#small").addClass("gray");
            $("#cardList").removeClass("container-xxl");
            $("#cardList").addClass("container-fluid");
        }
        else {
            $(this).removeClass("gray");
            $("#full").addClass("gray");
            $("#cardList").removeClass("container-fluid");
            $("#cardList").addClass("container-xxl");
        }
    });
})