function findTimeToWalk(steps, stepLenght, speed) {
    let length = (stepLenght * steps);
    let totalRestInMinutes = Math.floor(length / 500);
    let totalTime = length / speed / 1000 * 60;
    let totalTimeInSeconds = Math.ceil((totalRestInMinutes + totalTime) * 60);
    let result = new Date(null, null, null, null, null, totalTimeInSeconds);
    return (result.toTimeString().split(' ')[0]);
}

console.log(findTimeToWalk(4000, 0.60, 5));
console.log(findTimeToWalk(2564, 0.70, 5.5));