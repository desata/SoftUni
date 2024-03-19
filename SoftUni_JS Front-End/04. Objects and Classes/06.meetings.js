function solve(input) {
    const meetings = {};

    for(let record of input){
        let [day, name] = record.split(' ');

        if(Object.keys(meetings).includes(day)){
            console.log(`Conflict on ${day}!`);
        }else {
        meetings[day] = name;
        console.log(`Scheduled for ${day}`);
        }
    }

    for(let record in meetings) {
        console.log(`${record} -> ${meetings[record]}`);
    }

}

solve(['Friday Bob',
'Saturday Ted',
'Monday Bill',
'Monday John',
'Wednesday George']
);

solve(['Monday Peter',
'Wednesday Bill',
'Monday Tim',
'Friday Tim']
);