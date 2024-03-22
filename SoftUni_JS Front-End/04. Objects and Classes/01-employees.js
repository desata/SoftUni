function solve(input) {
    const employees = [];

    for (const record of input) {
        const employee = {
            name: record,
            personalNum: record.length,
        }
        employees.push(employee);
    }

    for (const employee of employees) {
        console.log(`Name: ${employee.name} -- Personal Number: ${employee.personalNum}`)
    }

}

solve([
    'Silas Butler',
    'Adnaan Buckley',
    'Juan Peterson',
    'Brendan Villarreal'
]
);