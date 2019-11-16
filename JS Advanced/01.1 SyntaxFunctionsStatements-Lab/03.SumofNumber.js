function sumOfNumbers(minNumber, maxNumber) {
    let result = 0;
    for (i = Number(minNumber); i <= Number(maxNumber); i++) {
        result += i;
    }
    console.log(result);
}

sumOfNumbers('-8', '15' )