var dep_suggest_count = 0;
var dep_input_initial_value = '';
var dep_suggest_selected = 0;
var dep_city_hover = false;

var arr_suggest_count = 0;
var arr_input_initial_value = '';
var arr_suggest_selected = 0;
var arr_city_hover = false;

$(document).ready(function () {
    $('#departure_place_flight').keyup(function (event) {
        switch (event.keyCode) {
            case 13:  // enter
            case 27:  // escape
            case 38:  // стрелка вверх
            case 40:  // стрелка вниз
                break;
            default: {
                var searchQuery = $('#departure_place_flight').val();
                $.ajax({
                    type: 'POST',
                    url: '/City/GetCities',
                    data: { "subString": searchQuery },
                    dataType: "json",
                    success: function (data) {
                        if (data.length !== 0 && searchQuery !== '') {
                            dep_suggest_count = data.length;
                            $('#departure_place_flight_wrapper').empty();
                            $("#departure_place_flight_wrapper").show();
                            for (var i in data) {
                                $('#departure_place_flight_wrapper').append('<div class="advice_variant">' + data[i].Name + '</div>');
                            }
                        }
                        if (searchQuery === '') {
                            dep_suggest_count = 0;
                            $("#departure_place_flight_wrapper").hide();
                        }
                    }
                })
            }
        }
    });

    $("#departure_place_flight_wrapper").hover(function () {
        dep_city_hover = true;
        $('#departure_place_flight_wrapper div').eq(dep_suggest_selected - 1).removeClass('active');
    });

    $("#departure_place_flight_wrapper").mouseleave(function () {
        console.log("kek");
        dep_city_hover = false;
    });

    $("#departure_place_flight_wrapper").on("click", ".advice_variant", function () {
        $('#departure_place_flight').val($(this).text());
        $('#departure_place_flight_wrapper').fadeOut(350).hide();
    });

    $('html').click(function () {
        $('#departure_place_flight_wrapper').hide();
    });

    $("#departure_place_flight").keydown(function (I) {
        switch (I.keyCode) {
            // по нажатию клавишь прячем подсказку
            case 13: // enter
            case 27: // escape
                $('#departure_place_flight_wrapper').hide();
                return false;
                break;
                // делаем переход по подсказке стрелочками клавиатуры
            case 38: // стрелка вверх
            case 40: // стрелка вниз
                I.preventDefault();
                if (dep_suggest_count && !dep_city_hover) {
                    //делаем выделение пунктов в слое, переход по стрелочкам
                    departure_key_activate(I.keyCode - 39);
                }
                break;
        }
    });

    $('#arrival_place_flight').keyup(function (event) {
        switch (event.keyCode) {
            case 13:  // enter
            case 27:  // escape
            case 38:  // стрелка вверх
            case 40:  // стрелка вниз
                break;
            default: {
                var searchQuery = $('#arrival_place_flight').val();
                $.ajax({
                    type: 'POST',
                    url: '/City/GetCities',
                    data: { "subString": searchQuery },
                    dataType: "json",
                    success: function (data) {
                        if (data.length !== 0 && searchQuery !== '') {
                            arr_suggest_count = data.length;
                            $('#arrival_place_flight_wrapper').empty();
                            $("#arrival_place_flight_wrapper").show();
                            for (var i in data) {
                                $('#arrival_place_flight_wrapper').append('<div class="advice_variant">' + data[i].Name + '</div>');
                            }
                        }
                        if (searchQuery === '') {
                            arr_suggest_count = 0;
                            $("#arrival_place_flight_wrapper").hide();
                        }
                    }
                })
            }
        }
    });

    $("#arrival_place_flight_wrapper").hover(function () {
        arr_city_hover = true;
        $('#arrival_place_flight_wrapper div').eq(arr_suggest_selected - 1).removeClass('active');
    });

    $("#arrival_place_flight_wrapper").mouseleave(function () {
        console.log("kek");
        arr_city_hover = false;
    });

    $("#arrival_place_flight_wrapper").on("click", ".advice_variant", function () {
        $('#arrival_place_flight').val($(this).text());
        $('#arrival_place_flight_wrapper').fadeOut(350).hide();
    });

    $('html').click(function () {
        $('#arrival_place_flight_wrapper').hide();
    });

    $("#arrival_place_flight").keydown(function (I) {
        switch (I.keyCode) {
            // по нажатию клавишь прячем подсказку
            case 13: // enter
            case 27: // escape
                $('#arrival_place_flight_wrapper').hide();
                return false;
                break;
                // делаем переход по подсказке стрелочками клавиатуры
            case 38: // стрелка вверх
            case 40: // стрелка вниз
                I.preventDefault();
                if (arr_suggest_count && !arr_city_hover) {
                    //делаем выделение пунктов в слое, переход по стрелочкам
                    arrival_key_activate(I.keyCode - 39);
                }
                break;
        }
    });


});

var departure_key_activate = function (n) {
    $('#departure_place_flight_wrapper div').eq(dep_suggest_selected - 1).removeClass('active');

    if (n == 1 && dep_suggest_selected < dep_suggest_count) {
        dep_suggest_selected++;
    } else if (n == -1 && dep_suggest_selected > 0) {
        dep_suggest_selected--;
    }

    if (dep_suggest_selected > 0) {
        $('#departure_place_flight_wrapper div').eq(dep_suggest_selected - 1).addClass('active');
        $("#departure_place_flight").val($('#departure_place_flight_wrapper div').eq(dep_suggest_selected - 1).text());
    } else {
        $("#departure_place_flight").val(dep_input_initial_value);
    }
}

var arrival_key_activate = function (n) {
    $('#arrival_place_flight_wrapper div').eq(arr_suggest_selected - 1).removeClass('active');

    if (n == 1 && arr_suggest_selected < arr_suggest_count) {
        arr_suggest_selected++;
    } else if (n == -1 && arr_suggest_selected > 0) {
        arr_suggest_selected--;
    }

    if (arr_suggest_selected > 0) {
        $('#arrival_place_flight_wrapper div').eq(arr_suggest_selected - 1).addClass('active');
        $("#arrival_place_flight").val($('#arrival_place_flight_wrapper div').eq(arr_suggest_selected - 1).text());
    } else {
        $("#arrival_place_flight").val(arr_input_initial_value);
    }
}