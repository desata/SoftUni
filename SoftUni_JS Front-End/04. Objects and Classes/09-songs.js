function solve(input){
    class Songs {
        constructor(typeList, name, time){
            this.typeList = typeList, 
            this.name = name, 
            this.time = time
        }
    }

    const arrayInput = input.map(line => line.split(','));
    let n = arrayInput[0];

    console.log(n);
}

solve([3,
    'favourite_DownTown_3:14',
    'favourite_Kiss_4:16',
    'favourite_Smooth Criminal_4:01',
    'favourite']);
