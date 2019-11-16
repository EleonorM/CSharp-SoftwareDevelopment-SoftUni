function findLargestNumber(...numbers){
    let maxNumber = Math.max(...numbers);
    console.log(`The largest number is ${maxNumber}.`);
}

findLargestNumber(5, -3, 16)