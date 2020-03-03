function printUniqueWords(input) {
    let words = [];
    for (let j = 0; j < input.length; j++) {
        let data = input[j].toLowerCase().match(/\w+/gim);
        for (let i = 0; i < data.length; i++) {
            if (!words.includes(data[i])) {
                words.push(data[i])
            }
        }
    }
    console.log(words.join(', '))
}

printUniqueWords(['Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Pellentesque quis hendrerit dui.',
    'Quisque fringilla est urna, vitae efficitur urna vestibulum fringilla.',
    'Vestibulum dolor diam, dignissim quis varius non, fermentum non felis.',
    'Vestibulum ultrices ex massa, sit amet faucibus nunc aliquam ut.',
    'Morbi in ipsum varius, pharetra diam vel, mattis arcu.',
    'Integer ac turpis commodo, varius nulla sed, elementum lectus.',
    'Vivamus turpis dui, malesuada ac turpis dapibus, congue egestas metus.']
)