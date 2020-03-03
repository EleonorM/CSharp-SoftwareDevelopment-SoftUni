function cookByNumber(elements) {
    let spice = (num) => num / 2;
    let bake = (num) => num / 2;
    let fillet = (num) => num / 2;
    let functions =
    {
        chop: (x) => x / 2,
        dice: (x) => Math.sqrt(x),
        spice: (x) => x + 1,
        bake: (x) => x * 3,
        fillet: (x) => 0.8 * x,
    }
    let number = parseInt(elements[0]);
    for (let i = 1; i < elements.length; i++) {
        number = functions[elements[i]](number);
        console.log(number)
    }
}

console.log(cookByNumber(['32', 'chop', 'chop', 'chop', 'chop', 'chop']));
console.log(cookByNumber(['9', 'dice', 'spice', 'chop', 'bake', 'fillet']));