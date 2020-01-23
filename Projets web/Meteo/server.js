"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
var express_1 = __importDefault(require("express"));
var app = express_1.default();
// middleware qui journalise les requêtes et le temps d'exécution
app.use(function (req, res, next) {
    var date1 = Date.now();
    next();
    var date2 = Date.now();
    console.log("Requête sur : " + req.url + " traitée en " + (date2 - date1) + " ms.");
});
// middleware qui va chercher un fichier dans wwwroot 
app.use(express_1.default.static(__dirname + "/wwwroot/"));
app.listen(80);
