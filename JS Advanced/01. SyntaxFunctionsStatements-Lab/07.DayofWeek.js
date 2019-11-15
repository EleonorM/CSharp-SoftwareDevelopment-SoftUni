function printDayOfWeek(dayOfWeek) {
    let numberDay = 0;
    switch (dayOfWeek) {
        case "Monday":
            numberDay = 1;
            break;
        case "Tuesday":
            numberDay = 2;
            break;
        case "Wednesday":
            numberDay = 3;
            break;
        case "Thursday":
            numberDay = 4;
            break;
        case "Friday":
            numberDay = 5;
            break;
        case "Saturday":
            numberDay = 6;
            break;
        case "Sunday":
            numberDay = 7;
            break;
        default:
            console.log("error");
            return;
    }

    console.log(numberDay);
}

printDayOfWeek("Friday")