function solve(input) {
  const baristasCount = Number(input.shift());
  const barista = {};

  for (let i = 0; i < baristasCount; i++) {
    const [name, shift, skills] = input[i].split(" ");

    barista[name] = { shift, skills: skills.split(",") };
  }

  let command = input.shift();

  while (command != "Closed") {
    const [task, name, argumentOne, argumentTwo] = command.split(" / ");
    let shift, coffeeType;
    let currentBarista = barista[name];

    switch (task) {
      case "Prepare":
        shift = argumentOne;
        coffeeType = argumentTwo;
        if (currentBarista.shift === shift && currentBarista.skills.includes(coffeeType)) {
          console.log(`${name} has prepared a ${coffeeType} for you!`);
        } else {
          console.log(`${name} is not available to prepare a ${coffeeType}.`);
        }
        break;
      case "Change Shift":
        shift = argumentOne;
        if (currentBarista.shift != shift) {
          currentBarista.shift = shift;
        }
        console.log(`${name} has updated his shift to: ${shift}`);
        break;
      case "Learn":
        coffeeType = argumentOne;
        if (currentBarista.skills.includes(coffeeType)) {
          console.log(`${name} knows how to make ${coffeeType}.`);
        }
        else {
            barista[name].skills.push(coffeeType);
            console.log(`${name} has learned a new coffee type: ${coffeeType}.`);
        }
        break;
    }

    command = input.shift();
  }

  for (const name in barista) {
    let {shift, skills} = barista[name];
    console.log(`Barista: ${name}, Shift: ${shift}, Drinks: ${skills.join(', ')}`);
  }  
}

solve(['4',
'Alice day Espresso,Cappuccino',
'Bob night Latte,Mocha',
'Carol day Americano,Mocha',
'David night Espresso',
'Prepare / Alice / day / Espresso',
'Change Shift / Bob / day',
'Learn / Carol / Latte',
'Prepare / Bob / night / Latte',
'Learn / David / Cappuccino',
'Prepare / Carol / day / Cappuccino',
'Change Shift / Alice / night',
 'Learn / Bob / Mocha',
'Prepare / David / night / Espresso',
'Closed']
);
