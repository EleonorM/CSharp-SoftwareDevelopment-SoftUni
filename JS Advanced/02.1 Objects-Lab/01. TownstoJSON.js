//@ts-check

function convertToJson(input) {
    function convertInputToArray(input2) {
        return input2
            .split("|")
            .filter(x => x !== "")
            .map(x => x.trim())
            .map(x => {
                if (Number(x)) {
                    return parseFloat(Intl.NumberFormat(this , { maximumFractionDigits: 2, minimumFractionDigits :2},).format(parseFloat(x)))
                }
                else if (Number(x) === 0) {
                    return 0
                }
                else { return x }
            })

    };

    let columns = convertInputToArray(input[0]);
    let values = input
        .slice(1)
        .map(convertInputToArray)
        .map(x => x.reduce((res, b, i) => {
            res[columns[i]] = b
            return res
        }, {}))

    console.log(JSON.stringify(values));
}

convertToJson(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']
)

convertToJson(['| Town | Latitude | Longitude |',
    '| Random Town | 0.00 | 0.00 |']
)