function passwordAutentificator(...input) {
    input = input[0];
    let username = input[0];
    let splitString = username.split("");
    let reverseArray = splitString.reverse();
    var password = reverseArray.join("");
    for (let i = 1; i < input.length; i++) {

        if (password === input[i]) {
            console.log(`User ${username} logged in.`);
        }
        else if (i === 4) {
            console.log(`User ${username} blocked!`);
        }
        else
            console.log(`Incorrect password. Try again.`);
    }
}

passwordAutentificator(['sunny','rainy','cloudy','sunny','not sunny'])