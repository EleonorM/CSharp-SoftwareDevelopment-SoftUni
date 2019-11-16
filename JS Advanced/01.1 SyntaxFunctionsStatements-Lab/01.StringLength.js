function stringLength(...words) {
    let length = words.reduce((a, b) => a + b.length, 0);
    let avg = Math.floor(length / words.length);
    console.log(length);
    console.log(avg);
}

stringLength('chocolate', 'ice cream', 'cake')