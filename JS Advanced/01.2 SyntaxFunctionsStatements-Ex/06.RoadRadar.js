function findIsInSpeedLimit(elements) {
    let limits = {
        motorway: 130,
        interstate: 90,
        city: 50,
        residential: 20,
    }
    let speed = parseInt(elements[0]);
    let type = elements[1];

    let overLimit = speed - limits[type];

    if (overLimit <= 0) {
        return '';
    }
    else if (overLimit <= 20) {
        return 'speeding';
    }
    else if (overLimit <= 40) {
        return 'excessive speeding';
    }
    else if (overLimit>40){
        return 'reckless driving';
    }
}

console.log(findIsInSpeedLimit([40, 'city']))
console.log(findIsInSpeedLimit([21, 'residential']))
console.log(findIsInSpeedLimit([120, 'interstate']))
console.log(findIsInSpeedLimit([200, 'motorway']))