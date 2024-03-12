function getSmallestNumber(a, b, c) {
    const compare = (a, b) => a < b ? a : b;
    let result = compare(compare(a, b), c);
    console.log(result);
}

getSmallestNumber(2, 5, 3);
getSmallestNumber(600, 342, 123);
getSmallestNumber(25, 21, 4);
getSmallestNumber(2, 2, 2);