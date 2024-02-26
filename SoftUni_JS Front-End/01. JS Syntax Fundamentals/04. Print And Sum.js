function solve (start, end){
    let result = 0;
    let numbers = '';

    for(let i = start; i <= end; i++) {
        result += i;
        numbers += i + ' ';
    }

    console.log(numbers);
    console.log(`Sum: ${result}`);
}

solve(5, 10)