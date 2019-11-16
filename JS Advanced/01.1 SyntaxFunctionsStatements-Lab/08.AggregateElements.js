function printAggregateFunc(numbers) {
    let sum = numbers.reduce((a,b) => a + b, 0);
    let sum2 = numbers.reduce((a,b) => a + 1/b, 0);
    let concat = numbers.reduce((a,b) => a + b ,"");
    console.log(sum);
    console.log(sum2);
    console.log(concat);
}

printAggregateFunc([1, 2, 3])