function solve(groupCount, groupType, day) {
    let price;
    let singlePrice;

    if (groupType == "Students") {
        if (day == "Friday") {
            singlePrice = 8.45;
        }
        else if (day == "Saturday") {
            singlePrice = 9.80;
        }
        else if (day == "Sunday") {
            singlePrice = 10.46;
        }
        
        if (groupCount >= 30) {
        singlePrice = singlePrice*0.85;
        }
        
    }
    else if (groupType == "Business") {
        if (day == "Friday") {
            singlePrice = 10.90;
        }
        else if (day == "Saturday") {
            singlePrice = 15.60;
        }
        else if (day == "Sunday") {
            singlePrice = 16;
        }
        if (groupCount >= 100) {
            groupCount -= 10;
            }
    }
    else if (groupType == "Regular") {
        if (day == "Friday") {
            singlePrice = 15;
        }
        else if (day == "Saturday") {
            singlePrice = 20;
        }
        else if (day == "Sunday") {
            singlePrice = 22.50;
        }
        if (groupCount >= 10 && groupCount <= 20) {
            singlePrice = singlePrice*0.95;
            }

    }
    price=singlePrice*groupCount;
    console.log(`Total price: ${price.toFixed(2)}`);
}

solve(30, "Students", "Sunday");
solve(40, "Regular", "Saturday");