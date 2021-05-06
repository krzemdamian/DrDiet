let currentProductEditId;

function show_edit_form(id, name, energy_kcal_per_100g) {
    unhideCurrentlyEditedRow();

    currentProductEditId = id;

    const elementId = `#${id}`;
    const productRow = $(elementId);
    productRow.hide();
    const editForm = $('#edit_product_row');
    editForm.show();
    $('#edit_product_id')[0].value = id;
    $('#edit_product_name')[0].value = name;
    const energyField = $('#edit_product_energy')[0];
    energyField.value = energy_kcal_per_100g;
    energyField.focus();

    editForm.show();
}

function cancel_edit() {
    //unhideCurrentlyEditedRow();

    const elementId = `#${currentProductEditId}`;
    const productRow = $(elementId);

    for (let button of $('edit_button')) {
        button.show();
    }

    $('#edit_product_row').hide();

    productRow.show();
}

function unhideCurrentlyEditedRow() {
    const currentElementId = `#${currentProductEditId}`;
    const currentProductRow = $(currentElementId);
    currentProductRow.show();
}
