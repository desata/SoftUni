function solve (speed, area){
    let speedLimit = 0;
    let output = '';
    let status = '';
    let difference = 0;

    if(area == 'motorway'){
        speedLimit = 130;        
    }
    else if (area == 'interstate'){
        speedLimit = 90;        
    }
    else if (area == 'city'){
        speedLimit = 50;        
    }
    else if (area == 'residential'){
        speedLimit = 20;        
    }

    difference = speed - speedLimit;

    if(difference <= 0){
        output = `Driving ${speed} km/h in a ${speedLimit} zone`;
    }
    else {
        if(difference <= 20){
            status = 'speeding';
        }
        else if(difference <= 40){
            status = 'excessive speeding';
        }
        else if(difference > 40 ){
            status = 'reckless driving';
        }
        output = `The speed is ${difference} km/h faster than the allowed speed of ${speedLimit} - ${status}`;
    }

    console.log(output);

}

solve(40, 'city');
solve(21, 'residential');
solve(120, 'interstate');