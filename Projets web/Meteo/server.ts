import express from 'express';




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




app.listen(80);