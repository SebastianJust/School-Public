$(document).ready(function () {
    $("#calculateFeet").click(function (e) {
        document.getElementById("calculateFeet").innerHTML = 'Calculating..';
        e.preventDefault();
        var settings = {
            url: '/Api/feetInches/0',
            type: 'post',
            "content-Type": "application/json",
            data: $('#feetForm').serialize(),
        }

        $.ajax(settings).done(function (resp) {
            document.getElementById("calculateFeet").innerHTML = "Calculate";
            console.log(resp);
            document.getElementById("resultCompleted").innerHTML = resp;
            document.getElementById("resultErr").innerHTML = "";


        }).fail(function (err) {
            document.getElementById("calculateFeet").innerHTML = "Try again";

            console.log("Failed...");
            console.log(err);
            document.getElementById("resultErr").innerHTML = err.responseText;
            document.getElementById("resultCompleted").innerHTML = "";

        });
    });

    $("#calculateInches").click(function (e) {
        console.log("Calculating inches...")
        document.getElementById("calculateInches").innerHTML = 'Calculating..';
        e.preventDefault();
        var settings = {
            url: '/Api/feetInches/1',
            type: 'post',
            "content-Type": "application/json",
            data: $('#inchesForm').serialize(),
        }

        $.ajax(settings).done(function (resp) {
            document.getElementById("calculateInches").innerHTML = "Calculate";
            console.log(resp);
            document.getElementById("resultCompleted").innerHTML = resp;
            document.getElementById("resultErr").innerHTML = "";


        }).fail(function (err) {
            document.getElementById("calculateInches").innerHTML = "Try again";

            console.log("Failed...");
            console.log(err);
            document.getElementById("resultErr").innerHTML = err.responseText;
            document.getElementById("resultCompleted").innerHTML = "";

        });
    });


});

