// CHARGEMENT DE LA BIBLIOTHEQUE
var express = require("express");

// CREATION D'UN SERVEUR
var app = express();

//Log all requests
//app.use(express.logger());

//Set content directories
app.use(express.static(__dirname + "/wwwroot"));

var port = 80;
// DEMANDE AU SERVEUR D'ECOUTER SUR LE PORT
app.listen(port, function() {
  console.log("Ecoute sur le port " + port);
});
