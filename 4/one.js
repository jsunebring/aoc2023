const fs = require('fs');

const input = fs.readFileSync('./input.txt', 'utf8').split('\n');

let total = 0;
for (let line of input) {
    var winning = line.split(':')[1].split('|')[0].trim().split(' ').filter(n => n);
    var nums = line.split(':')[1].split('|')[1].trim().split(' ').filter(n => n);
    let instance = 0;
    for (let num of nums) {
        if (winning.indexOf(num) > -1) {
            instance = instance == 0 ? 1 : instance * 2;
        }
    }
    total += instance;
}

console.log(total);