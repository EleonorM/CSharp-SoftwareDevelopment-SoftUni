function calculateBitcoin(...numbers) {
    numbers = numbers[0];
    let counter = 0;
    let money = 0;
    let bitcoins = 0;
    let day = 0;
    let bitcoinPrice = 11949.16;
    let goldPerGramPrice = 67.51;
    while (counter < numbers.length) {
        let goldDigged = numbers[counter];
        if ((counter + 1) % 3 === 0) {
            goldDigged -= goldDigged * 0.3;
        }
        money += goldDigged * goldPerGramPrice;
        if (money > bitcoinPrice) {
            if (day === 0)
                day = counter + 1;
            let bitcoinsToBuy = ~~(money / bitcoinPrice);
            money -= bitcoinsToBuy * bitcoinPrice;
            bitcoins += bitcoinsToBuy
        }

        counter++;
    }
    console.log(`Bought bitcoins: ${bitcoins}`)
    if (day !== 0)
        console.log(`Day of the first purchased bitcoin: ${day}`)
    console.log(`Left money: ${money.toFixed(2)} lv.`);

}

calculateBitcoin([50, 100])

