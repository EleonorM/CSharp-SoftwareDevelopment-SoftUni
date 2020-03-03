function countWords(input) {
    let data = input[0]
        .match(/\w+/gm);
    let stored = {};
    for (i = 0; i < data.length; i++) {
        if (!stored.hasOwnProperty(data[i])) {
            stored[data[i]] = 0;
        }
        stored[data[i]]++;
    }
    
    console.log(JSON.stringify(stored))
}

countWords(['JS devs use Node.js for server-side JS.-- JS for devs'])