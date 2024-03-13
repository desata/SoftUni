function solve(charA, charB) {
    let firstChar = getASCII(charA);
    let secondChar = getASCII(charB);
    let result = '';

    if (firstChar > secondChar) {
        printChar(secondChar, firstChar);
    } else {
        printChar(firstChar, secondChar);
    }

    function printChar(a, b) {
        for (let i = a + 1; i < b; i++) {
            var char = String.fromCharCode(i);
            result += char + ' ';
        }
    }

    function getASCII(a){
       return a.charCodeAt(0);
    }

    console.log(result);
}

solve('a', 'n')
solve('C', '#')