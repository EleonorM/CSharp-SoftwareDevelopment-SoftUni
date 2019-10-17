function findPlace(str, char, result) {
    let stringReplace = str.replace('_', char);
    let output = stringReplace === result ? 'Matched' : 'Not Matched';
    console.log(output);
    
}

findPlace('Str_ng', 'i', 'String')