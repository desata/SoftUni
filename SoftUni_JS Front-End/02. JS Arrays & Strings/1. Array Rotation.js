function solve(arr, x) {
    let n = arr.length;
 
    // if x is greater than length 
    // of the array
    x = x % n;
 
    let first_x_elements = arr.slice(0, x);
 
    let remaining_elements = arr.slice(x, n);
 
    // Destructuring to create the desired array
    arr = [...remaining_elements, ...first_x_elements];
 
    console.log(arr);
}

solve([51, 47, 32, 61, 21], 2);
solve([32, 21, 61, 1], 4);
solve([2, 4, 15, 31], 5);