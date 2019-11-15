function convertWordsUppercase(str) {
    let result = str.match(/\w+/gim).map(x => x.toUpperCase()).join(", ");
    console.log(result);
}

convertWordsUppercase('Hi, how are you?')