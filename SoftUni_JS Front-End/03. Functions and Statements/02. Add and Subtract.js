function solve(a, b, c) {
    let result;

    let sum = (a, b) => a + b;
    let subtract = (a, b) => a - b;

    result = subtract(sum(a, b), c);

    console.log(result);
}

solve(23, 6, 10);
solve(1, 17, 30);
solve(42, 58, 100);