function solve(arr) {
    let even = 0;
    let odd = 0;
    for (let i = 0; i < arr.length; i++) {
        arr[i] = Number(arr[i])
        if (arr[i] % 2 === 0) {
            even += arr[i];
        }
        else {
            odd += arr[i];
        }
    }

    let output = even - odd;
    console.log(output);
}

solve([1, 2, 3, 4, 5, 6]);
solve([3, 5, 7, 9]);
solve([2, 4, 6, 8, 10]);

/*
Write a program that calculates the difference between 
the sum of the even and the sum of the odd numbers in an array.*/
