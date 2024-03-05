function solve(text){
    let regEx = /#([a-zA-Z]+)/g;

    let results = text.matchAll(regEx);

    for (const result of results) {
        console.log(`${result[1]}`);
    }
}

solve('The symbol # is known #variously in English-speaking #regions as the #number sign');