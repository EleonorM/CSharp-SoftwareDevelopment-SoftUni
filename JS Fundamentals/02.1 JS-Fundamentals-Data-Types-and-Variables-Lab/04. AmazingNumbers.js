function findIfAmazing(num) {
    let numAsStr = num.toString();
    let sum = 0;
    for (i = 0; i < numAsStr.length; i++) {
        sum += Number(numAsStr[i]);
    }
    let result = sum.toString().includes('9');
    console.log(`${numAsStr} Amazing? ${result ? 'True' : 'False'}`);

}

findIfAmazing(1233)