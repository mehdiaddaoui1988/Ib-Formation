"use strict";
// NOMBRE ALEATOIRE ENTRE 1 ET 100
var nombreATrouver = Math.floor(Math.random() * 100) + 1;
// DOCUMENT CHARGÉ
document.addEventListener("DOMContentLoaded", function () {
    // EVENEMENT CLIC BOUTON
    document.getElementById("button-try").addEventListener("click", function () {
        // LA VALEUR DU NOMBRE TENTE LORS DU CLIC
        var nombreTente = document.getElementById("text-try")
            .value;
        // SI ON RENTRE UNE VALEUR /////////////////VERIFIER CHIFFRE
        if (document.getElementById("text-try").value != "") {
            // AJOUTE UNE LIGNE A LA TABLE
            var newLine = document.getElementById("table-historique").insertRow();
            // AJOUTE UNE CELLULE INDEX 0
            var newCell = newLine.insertCell(0);
            // AJOUTE LE NOMBRE TENTE A LA CELLULE
            newCell.innerHTML = nombreTente;
            // RESULTAT C EST PLUS / C EST MOINS / EGAL
            var resultat = "";
            if (+nombreTente < nombreATrouver) {
                resultat = "C'est plus";
            }
            else if (+nombreTente > nombreATrouver) {
                resultat = "C'est moins";
            }
            else if (+nombreTente == nombreATrouver) {
                resultat = "Bravo !";
            }
            // AJOUTE UNE CELLULE INDEX 1
            var newCell = newLine.insertCell(1);
            // AJOUTE LE RESULTAT A LA CELLULE
            newCell.innerHTML = resultat;
            // SI ON GAGNE DESACTIVER LE BOUTON GO
            if (resultat == "Bravo !") {
                document.getElementById("button-try").style.display = "none";
            }
        }
    });
});
