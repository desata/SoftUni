function solve(number1, number2, sign) {
    let result;
    switch(sign){
        case '+': result = number1 + number2; break;
        case '-': result = number1 - number2; break;
        case '*': result = number1 * number2; break;
        case '/': result = number1 / number2; break;
        case '%': result = number1 % number2; break;
        case '**': result = number1 ** number2; break;
    }
   
    console.log(result);
}

solve(5, 6, '+');
solve(3, 5.5, '*');
solve(1, 2, '**');