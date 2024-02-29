function solve(text, word) {
    let censored = text.replace(word, repeat(word))

    while (censored.includes(word))
    censored = censored.replace(word, repeat(word));

    function repeat(word) {        

        return word.replace(/./g, '*');
    }
    console.log(censored);
}

solve('A small sentence with some words', 'small');
solve('Find the hidden hidden word', 'hidden');