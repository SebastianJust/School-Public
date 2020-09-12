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



    $(document).keypress(handleEnter);
    $("#searchTextBox").keypress(handleEnter);


    //Create customer
    $("#createCustomerBtn").click(function () {
        $("#createCustomer").text("Opretter...");
    });

    //Update customer
    $("#updateCustomerBtn").click(function () {
        $("#updateCustomer").text("Opdaterer...");
    });

});

