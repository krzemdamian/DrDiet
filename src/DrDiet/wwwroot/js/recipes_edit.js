let initialKcalSum;

function update_kcals() {
    if (typeof(initialKcalSum) === 'undefined')
        initialKcalSum = parseFloat($('#kcal_info')[0].innerText.replace(' kcal', ''));

    const selectedKcalPerKilo =
        $('#available_products')[0].selectedOptions[0].attributes.data.value;
    const amountInputValue = $('#weight_in_grams')[0].value;
    const updatedKcals = amountInputValue * selectedKcalPerKilo / 1000;

    const kcalInputElement = $('#kcals')[0];
    kcalInputElement.value = updatedKcals;

    const kcalsSum = initialKcalSum + updatedKcals;
    $('#kcal_info')[0].innerText = `${kcalsSum.toFixed(0)} kcal`;
}

function enableRename() {
    $('#recipe_name').hide();
    $('#rename_recipe').hide();
    $('#rename_form').show();
    $('#cancel_rename').show();
}

function disableRename() {
    $('#recipe_name').show();
    $('#rename_recipe').show();
    $('#rename_form').hide();
    $('#cancel_rename').hide();
}

function enableInstructionsEdit() {
    $('#instructions').hide();
    $('#enable_instructions_edit_button').hide();
    $('#edit_instructions_form').show();
    $('#cancel_edit_instructions').show();
}

function disableInstructionsEdit() {
    $('#instructions').show();
    $('#enable_instructions_edit_button').show();
    $('#edit_instructions_form').hide();
    $('#cancel_edit_instructions').hide();
}