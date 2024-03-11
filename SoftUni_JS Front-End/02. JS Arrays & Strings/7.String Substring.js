function solve(word, text){
   
    let words = text.toLowerCase().split(' ');
    
    let result= words.includes(word.toLowerCase());

    if(result){
        console.log(word);
return;
    } else {
console.log(`${word} not found!`);
    }
}

solve('javascript','JavaScriptdddd is the best programming language');

solve('python','JavaScript is the best programming language');