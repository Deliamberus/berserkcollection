$(function () {
    $(".minus").click(function () {
        let countlabel = $(this).siblings('label.count');
        let idinput = $(this).siblings('input.idcard');
        let img = $(this).siblings('img');
        let newValue = parseInt(countlabel.text()) - 1;

        if (newValue <= 0) {
            newValue = 0;
            img.addClass("gray");
        }

        countlabel.text(newValue);
        saveCard(idinput.val(), newValue);
        checkVisible(this, newValue);
    });

    $(".plus").click(function () {
        let countlabel = $(this).siblings('label.count');
        let idinput = $(this).siblings('input.idcard');
        let img = $(this).siblings('img');
        let newValue = parseInt(countlabel.text()) + 1;

        img.removeClass("gray");
        countlabel.text(newValue);
        saveCard(idinput.val(), newValue);
        checkVisible(this, newValue);
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

        $("[type='availability']").addClass("gray");
        $(this).removeClass("gray");
        if (filterName == "have") {
            $(".more").removeClass("displayNoneavailability");
            $(".set").removeClass("displayNoneavailability");
            $(".less").removeClass("displayNoneavailability");
            $(".card-img.gray").parent().addClass("displayNoneavailability");
        }
        else if (filterName == "all") {
            $(".card-img").parent().removeClass("displayNoneavailability");
        }
        else if (filterName == "less") {
            $(".less").removeClass("displayNoneavailability");
            $(".more").addClass("displayNoneavailability");
            $(".set").addClass("displayNoneavailability");
        }
        else if (filterName == "more") {
            $(".more").removeClass("displayNoneavailability");
            $(".less").addClass("displayNoneavailability");
            $(".set").addClass("displayNoneavailability");
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

    $('.card-img').click(function () {
        $("#myModal").css("display", "flex");
        $("#modalImg").attr("src", $(this).attr("src"));
    });

    // Закрываем модальное окно если клик был не по изображению внутри модального окна
    $("#myModal").click(function (event) {
        $("#myModal").css("display", "none");
    });

    function saveCard(id, count) {
        const dataToSend = {
            Id: Number(id),
            Count: Number(count)
        };

        $.ajax({
            url: '/Collection/SaveCard',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(dataToSend),
            success: function (response) {
                console.log(response);
            },
            error: function (error) {
                console.error('Error:', error);
            }
        });
    };

    function checkVisible(element, count) {
        let card = $(element).parent()
        let isHorde = card.hasClass("ishorde");

        if (count < 3 || (count < 5 && isHorde)) {
            card.removeClass("set");
            card.removeClass("more");
            card.addClass("less");
            if (!$("#more").hasClass("gray") || (!$("#have").hasClass("gray") && count == 0)) {
                card.addClass("displayNoneavailability");
            }
        }
        else if ((count > 3 && !isHorde) || (count > 5 && isHorde)) {
            card.removeClass("set");
            card.removeClass("less");
            card.addClass("more");
            if (!$("#less").hasClass("gray")) {
                card.addClass("displayNoneavailability");
            }
        }
        else {
            card.removeClass("more");
            card.removeClass("less");
            card.addClass("set");
            if (!$("#less").hasClass("gray") || !$("#more").hasClass("gray")) {
                card.addClass("displayNoneavailability");
            }
        }
    }
})