$(function init_datetimepicker() {
    const picker = $('#my-datetimepicker');
    picker.datetimepicker({
        format: 'DD.MM.YYYY H:mm',
        stepping: 30 //minute step
    });
});

function update_kcals_courses(name = "[-1]") {
    const number = parseInt(name.split('[')[1].split(']')[0]) + 1;

    const selectedKcalPerKilo =
        $('.available_recipes')[number].selectedOptions[0].attributes.data.value;
    const amountInputValue = $('.weight_in_grams_courses')[number].value;
    const updatedKcals = amountInputValue * selectedKcalPerKilo / 1000;

    const kcalInputElement = $('.kcals_courses')[number];
    kcalInputElement.value = updatedKcals;

    const kcalsSum = Object.values($('.kcals')).filter(a => a.value).map(i => i.valueAsNumber).reduce((a, c) => a + c);
    $('#kcal_info')[0].innerText = `${kcalsSum.toFixed(0)} kcal`;
}

function update_kcals_ingredients(name = "[-1]") {
    const number = parseInt(name.split('[')[1].split(']')[0]) + 1;

    const selectedKcalPerKilo =
        $('.available_products')[number].selectedOptions[0].attributes.data.value;
    const amountInputValue = $('.weight_in_grams_ingredients')[number].value;
    const updatedKcals = amountInputValue * selectedKcalPerKilo / 1000;

    const kcalInputElement = $('.kcals_ingredients')[number];
    kcalInputElement.value = updatedKcals;

    const kcalsSum = Object.values($('.kcals')).filter(a => a.value).map(i => i.valueAsNumber).reduce((a, c) => a + c);
    $('#kcal_info')[0].innerText = `${kcalsSum.toFixed(0)} kcal`;
}

let coursesCount = 0;
function addCourseRow() {
    const clone = $('#menu-components-table-body').children('#new-course-row').clone();
    clone[0].removeAttribute('id');
    clone[0].classList.add('new-course');
    const recipeIdInputName = 'courses[' + coursesCount + '].Recipe.Id';
    const weightInputName = 'courses[' + coursesCount + '].Ammount';

    clone.find('.available_recipes')[0].name = recipeIdInputName;
    clone.find('.weight_in_grams_courses')[0].name = weightInputName;
    clone.find('.available_recipes')[0].value = 0;
    clone.find('.weight_in_grams_courses')[0].value = 0;
    clone.find('button')[0].addEventListener('click', deleteCourseRow, false);

    clone.show();
    $('#menu-components-table-body').append(clone[0]);

    coursesCount++;
}

let ingredientsCount = 0;
function addIngredientRow() {
    const clone = $('#menu-components-table-body').children('#new-ingredient-row').clone();
    clone[0].removeAttribute('id');
    clone[0].classList.add('new-ingredient');

    const productselectName = 'otherProducts[' + ingredientsCount + '].Product.Id';
    const weightInputName = 'otherProducts[' + ingredientsCount + '].Ammount';
    clone.find('.available_products')[0].name = productselectName;
    clone.find('.weight_in_grams_ingredients')[0].name = weightInputName;
    clone.find('.available_products')[0].value = 0;
    clone.find('.weight_in_grams_ingredients')[0].value = 0;
    clone.find('button')[0].addEventListener('click', deleteIngredientRow, false);

    clone.show();
    $('#menu-components-table-body').append(clone[0]);

    ingredientsCount++;
}

function deleteCourseRow() {
    this.parentElement.parentElement.remove();

    coursesCount = 0;
    const newCourses = $('.new-course');
    for (let course of newCourses) {
        const recipeIdInputName = 'courses[' + coursesCount + '].Recipe.Id';
        const weightInputName = 'courses[' + coursesCount + '].Ammount';

        var courseWrapped = $(course);
        courseWrapped.find('.available_recipes')[0].name = recipeIdInputName;
        courseWrapped.find('.weight_in_grams_courses')[0].name = weightInputName;
        coursesCount++;
    }
}

function deleteIngredientRow() {
    this.parentElement.parentElement.remove();

    ingredientsCount = 0;
    const newCourses = $('.new-ingredient');
    for (let course of newCourses) {
        const productSelectName = 'otherProducts[' + ingredientsCount + '].Product.Id';
        const weightInputName = 'otherProducts[' + ingredientsCount + '].Ammount';
        var courseWrapped = $(course);
        courseWrapped.find('.available_products')[0].name = productSelectName;
        courseWrapped.find('.weight_in_grams_ingredients')[0].name = weightInputName;
        ingredientsCount++;
    }
}
