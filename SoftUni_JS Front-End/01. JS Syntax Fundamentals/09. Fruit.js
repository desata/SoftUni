function solve(fruit, weightInKilo, pricePerKilo) {
    let money;
    weight = (weightInKilo / 1000);
    money = weight * pricePerKilo;
    console.log(`I need $${money.toFixed(2)} to buy ${weight.toFixed(2)} kilograms ${fruit}.`);
}

solve('orange', 2500, 1.80)
solve('apple', 1563, 2.35)
