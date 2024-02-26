function solve(number, action1, action2, action3, action4, action5) {
    let result = Number(number);
    let action = [];
    action.push(action1, action2, action3, action4, action5);

    for (let i = 0; i < 5; i++) {

        if (action[i] == 'chop') {
            result /= 2;
        }
        else if (action[i] == 'dice') {
            result = Math.sqrt(result);
        }
        else if (action[i] == 'spice') {
            result++;
        }
        else if (action[i] == 'bake') {
            result *= 3;
        }
        else if (action[i] == 'fillet') {
            result *= 0.8;
        }
        console.log(result.toFixed(1));
    }
}

solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet');