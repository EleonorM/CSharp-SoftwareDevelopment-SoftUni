function fruit(fruit, weight, money) {
    let weightInKg = (weight / 1000);
    let totalPrrice = (money * weightInKg).toFixed(2);
    return `I need $${totalPrrice} to buy ${weightInKg.toFixed(2)} kilograms ${fruit}.`;
}

console.log(fruit('orange', 2500, 1.80))
