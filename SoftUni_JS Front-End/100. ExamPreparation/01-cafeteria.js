function manageCafe(input) {
    let baristas = {};

    // Function to update barista details
    function updateBarista(name, shift, drinks) {
        if (!baristas.hasOwnProperty(name)) {
            baristas[name] = { shift: shift, drinks: drinks };
        } else {
            baristas[name].shift = shift;
            baristas[name].drinks = drinks;
        }
    }

    // Function to prepare coffee
    function prepareCoffee(name, shift, coffeeType) {
        if (baristas.hasOwnProperty(name) && baristas[name].shift === shift && baristas[name].drinks.includes(coffeeType)) {
            console.log(`${name} has prepared a ${coffeeType} for you!`);
        } else {
            console.log(`${name} is not available to prepare a ${coffeeType}.`);
        }
    }

    // Function to change shift
    function changeShift(name, newShift) {
        if (baristas.hasOwnProperty(name)) {
            baristas[name].shift = newShift;
            console.log(`${name} has updated his shift to: ${newShift}`);
        }
    }

    // Function to learn new coffee type
    function learnCoffeeType(name, newCoffeeType) {
        if (baristas.hasOwnProperty(name) && !baristas[name].drinks.includes(newCoffeeType)) {
            baristas[name].drinks.push(newCoffeeType);
            console.log(`${name} has learned a new coffee type: ${newCoffeeType}.`);
        } else {
            console.log(`${name} knows how to make ${newCoffeeType}.`);
        }
    }

    // Parse input
    let n = parseInt(input.shift());
    for (let i = 0; i < n; i++) {
        let [name, shift, drinks] = input.shift().split(' ');
        drinks = drinks.split(',');
        updateBarista(name, shift, drinks);
    }

    // Process commands
    for (let command of input) {
        let [action, name, ...args] = command.split(' / ');
        if (action === 'Prepare') {
            prepareCoffee(name, ...args);
        } else if (action === 'Change Shift') {
            changeShift(name, ...args);
        } else if (action === 'Learn') {
            learnCoffeeType(name, ...args);
        } else if (action === 'Closed') {
            break;
        }
    }

    // Output barista details
    for (let name in baristas) {
        let { shift, drinks } = baristas[name];
        console.log(`Barista: ${name}, Shift: ${shift}, Drinks: ${drinks.join(', ')}`);
    }
}

// Example usage
let input = [
    '3',
    'Alice day Espresso,Cappuccino',
    'Bob night Latte,Mocha',
    'Carol day Americano,Mocha',
    'Prepare / Alice / day / Espresso',
    'Change Shift / Bob / night',
    'Learn / Carol / Latte',
    'Learn / Bob / Latte',
    'Prepare / Bob / night / Latte',
    'Closed'
];

manageCafe(input);
