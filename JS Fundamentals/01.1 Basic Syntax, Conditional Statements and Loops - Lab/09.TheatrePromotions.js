function calculateTicket(typeOfDay, age) {
    let money;
    if (age >= 0 & age <= 18) {
        switch (typeOfDay) {
            case 'Weekday':
                money = 12;
                break;
            case 'Weekend':
                money = 15;
                break;
            case 'Holiday':
                money = 5;
                break;
            default:
                money = 'Error!'
                break;
        }
    }
    else if (age <= 64 & age > 18) {
        switch (typeOfDay) {
            case 'Weekday':
                money = 18;
                break;
            case 'Weekend':
                money = 20;
                break;
            case 'Holiday':
                money = 12;
                break;
            default:
                money = 'Error!'
                break;
        }
    }
    else if (age <= 122 & age > 64) {
        switch (typeOfDay) {
            case 'Weekday':
                money = 12;
                break;
            case 'Weekend':
                money = 15;
                break;
            case 'Holiday':
                money = 10;
                break;
            default:
                money = 'Error!'
                break;
        }
    }
    else {
        money = 'Error!'
        console.log(money)
        return;
    }

    console.log(money + '$')
}

calculateTicket('Holiday', -12)