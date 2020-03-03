function findDivisor(firstNum, secondNum){
    while(secondNum !== 0){
        let temp = secondNum;
        secondNum = firstNum % secondNum;
        firstNum = temp;        
    }
    return firstNum;
};

console.log(findDivisor(15, 5));
console.log(findDivisor(2154, 458));