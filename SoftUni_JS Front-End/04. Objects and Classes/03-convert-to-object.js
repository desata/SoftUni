function solve(jsonData){
    let data = JSON.parse(jsonData);

    Object.keys(data).forEach(key => console.log(`${key}: ${data[key]}`));
}
solve('{"name": "George", "age": 40, "town": "Sofia"}');