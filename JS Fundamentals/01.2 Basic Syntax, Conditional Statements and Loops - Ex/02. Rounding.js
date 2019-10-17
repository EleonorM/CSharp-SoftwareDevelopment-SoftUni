function round(num, precision){
let result;
if(precision > 15)
result = num.toFixed(15)
else
result = num.toFixed(precision)
console.log(parseFloat(result))
}

round(10.5,3)