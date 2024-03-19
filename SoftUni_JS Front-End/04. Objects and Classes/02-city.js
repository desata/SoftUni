function getCity(city){
    Object.keys(city)
    .forEach(propertyName => 
        console.log(`${propertyName} -> ${city[propertyName]}`));

}


getCity({
    name: "Sofia",
    area: 492,
    population: 1238438,
    country: "Bulgaria",
    postCode: "1000"
})
getCity({
    name: "Plovdiv",
    area: 389,
    population: 1162358,
    country: "Bulgaria",
    postCode: "4000"
})
