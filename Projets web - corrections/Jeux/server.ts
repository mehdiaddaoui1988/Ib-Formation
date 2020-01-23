import express, { response } from 'express';
import { mots } from './mots';



var app = express();

// Middleware qui journalise la requète et le temps d'exécution
app.use((req, res, next) => {
    var date1 = Date.now();
    next();
    var date2 = Date.now();
    console.log('Requète sur : ' + req.url + ' traitée en ' + (date2 - date1) + ' ms');
});
// Middleware qui va chercher un fichier dans wwwroot
app.use(express.static(__dirname + '/wwwroot/'));

app.get("/anagramme/getLettres/:n", (req, res) => {
    var n = +req.params.n;

    var motsValables = mots.filter(m => m.length == n);
    var nombreDeMotsValables = motsValables.length;
    var indexAuHasard = Math.floor(Math.random() * nombreDeMotsValables);
    var motChoisi = motsValables[indexAuHasard];
    var motOrdonne = motChoisi.split('').sort().join("");
    res.send(motOrdonne);

})

app.get("/anagramme/getReponses/:mot", (req, res) => {
    var mot = req.params.mot;
    mot = mot.split('').sort().join("");
    var reponses = mots.filter(m => mot.length == m.length && mot == m.split('').sort().join(""));
    res.send(reponses)
})

// app.get("/anagramme/checkMot/:mot/:lettres", (req, res) => {
//     var mot = req.params.mot;
//     var lettres = req.params.lettres.split('').sort().join("");
//     var motTrie = mot.split('').sort().join("");
//     if (lettres != motTrie) { return false }
//     res.send((mots.indexOf(mot) >= 0).toString())
// })


// Middleware qui s'excuse
app.use((req, res, next) => {
    res.send('Désolé');
})

app.listen(80);