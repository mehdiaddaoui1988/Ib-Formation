"use strict";
(function () {
    $(".form-hidden").hide();
    var lettresAReordonner;
    var nombreLettres;
    /* -------------------------------------------------------------------------- */
    /*                             SUBMIT FORM CONFIG                             */
    /* -------------------------------------------------------------------------- */
    $("#surface-config").submit(function (e) {
        e.preventDefault();
        // Désactiver bouton submit, afficher image de chargement
        $("#bouton-submit-config").attr("disabled", "true");
        $("#image-waiting").show();
        // nombre de lettres du mot = valeur entrée dans l'input
        nombreLettres = $("#input-nombreLettres").val();
        // Créé une promesse basée sur la requête HTTP au service 
        // then : promesse résolue, tout s'est bien passée
        // catch : promesse rejetée
        console.log("Requête vers /anagramme/getLettres/" + nombreLettres);
        $.get("/anagramme/getLettres/" + nombreLettres)
            .then(function (resultat) {
            // cette valeur prend le mot choisi aléatoirement, ordonné alphabétiquement
            lettresAReordonner = resultat;
            // on affiche cette série de lettres dans la console
            console.log("Résultat de la requête : " + resultat);
            // Affichage
            $("#surface-config").slideUp();
            $("#surface-jeu").slideDown();
            $("#image-waiting").hide();
            $("#bouton-submit-config").removeAttr("disabled");
            $("#label-lettres").html(resultat);
            // Attributs de l'input suivant
            $("#input-motTente")
                .attr("maxLength", nombreLettres)
                .attr("minLength", nombreLettres);
            // Si la promesse ne fonctionne pas
        }).catch(function (err) {
            console.log("Erreur dans la requête : " + err);
            alert("Serveur indisponible");
            $("#image-waiting").hide();
            $("#bouton-submit-config").removeAttr("disabled");
        });
    });
    /* -------------------------------------------------------------------------- */
    /*                               SUBMIT FORM JEU                              */
    /* -------------------------------------------------------------------------- */
    $("#surface-jeu").submit(function (e) {
        e.preventDefault();
        // le mot tenté est mis en majuscule
        var motTente = $("#input-motTente").val().toUpperCase();
        // on envoie la requête, avec le mot trié alphabétiquement. Cela retourne les mots existant qui ont les mêmes lettres
        $.get("/anagramme/getReponses/" + lettresAReordonner)
            .then(function (resultats) {
            console.log(resultats);
            // Si le mot tenté existe parmi cette liste, c'est gagné
            if (resultats.indexOf(motTente) > -1) {
                $("#surface-jeu").slideUp();
                $("#surface-gagne").slideDown();
            }
        });
    });
    /* -------------------------------------------------------------------------- */
    /*                              BOUTON ABANDONNER                             */
    /* -------------------------------------------------------------------------- */
    $("#btn-ff").click(function () {
        // Affichage
        $("#surface-jeu").fadeOut();
        // On affiche les mots possibles à trouver
        $.get("/anagramme/getReponses/" + lettresAReordonner).then(function (resultats) {
            // On vide puis on affiche la liste
            $("#mots-a-trouver").empty();
            resultats.forEach(function (element) {
                $("#mots-a-trouver").append(element + "<br>");
            });
        });
        $("#surface-perdu").show();
    });
    /* -------------------------------------------------------------------------- */
    /*                             BOUTON RECOMMENCER                             */
    /* -------------------------------------------------------------------------- */
    $(".btn-restart").click(function () {
        // On vide l'input du mot à tenter
        $("#input-motTente").val("");
        // On fait tout disparaître et on réaffiche la config
        $(".form-hidden").hide();
        $("#surface-config").slideDown();
    });
})();
