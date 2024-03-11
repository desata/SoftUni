function calculateTotalPrice(product, qty){
    let singlePrice;
//coffee, coke, water, snacks
    if(product == 'coffee'){
        singlePrice = 1.50
    }
    else if(product == 'coke'){
        singlePrice = 1.40
    }
    else if(product == 'water'){
        singlePrice = 1.00
    }
    else if(product == 'snacks'){
        singlePrice = 2.00
    }

    console.log((singlePrice*qty).toFixed(2));
}
calculateTotalPrice("water", 5);
calculateTotalPrice("coffee", 2);