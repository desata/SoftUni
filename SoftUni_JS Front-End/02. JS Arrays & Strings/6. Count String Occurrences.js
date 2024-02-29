//Write a function that receives a text and a single word that you need to search. 
//Print the number of all occurrences of this word in the text.
function solve(text, neededWord){
    let words = text.split(' ');
    let counter = 0;
    for(let word of words){
        if(word == neededWord)
        counter++;
    }
    console.log(counter);
}


solve('This is a word and it also is a sentence', 'is');
solve('softuni is great place for learning new programming languages', 'softuni');