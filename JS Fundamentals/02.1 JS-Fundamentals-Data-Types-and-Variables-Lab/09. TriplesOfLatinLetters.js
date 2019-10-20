function printTripletsOfLetters(num) {
    let numChar = String.fromCharCode(97 + num);

    for (let i = 97; i < 97 + num; i++) {
        let result = [String.fromCharCode(i)];
        for (let i = 97; i < 97 + num; i++) {
            result.push(String.fromCharCode(i));
            for (let i = 97; i < 97 + num; i++) {
                result.push(String.fromCharCode(i));

                console.log(result[0]+result[1]+result[2]);
                result.pop();
            }

            result.pop();
        }
    }
}

printTripletsOfLetters(3)