function printTripletsOfLetters(num) {
    for (let i = 0; i < num; i++) {
        let letter1 = String.fromCharCode(97 + i);
        for (let j = 0; j < num; j++) {
            let letter2 = String.fromCharCode(97 + j);
            for (let k = 0; k < num; k++) {

                let letter3 = String.fromCharCode(97 + k);
                console.log(letter1 + letter2 + letter3);
            }
        }
    }
}

function tripplesOfLatinLetters(num) {
    for (let n = 0; n < num; n++) {
        let letter1 = String.fromCharCode(97 + n);
        for (let y = 0; y < num; y++) {
            let letter2 = String.fromCharCode(97 + y);
            for (let j = 0; j < num; j++) {
                let letter3 = String.fromCharCode(97 + j);
                console.log(letter1 + letter2 + letter3);
            }

        }
    }
}

printTripletsOfLetters(3)