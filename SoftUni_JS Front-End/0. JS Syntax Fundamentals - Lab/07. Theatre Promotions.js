function solve(day, age) {
    let result = '';

if(age>=0 && age <= 18){
    if(day == 'Weekday')
    result = '12$';
    else if (day == 'Weekend')
    result = '15$';
    else if (day == 'Holiday')
    result = '5$';
}
else if(age>18 && age <= 64){
    if(day == 'Weekday')
    result = '18$';
    else if (day == 'Weekend')
    result = '20$';
    else if (day == 'Holiday')
    result = '12$';
}
else if(age>64 && age <= 122){
    if(day == 'Weekday')
    result = '12$';
    else if (day == 'Weekend')
    result = '15$';
    else if (day == 'Holiday')
    result = '10$';
}
else 
result = 'Error!'


   
    console.log(result);
}

solve('Weekday', -2);