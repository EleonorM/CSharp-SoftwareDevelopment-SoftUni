function calculateFuelMoney(distance, passengers, priceForLiter) {
    let neededFuel = (distance / 100) * 7;
    neededFuel += passengers * 0.1;
    let money = neededFuel * priceForLiter;
    console.log(`Needed money for that trip is ${money}lv.`);    
}