function solve(arrayOfNumbers) {
    let sortedArray = arrayOfNumbers.sort((a, b) => a - b);
    let result = [];
    while (sortedArray.length > 0) {

       // let firstNumber = 
        result.push(sortedArray.shift());
        result.push(sortedArray.pop());
    }

        console.log(result);
}

/*
Write a function that sorts an array of numbers so that the first element is the smallest one, the second is the biggest one, the third is the second smallest one, the fourth is the second biggest one, and so on. 
Return the resulting array.
 */

solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]);