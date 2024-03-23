function solve(input) {
    const towns = [];

    for (const line of input) {
        let [name, latitude, longitude] = line.split(" | ");
        const town = {
            name: name,
            latitude: latitude,
            longitude: longitude
        }
        towns.push(town);
    }
    for (const town of towns) {
        console.log(`{ town: '${town.name}', latitude: '${Number(town.latitude).toFixed(2)}', longitude: '${Number(town.longitude).toFixed(2)}' }`);
    }    
}


solve(['Sofia | 42.696552 | 23.32601',
    'Beijing | 39.913818 | 116.363625']
);

//You’re tasked to create and print objects from a text table.
//You will receive the input as an array of strings, where each string represents a table row, with values on the row separated by pipes " | " and spaces.
//The table will consist of exactly 3 columns "Town", "Latitude" and "Longitude".The latitude and longitude columns will always contain valid numbers.
//Check the examples to get a better understanding of your task.
//The output should be objects.Latitude and longitude must be parsed to numbers and formatted to the second decimal point!

// for (let key of input) {
//     let [name, phone] = key.split(' ');

//     phoneBook[name] = phone;
// }

// for (let record in phoneBook) {
//     console.log(`${record} -> ${phoneBook[record]}`);
// }

// { town: 'Sofia', latitude: '42.70', longitude: '23.33' }