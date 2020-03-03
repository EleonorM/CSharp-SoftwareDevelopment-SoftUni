//@ts-check

function printPopulation(input) {
    let towns = {};

    input.forEach(line => {
        let [name, quantity] = line.split(' <-> ');
        quantity = Number(quantity);

        if (!towns.hasOwnProperty(name)){
            towns[name] = 0
        }
        towns[name] += quantity
    });

    var keys = Object.keys(towns);
    for(let name of keys){
        let population = towns[name];

        console.log(`${name} : ${population}`)
    }
}

printPopulation(['Istanbul <-> 100000',
'Honk Kong <-> 2100004',
'Jerusalem <-> 2352344',
'Mexico City <-> 23401925',
'Istanbul <-> 1000']

)