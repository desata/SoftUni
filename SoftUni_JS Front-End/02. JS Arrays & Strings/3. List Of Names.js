function solve(arrayOfNames){
    let sortedNames = arrayOfNames.sort((a, b) => a.localeCompare(b));

    for (let i = 0; i < sortedNames.length; i++) {
    console.log(`${i+1}.${sortedNames[i]}`);
    }
}

/*
You will receive an array of names. Sort them alphabetically in ascending order and print a numbered list of all the names, each on a new line.
*/

solve(["John", "boya", "Bob", "Christina", "Ema"]);