$(document).ready(function () {
    $(document).on("change", "input[id$='IsInfoElementChecked']", updateTotalAndApplyButton);

});



function updateTotalAndApplyButton() {
    var total = 0;

    $("#infoElementsTable > tbody > tr").each(function () {

        if ($(this).find(":nth-child(1) > input[type='checkbox']").is(":checked")) {
            var quantity = $(this).find(":nth-child(6) > span").text();
            if (quantity == '') quantity = 0;

            total += parseInt(quantity);
        }
    })
  
    $("#totalQuantityLabel").text(total);

    var anyChecked = $("input[id$='IsInfoElementChecked']").is(function () { return this.checked; });
    $("#applyInfoElementsButton").prop("disabled", !anyChecked);
}