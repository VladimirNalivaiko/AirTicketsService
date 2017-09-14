var flightClicked = false;
var ticketClicked = false;
var userClicked = false;

var flightClick = function (event) {
    $.ajax({
        type: 'POST',
        url: '/Flight/GetFlightsToAdminJson',
        dataType: "json",
        success: function (data) {
            if (data) {
                console.log(data);
                var len = data.length;
                var txt = "";
                if (len > 0) {
                    if (!flightClicked) {
                        for (var i = 0; i < len; i++) {
                            if (data[i].ID && data[i].DeparturePlace && data[i].ArrivalPlace
                                && data[i].Price && data[i].DepartureDate && data[i].NumOfFreeSeats) {
                                var re = /-?\d+/;
                                var m = re.exec(data[i].DepartureDate);
                                var date = new Date(parseInt(m));
                                txt += "<tr><td>" +
                                    data[i].ID + "</td><td>" +
                                    data[i].DeparturePlace + "</td><td>" +
                                    data[i].ArrivalPlace + "</td><td>" +
                                    data[i].Price + "</td><td>" +
                                    formatDate(date) + "</td><td>" +
                                    data[i].NumOfFreeSeats + "</td></tr>";                                
                            }                     
                        }
                    }
                    if (txt != "" || flightClicked) {

                        forFlightHide();

                        if (!flightClicked) {
                            $("#flights-table").append(txt);
                            flightClicked = true;
                        }
                        $("#flights-table-header").show();
                        $("#flights-table").show();
                        $("#create-flight-admin-btn").show();
                    }
                }
                else {
                    $("#no-flights").show();

                    forFlightHide();
                }
            }
        }
    });
}

var forFlightHide = function () {
    $("#tickets-table").hide();
    $("#users-table").hide();

    $("#users-table-header").hide();
    $("#tickets-table-header").hide();

    $("#no-tickets").hide();
    $("#no-users").hide();
};

var ticketClick = function (event) {
    $.ajax({
        type: 'POST',
        url: '/Ticket/GetTicketsToAdminJson',
        dataType: "json",
        success: function (data) {
            console.log(data);
            if (data) {
                var len = data.length;
                var txt = "";
                console.log(data);
                if (len > 0) {
                    if (!ticketClicked) {
                        for (var i = 0; i < len; i++) {
                            if (data[i].ID && data[i].DeparturePlace && data[i].ArrivalPlace
                                && data[i].DepartureDate && data[i].Name && data[i].SurName
                                && data[i].PassportNumber && data[i].PhoneNumber
                                && data[i].Email && data[i].SeatNumber) {
                                var re = /-?\d+/;
                                var m = re.exec(data[i].DepartureDate);
                                var date = new Date(parseInt(m));
                                txt += "<tr><td>" +
                                    data[i].ID + "</td><td>" +
                                    data[i].DeparturePlace + "</td><td>" +
                                    data[i].ArrivalPlace + "</td><td>" +
                                    formatDate(date) + "</td><td>" +
                                    data[i].SurName + " " + data[i].Name.charAt(0).toUpperCase() + "." + "</td><td>" +
                                    data[i].PassportNumber + "</td><td>" +
                                    data[i].PhoneNumber + "</td><td>" +
                                    data[i].Email + "</td><td>" +
                                    data[i].SeatNumber + "</td></tr>";

                                console.log("Date in func: " + data[i].DepartureDate + data[i].DepartureTime);
                            }
                        }
                    }
                    if (txt != "" || ticketClicked) {
                        forTicketHide();

                        if (!ticketClicked) {
                            $("#tickets-table").append(txt);
                            ticketClicked = true;
                        }
                        $("#tickets-table-header").show();
                        $("#tickets-table").show();
                    }
                }
                else {
                    $("#no-tickets").show();

                    forTicketHide();    
                }
            }
        }
    });
}

var forTicketHide = function () {
    $("#flights-table").hide();
    $("#users-table").hide();

    $("#flights-table-header").hide();
    $("#create-flight-admin-btn").hide();
    $("#users-table-header").hide();

    $("#no-flights").hide();
    $("#no-users").hide();
};

var userClick = function (event) {
    $.ajax({
        type: 'POST',
        url: '/Account/GetUserListToAdminJson',
        dataType: "json",
        success: function (data) {
            if (data) {
                var len = data.length;
                var txt = "";
                if (len > 0) {
                    if (!userClicked) {
                        for (var i = 0; i < len; i++) {
                            if (data[i].ID && data[i].Email && data[i].Roles) {
                                txt += "<tr><td>" +
                                    data[i].ID + "</td><td>" +
                                    data[i].Email + "</td><td>" +
                                    data[i].Roles + "</td></tr>";
                            }
                        }
                    }
                    if (txt != "" || userClicked) {
                        forUserHide();

                        if (!userClicked) {
                            $("#users-table").append(txt);
                            userClicked = true;
                        }

                        $("#users-table-header").show();
                        $("#users-table").show();
                    }
                }
                else {
                    $("#no-users").show();

                    forUserHide();
                }
            }
        }
    });
}

var forUserHide = function () {
    $("#flights-table").hide();
    $("#tickets-table").hide();

    $("#flights-table-header").hide();
    $("#create-flight-admin-btn").hide();
    $("#tickets-table-header").hide();

    $("#no-tickets").hide();
    $("#no-flights").hide();
};

var formatDate = function (date) {
    console.log(date);

    var d = new Date();
    d.setTime(date);

    var mn = d.getMinutes();
    if (mn < 10) mn = '0' + mn;

    var hh = d.getHours();
    if (hh < 10) hh = '0' + hh;

    var dd = d.getDate();
    if (dd < 10) dd = '0' + dd;

    var mm = d.getMonth() + 1;
    if (mm < 10) mm = '0' + mm;

    var yy = d.getFullYear() % 100;
    if (yy < 10) yy = '0' + yy;

    return dd + '.' + mm + '.' + yy + ' ' + hh + ':' + mn;
}

