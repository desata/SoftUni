function solve(array, rotateNums) {
    let result = '';

    if(rotateNums >= array.length){
        rotateNums = rotateNums % array.length
    }
    for (let i = rotateNums; i< array.length; i++){
        result += array[i] + ' ';
        } 

        for (let i = 0; i< rotateNums; i++){
            result += array[i] + ' ';
        }
        console.log(result);
}

solve([51, 47, 32, 61, 21], 62);
solve([32, 21, 61, 1], 4);
solve([2, 4, 15, 31], 5);


