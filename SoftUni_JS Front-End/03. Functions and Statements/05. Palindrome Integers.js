//A palindrome is a number, which reads the same backward as forward, such as 323 or 1001. 
//Write a function, which receives an array of positive integers and checks if each integer is a palindrome or not.
//true or false

function isPalindrome(numbers){
    let nums = numbers.splice(',');
    let revNum;

    for( let num of nums){
        let numText = num.toString();
        revNum = numText.split("").reverse().join("");
        if(num == revNum) {
            console.log('true');
        } else {
            console.log('false');
        }
    }    

    // function reverseNumber(number){
    //     while(number > 0){
    //     let digit = number % 10;
        
    //     number = (number / 10) - digit*0.1;
    //     }
    // }

}

isPalindrome([123,323,421,121])
isPalindrome([32,2,232,1010])

