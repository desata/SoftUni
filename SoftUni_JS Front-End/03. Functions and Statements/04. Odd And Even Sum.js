//You will receive a single number. 
//You have to write a function, that returns the sum of all even and all odd digits from that number. 

function solve(number) {
    let odds = 0;
    let evens = 0;

    while (number > 0) {
        let digit = number % 10;
        isEven(digit) ? evens += digit : odds += digit;
        number = (number / 10) - digit*0.1;
    }
    function isEven(digit){
        return number % 2 === 0
    }
    console.log(`Odd sum = ${odds}, Even sum = ${evens}`);

}

solve(1000435);
solve(3495892137259234);