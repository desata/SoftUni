function solve(string) {
    let result = string[0];
    for (let i = 1; i < string.length; i++) {
        let letter = string[i];
        if (letter.charCodeAt(0) >= 65 && letter.charCodeAt(0) <= 90) {
            result += ', ';
        }
        result += string[i];
    }
    console.log(result);
}

solve('AsdAs');
solve('SplitMeIfYouCanHaHaYouCantOrYouCan');
solve('HoldTheDoor');
solve('ThisIsSoAnnoyingToDo');

/*
You will receive a single string. 
This string is written in PascalCase format. 
Your task here is to split this string by every word in it. 
Print them joined by comma and space.
 */