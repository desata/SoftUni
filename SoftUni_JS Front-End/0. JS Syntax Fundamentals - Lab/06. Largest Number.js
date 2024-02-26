function solve(number1, number2, number3) {
    let result;

    if (number1>=number2 && number1 >= number3)
    result = number1;
else if (number2>=number1 && number2>=number3)
result = number2;
else result = number3
   
    console.log(`The largest number is ${result}.`);
}

solve(5, -3, 16);
solve(5, 5, 16);
solve(-3, -5, -22.5);
solve(5, 5, 5);