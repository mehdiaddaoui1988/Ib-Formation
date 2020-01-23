// Je charge la bivliothèque express dans la variable express
var express = require("express");

// Je créé un serveur http (app) par l'éxécution de express()
var app = express();

app.use("/", express.static(__dirname + "/wwwroot"));

app.use((req, res, next) => {
  console.log("Début de Requete vers " + req.url);
  next();
  console.log("Fin de Requete vers " + req.url);
});

// intergiciel qui va chercher les fichiers demandés dans le dossier wwwroot

app.listen(80, () => {
  console.log("Server à l'écoute sur le port 80");
});
