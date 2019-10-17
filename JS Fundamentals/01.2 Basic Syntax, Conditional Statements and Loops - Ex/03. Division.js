function divisible(num) {
    let devisor;
    if (num % 10 === 0)
        deivsor = 10;
    else if (num % 7 === 0)
        deivsor = 7;
    else if (num % 6 === 0)
        deivsor = 6;
    else if (num % 3 === 0)
        deivsor = 3;
    else if (num % 2 === 0)
        deivsor = 2;
    else {
        console.log(`Not divisible`)
        return;
    }
    console.log(`The number is divisible by ${deivsor}`)
}

divisible(1643)