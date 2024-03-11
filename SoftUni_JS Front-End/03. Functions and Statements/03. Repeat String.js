function stringRepeater(string, countN){
    let result = '';
    for(let i=0; i<countN;i++){
        result+=string;
    }
    console.log(result);
}
stringRepeater('abc',3);
stringRepeater('String',2);