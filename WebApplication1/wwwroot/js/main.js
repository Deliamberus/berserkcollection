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
    });

    $(".plus").click(function () {
        let countlabel = $(this).siblings('label.count');
        let idinput = $(this).siblings('input.idcard');
        let img = $(this).siblings('img');
        let newValue = parseInt(countlabel.text()) + 1;

        img.removeClass("gray");
        countlabel.text(newValue);
        saveCard(idinput.val(), newValue);
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

        if (filterName == "have") {
            $(this).removeClass("gray");
            $("#all").addClass("gray");
            $(".card-img.gray").parent().addClass("displayNone" + filterType);
        }
        else {
            $(this).removeClass("gray");
            $("#have").addClass("gray");
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
})