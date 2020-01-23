import express from 'express';
import { mots } from './mots';




var app = express();

// middleware qui journalise les requêtes et le temps d'exécution
app.use((req, res, next) => {
    var date1 = Date.now();
    next();
    var date2 = Date.now();
    console.log("Requête sur : " + req.url + " traitée en " + (date2 - date1) + " ms.");

});

// middleware qui va chercher un fichier dans wwwroot 
app.use(express.static(__dirname + "/wwwroot/"));






var motChoisi: string;

// Avoir un mot au hasard mélangé de n lettres
app.get("/anagramme/getLettres/:n", (req, res) => {
    var n = +req.params.n;
    var motsValables = mots.filter(m => m.length == n);
    var nombreDeMotsValables = motsValables.length;
    var indexAuHasard = Math.floor((Math.random() * nombreDeMotsValables));

    motChoisi = motsValables[indexAuHasard];

    var motOrdonne = motChoisi.split('').sort().join("");
    res.send(motOrdonne);
})




app.get("/anagramme/getReponses/:mot", (req, res) => {
    var mot = req.params.mot;
    mot = mot.split('').sort().join("");

    var reponses = mots.filter(m => mot.length == m.length && mot == m.split('').sort().join(""));
    res.send(reponses)
})





// middleware qui s'excuse
app.use((req, res, next) => {
    res.send("Désolé");
});

// Ecoute sur le port 80
app.listen(80);