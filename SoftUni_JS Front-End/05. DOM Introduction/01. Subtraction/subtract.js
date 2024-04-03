function subtract() {
    const firstNumberElement = document.getElementById('firstNumber').value;
    const secondNumberElement = document.getElementById('secondNumber').value;
    const resultElement = document.getElementById('result');

    let results =  Number(firstNumberElement) - Number(secondNumberElement);
    resultElement.textContent = results;
}