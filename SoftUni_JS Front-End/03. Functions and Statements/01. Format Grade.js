function formatFrade(grade){
    if(grade < 3.00){
        console.log('Fail (2)');
    }
    else if(grade < 3.50){
        console.log(`Poor (${grade.toFixed(2)})`);
    }
    else if(grade < 4.50){
        console.log(`Good (${grade.toFixed(2)})`);
    }
    else if(grade < 5.50){
        console.log(`Very good (${grade.toFixed(2)})`);
    }
    else if(grade < 6.00){
        console.log(`Excellent (${grade.toFixed(2)})`);
    }
}

formatFrade(3.33);
formatFrade(4.54554450);
formatFrade(2.99);
formatFrade(5.99);