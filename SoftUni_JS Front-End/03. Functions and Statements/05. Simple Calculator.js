function calculateResult(numOne, numTwo, operator) {
    const operation = getOperator(operator)

    const result = operation(numOne, numTwo);
    console.log(result);

    function getOperator(operator) {
        switch (operator) {
            case 'multiply':
                return (a, b) => a * b;
            case 'divide':
                return (a, b) => a / b;
            case 'add':
                return (a, b) => a + b;
            case 'subtract':
                return (a, b) => a - b;
        }
    }
}

calculateResult(5, 5, 'multiply');
calculateResult(40, 8, 'divide');
calculateResult(12, 19, 'add');
calculateResult(50, 13, 'subtract');