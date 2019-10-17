function calculateVacation(numOfPeople, typeOfGroup, dayOfWeek) {
    let moneyPerPerson;
    switch (typeOfGroup) {
        case 'Students':
            if (dayOfWeek == 'Friday')
                moneyPerPerson = 8.45
            else if (dayOfWeek == 'Saturday')
                moneyPerPerson = 9.8;
            else if (dayOfWeek == 'Sunday')
                moneyPerPerson = 10.46
            break;
        case 'Business':
            if (dayOfWeek == 'Friday')
                moneyPerPerson = 10.9
            else if (dayOfWeek == 'Saturday')
                moneyPerPerson = 15.6;
            else if (dayOfWeek == 'Sunday')
                moneyPerPerson = 16
            break;
        case 'Regular':
            if (dayOfWeek == 'Friday')
                moneyPerPerson = 15
            else if (dayOfWeek == 'Saturday')
                moneyPerPerson = 20;
            else if (dayOfWeek == 'Sunday')
                moneyPerPerson = 22.5
            break;
        default:
            break;
    }
    let price = numOfPeople * moneyPerPerson;
    if (typeOfGroup == 'Students' & numOfPeople >=30) {
        price -= price*0.15;        
    }
    else if (typeOfGroup == 'Business' & numOfPeople >=100) {
        price -= 10 * moneyPerPerson;
    }
    else if (typeOfGroup == 'Regular' & numOfPeople >=10 & numOfPeople <= 20) {
        price -= price*0.05;  
    }
    console.log(`Total price: ${price.toFixed(2)}`)
}
