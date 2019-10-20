function printIfNumberIsSpecial(number) {
    for (let i = 1; i <= number; i++) {
        var value = i
        sum = 0;

        while (value) {
            sum += value % 10;
            value = Math.floor(value / 10);
        }

        if (sum === 5 || sum === 7 || sum === 11)
            console.log(`${i} -> ${True}`);
        else
            console.log(`${i} -> ${False}`);
    }
}