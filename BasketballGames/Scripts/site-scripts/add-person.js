$(() => {
    $("#name").on('keyup', setButtonValidity);
    $("#email").on('keyup', setButtonValidity);

    function setButtonValidity() {
        $("#submit-button").prop('disabled', !isFormValid());
    }

    function isFormValid() {
        const email = isValidEmail($("#email").val())
        const name = $("#name").val();
        return name && email;
    }


    function isValidEmail(email) {
        var re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return re.test(email);
    }
})