const fs = require('fs');

var input = JSON.parse(fs.readFileSync("input2.json", { encoding: 'utf-8' }));

var nums = {
    "one": "1",
    "two": "2",
    "three": "3",
    "four": "4",
    "five": "5",
    "six": "6",
    "seven": "7",
    "eight": "8",
    "nine": "9"
};
let total = 0;
let fixedInput = [];

for (var row of input) {
    let fixedRow = [];
    for (const [key, value] of Object.entries(nums)) {
        let wordMatch = new RegExp(key, "g");
        let numMatch = new RegExp(value, "g");

        if (row.search(wordMatch) > -1) {
            for (let match of row.matchAll(wordMatch)) {
                fixedRow.push({ "match": value, "position": match.index });
            }
        }

        if (row.search(numMatch) > -1) {
            for (let match of row.matchAll(numMatch)) {
                fixedRow.push({ "match": value, "position": match.index });
            }
        }

    }
    fixedInput.push(fixedRow);
}
console.log(fixedInput);
fixedInput.forEach(row => {
    row.sort((a, b) => a.position - b.position);
});


fixedInput = fixedInput.map(row => {
    return row.map(item => item.match).join('');
});

for (var i of fixedInput) {
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