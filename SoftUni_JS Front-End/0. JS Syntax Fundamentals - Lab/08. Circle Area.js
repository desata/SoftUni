function solve(input) {
    let result = '';

if(typeof input == 'number')
result = (Math.pow(input, 2) * Math.PI).toFixed(2);

else 
result = `We can not calculate the circle area, because we receive a ${typeof input}.`;
   
    console.log(result);
}

solve(5)
solve(2)
solve(10)