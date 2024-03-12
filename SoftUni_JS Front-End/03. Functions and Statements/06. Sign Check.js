function checkNegative(numOne, numTwo, numThree) {
    let result = 'Positive';

    const multiply = (a, b) => a * b;

    if(multiply((multiply(numOne, numTwo)), numThree) < 0){
        result = 'Negative'
    }

    console.log(result);
}

checkNegative(5, -12, 15);
checkNegative(-6, -12, 14);
checkNegative(-1, -2, -3);
checkNegative(-5, 1, 1);