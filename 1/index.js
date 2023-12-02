const fs = require('fs');
const path = require('path');

var input = JSON.parse(fs.readFileSync("input.json", { encoding: 'utf-8' }));

let total = 0;
for (var i of input) {
    let rowNums = [];
    for (var n of i) {
        if (isNumber(n)) {
            rowNums.push(n);
        }
    }

    var numOne = rowNums[0];
    var numTwo = rowNums[rowNums.length - 1];
    var rowTotal = parseInt(numOne + numTwo);
    console.log(numOne + " + " + numTwo + " = " + rowTotal);
    total += rowTotal;

}

console.log(total);

function isNumber(value) {
    return !isNaN(parseInt(value));
}