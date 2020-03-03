function findSameNumber(num) {
    let numCollection = num.toString().split('');
    let allTrue = true;
    let sum = 0;
    for (let i = 0; i < numCollection.length; i++) {
        if (allTrue) {
            allTrue = numCollection[i] === numCollection[0];
        }

        sum += +numCollection[i];
    }

    console.log(allTrue);
    console.log(sum);
}

console.log(findSameNumber(2222222));
console.log(findSameNumber(1234));