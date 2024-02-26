function solve(number) {
    let textNumber = number.toString();
    let areEqual = true;
    let currentDigit = textNumber[0];
    let sum = Number(currentDigit);

    for (let i = 1; i < textNumber.length; i++) {
        if (currentDigit !== textNumber[i]){
            areEqual=false;
        }

        currentDigit = textNumber[i];
        sum += Number(currentDigit);
    }
    console.log(areEqual);
    console.log(sum);
}

solve(22222227);