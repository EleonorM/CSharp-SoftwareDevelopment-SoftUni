function sumAllOddNumbers(num){
    let sum=0;
    let counter=0;
    let numberToIncrease = 1;
   while(counter!= num){
        sum += numberToIncrease;      
        console.log(numberToIncrease);
        counter++;
        numberToIncrease+=2;
    }
    console.log(`Sum: ${sum}`)
}

sumAllOddNumbers(3)