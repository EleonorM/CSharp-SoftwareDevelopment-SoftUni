function calculateArea(input) {
    let typeOfInput = typeof (input);
    if (typeOfInput === 'number') {
        let area = Math.pow(input, 2) * Math.PI;
        console.log(area.toFixed(2))
    }
    else {
        console.log(`We can not calculate the circle area, because we receive a ${typeOfInput}.`)
    }
}

calculateArea(5)