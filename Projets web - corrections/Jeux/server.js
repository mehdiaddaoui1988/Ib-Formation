"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
var express_1 = __importDefault(require("express"));
var mots_1 = require("./mots");
var app = express_1.default();
// Middleware qui journalise la requète et le temps d'exécution
app.use(function (req, res, next) {
    var date1 = Date.now();
    next();
    var date2 = Date.now();
    console.log('Requète sur : ' + req.url + ' traitée en ' + (date2 - date1) + ' ms');
});
// Middleware qui va chercher un fichier dans wwwroot
app.use(express_1.default.static(__dirname + '/wwwroot/'));
app.get("/anagramme/getLettres/:n", function (req, res) {
    var n = +req.params.n;
    var motsValables = mots_1.mots.filter(function (m) { return m.length == n; });
    var nombreDeMotsValables = motsValables.length;
    var indexAuHasard = Math.floor(Math.random() * nombreDeMotsValables);
    var motChoisi = motsValables[indexAuHasard];
    var motOrdonne = motChoisi.split('').sort().join("");
    res.send(motOrdonne);
});
app.get("/anagramme/getReponses/:mot", function (req, res) {
    var mot = req.params.mot;
    mot = mot.split('').sort().join("");
    var reponses = mots_1.mots.filter(function (m) { return mot.length == m.length && mot == m.split('').sort().join(""); });
    res.send(reponses);
});
// app.get("/anagramme/checkMot/:mot/:lettres", (req, res) => {
//     var mot = req.params.mot;
//     var lettres = req.params.lettres.split('').sort().join("");
//     var motTrie = mot.split('').sort().join("");
//     if (lettres != motTrie) { return false }
//     res.send((mots.indexOf(mot) >= 0).toString())
// })
// Middleware qui s'excuse
app.use(function (req, res, next) {
    res.send('Désolé');
});
app.listen(80);
