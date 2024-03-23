function solve(stock, order) {
    const store = {};

    for (let i = 0; i < stock.length; i += 2) {
        const product = stock[i];
        const qty = Number(stock[i+1]);

        store[product] = qty;
    }

    for (let i = 0; i < order.length; i += 2) {
        const product = order[i];
        const qty = Number(order[i+1]);

        if(!store[product])
        {
            store[product] = 0;
        }
        store[product] += qty;
    }

    for (const product in store) {
        console.log(`${product} -> ${store[product]}`);
    }
}

solve([
    'Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'
],
    [
        'Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30'
    ]
);