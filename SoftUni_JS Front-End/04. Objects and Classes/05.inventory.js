function solve(input) {
    const heroes = [];

    for (const row of input) {
        const [name, level, items] = row.split(' / ');
        const hero = {
            name,
            items,
            level: Number(level),
        };

        heroes.push(hero);
    }

    heroes.sort((a, b) => a.level - b.level);

    for (const hero of heroes) {
        console.log(`Hero: ${hero.name}`);
        console.log(`level => ${hero.level}`);
        console.log(`items => ${hero.items}`);
    }
}

function fancySolve(input) {
    input
        .map(row => row.split(' / '))
        .map(([name, level, items]) => ({
            name,
            items,
            level: Number(level),
        }))
        .sort((a, b) => a.level - b.level)
        .forEach(hero => {
            console.log(`Hero: ${hero.name}`);
            console.log(`level => ${hero.level}`);
            console.log(`items => ${hero.items}`);
        })
}

fancySolve([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
]
);
