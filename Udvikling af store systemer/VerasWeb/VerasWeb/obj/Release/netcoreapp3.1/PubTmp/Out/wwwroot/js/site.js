// For search
$(document).ready(function () {
    function handleEnter(e) {
        if (e.which === 13) {
            // enter pressed
            var searchKeyWord = $("#searchTextBox").val();
            if (searchKeyWord.length !== 10) {
                Swal.fire({
                    title: 'Ikke gyldig CPR-nummer',
                    text: 'CPR-nummeret skal være i tal: xxxxxxxxxx',
                    icon: 'warning',
                    confirmButtonText: 'Prøv igen'
                });
                return false;
            }
            window.location.href = "/customer/" + searchKeyWord;
            return false;

        }
    }



    $("#searchTextBox").keypress(handleEnter);

    //Log in the user
    $("#loginUser").click(function () {
        $("#loginUser").text("Logger ind...");
    });

    //Create user
    $("#createUser").click(function () {
        $("#createUser").text("Opretter...");
    });

    //Create customer
    $("#createCustomerBtn").click(function () {
        $("#createCustomer").text("Opretter...");
    });

    //Update customer
    $("#updateCustomerBtn").click(function () {
        $("#updateCustomer").text("Opdaterer...");
    });

});

