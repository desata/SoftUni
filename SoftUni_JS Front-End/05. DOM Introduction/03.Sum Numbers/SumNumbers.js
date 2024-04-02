function calc() {
    // TODO: sum = num1 + num2

    const inputItemOne = document.getElementById('num1');
    const inputItemTwo = document.getElementById('num2');
    const ItemSum = document.getElementById('sum');

    const firstNumber = Number(inputItemOne.value);
    const secondNumber = Number(inputItemTwo.value);

    ItemSum.value = firstNumber + secondNumber;
}
