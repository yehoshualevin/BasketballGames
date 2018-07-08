$(() => {
    $("#max-people").on('change', setButtonValidity);
    $("#date").on('change', setButtonValidity);

    function setButtonValidity() {
        $("#submit-button").prop('disabled', !isFormValid());
    }

    function isFormValid() {
        const maxPeople = $("#max-people").val();
        const date = $("#date").val();
        return maxPeople && date;
    }

})


