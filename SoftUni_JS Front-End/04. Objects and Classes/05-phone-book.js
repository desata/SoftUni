function solve(input) {
    const phoneBook = {};

    for(let key of input){
        let [name, phone] = key.split(' ');

        phoneBook[name] = phone;
    }

    for(let record in phoneBook){
        console.log(`${record} -> ${phoneBook[record]}`);
    }
}

solve(['Tim 0834212554',
'Peter 0877547887',
'Bill 0896543112',
'Tim 0876566344']
)