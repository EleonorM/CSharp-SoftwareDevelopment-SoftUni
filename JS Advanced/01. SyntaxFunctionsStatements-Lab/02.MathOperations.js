function mathOperation(number1, number2, operand){
    let result = eval(`${number1} ${operand} ${number2}`);

    console.log( result);
}

mathOperation(5, 6, '+')