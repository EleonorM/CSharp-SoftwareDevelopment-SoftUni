function sumIncomeOfTown(...input) {
    let data = input[0];
    let stored = [];
    for (i = 0; i < data.length; i += 2) {
        if (!stored.some(e => e.key === [data[i]])) {
            stored[data[i]] = 0;
        }
        stored[data[i]] += Number(data[i + 1]);
    }
    console.log()
}

sumIncomeOfTown(['Sofia', '20', 'Varna', '3', 'Sofia', '5', 'Varna', '4'])