function findCalorieObject(elements) {
    // return elements.reduce((acc,x,i,arr)=>{
    //     if (i % 2 === 0) {
    //         acc[x] = undefined;
    //     }
    //     else{
    //         acc[arr[i-1]] = x;
    //     }
    //     return acc;
    // },{})
    let result = {};
    for (let i = 0; i < elements.length; i+=2) {
       result[elements[i]] = parseInt(elements[i+1]);        
    }
    
    return result;
}

console.log(findCalorieObject(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']));

console.log(findCalorieObject(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42']));