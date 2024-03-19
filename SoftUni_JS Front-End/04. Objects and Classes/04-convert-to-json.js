function solve(firstName, lastName, hairColor ){
    let person = {
        name: firstName, 
        lastName, 
        hairColor,
    };

    console.log(JSON.stringify(person));
}

solve('George', 'Jones', 'Brown')