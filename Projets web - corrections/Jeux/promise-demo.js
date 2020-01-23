"use strict";
var P = new Promise(function (resolve, reject) {
    setTimeout(function () {
        if (Math.random() > 0.5) {
            console.log("Bonjour");
            resolve();
        }
        else {
            reject();
        }
    }, 2000);
});
function addition(a, b) {
    for (var i = 0; i < 2000000000; i++) {
        i = i * 2 / 2;
    }
    return a + b;
}
console.log("debut de fonction");
var p2 = new Promise(function (resolve, reject) {
    var a = addition(1, 2);
    resolve(a);
});
p2.then(function (resultat) {
    console.log("Le résultat est " + resultat);
});
console.log("Je vais dire bonjour");
P.then(function () {
    console.log("Bonjour fait");
})
    .catch(function () {
    console.log("Excusez-moi mais erreur de données");
});
