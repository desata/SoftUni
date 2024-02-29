/*Write a function that receives a string and two numbers. 
The numbers will be a starting index and count of elements to substring.
Print the result. */

function solve(string, startIndex, count){   
    console.log(string.substring(startIndex, startIndex+count));
}

solve('ASentence', 1, 8);
solve('SkipWord', 4, 7);