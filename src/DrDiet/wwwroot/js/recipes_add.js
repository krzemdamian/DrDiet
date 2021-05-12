////const newProductRow = $('#newProductRow');
//const ingredientsTable = $('#ingredients_table');
let productsCount = 1;

function update_kcals(name = "[-1]") {

    const number = name.split('[')[1].split(']')[0];

    const selectedKcalPerKilo =
        $('.available_products')[number].selectedOptions[0].attributes.data.value;
    //const selectedKcalPerKilo =
    //    event.element.selectedOptions[0].attributes.data.value;
    const amountInputValue = $('.weight_in_grams')[number].value;
    const updatedKcals = amountInputValue * selectedKcalPerKilo / 1000;

    const kcalInputElement = $('.kcals')[number];
    kcalInputElement.value = updatedKcals;

    const kcalsSum = Object.values($('.kcals')).filter(a => a.value).map(i => i.valueAsNumber).reduce((a, c) => a + c);
    $('#kcal_info')[0].innerText = `${kcalsSum.toFixed(0)} kcal`;
}

function addIngredientRow() {
    const clone = $('#ingredients_table_body').children('#newProductRow').clone();
    const productselectName = 'ingredients[' + productsCount + '].Product.Id';
    const weightInputName = 'ingredients[' + productsCount + '].Ammount';

    clone.find('.available_products')[0].name = productselectName;
    clone.find('.weight_in_grams')[0].name = weightInputName;
    clone.find('.available_products')[0].value = 0;
    clone.find('.weight_in_grams')[0].value = 0;

    $('#ingredients_table_body').append(clone[0]);

    productsCount++;
}
