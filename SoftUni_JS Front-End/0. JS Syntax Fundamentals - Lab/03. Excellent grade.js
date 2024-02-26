function solve(number) {
    let grade = '';
    if (number >= 5.50)
        grade = 'Excellent'
    else
        grade = 'Not excellent'
    console.log(grade);
}

solve(5.50);
solve(4.35);