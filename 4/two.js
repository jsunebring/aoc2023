const fs = require('fs');

const input = fs.readFileSync('./input.txt', 'utf8').split('\n');
let total = 0;

for (let line in input) {
    checkCard(parseInt(line));
}
function checkCard(index) {
    var instance = index;
    var card = input[instance];
    var winning = card.split(':')[1].split('|')[0].trim().split(' ').filter(n => n);
    var nums = card.split(':')[1].split('|')[1].trim().split(' ').filter(n => n);
    for (let num of nums) {
        if (winning.indexOf(num) > -1) {
            checkCard(parseInt(instance+1));
            instance++;
        }
    }

    total++;
}

console.log(total);