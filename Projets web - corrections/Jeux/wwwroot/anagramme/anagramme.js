"use strict";
(function () {
    // Cet espace est une closure
    // un contexte indépendant du reste
    $("#surface-config").submit(function (e) {
        e.preventDefault();
        // Désactivation du bouton
        $("#bouton-submit-config").attr("disabled", "true");
        // J'affiche une image de progression
        $("#image-waiting").show();
        // je récupère le nombre de lettres
        var nombreDeLettres = $("#input-nombreLettres").val();
        // Je créé une promesse basée sur la requète http au service
        console.log("Requ\u00E8te vers /anagramme/getLettres/" + nombreDeLettres);
        $.get("/anagramme/getLettres/" + nombreDeLettres)
            .then(function (resultat) {
            console.log("Résultat de la requète :" + resultat);
            $("#affichage-lettres").html(resultat);
            $("#input-motTente").attr("minLength", nombreDeLettres).attr("maxLength", nombreDeLettres);
            // La promesse est résolue : Tout s'est bien passé
            // J'efface la surface de config
            $("#surface-config").slideUp();
            // Affichage de la surface de jeu
            $("#surface-jeu").slideDown();
            $("#image-waiting").hide();
            $("#bouton-submit-config").removeAttr("disabled");
            $.getJSON("/anagramme/getReponses/" + resultat).then(function (resultats) {
                resultats.forEach(function (r) {
                    $("#liste-mots").append($("<li/>").html(r).hide());
                });
                $("#texte-indication").html(resultats.length + " mots \u00E0 trouver");
            });
        })
            .catch(function (err) {
            console.log("Erreur dans la requète");
            // Problème d'exécution de la requète http
            alert("Serveur indisponible");
            $("#image-waiting").hide();
            $("#bouton-submit-config").removeAttr("disabled");
        });
    });
    $("#bouton-reponse").click(function () {
        $("#liste-mots > li").each(function (i, e) {
            $(e).slideDown().attr("trouve", "true");
        });
        $("#surface-abandon").slideDown();
    });
    $(".bouton-retour").click(function () {
        $("#surface-config").slideDown();
        $("#surface-jeu").slideUp();
        $("#surface-gagne").slideUp();
        $("#surface-abandon").slideUp();
        $("#liste-mots").empty();
    });
    $("#surface-jeu").submit(function (e) {
        debugger;
        e.preventDefault();
        // Je vérifie les lettres entrées
        var motEntre = $("#input-motTente").val().toUpperCase();
        if (motEntre.split('').sort().join('') != $("#affichage-lettres").html()) {
            alert("Entrez un mot avec les bonnes lettres");
            return;
        }
        $("#input-motTente").val("");
        $("#liste-mots > li").each(function (i, e) {
            if ($(e).html() == motEntre) {
                $(e).slideDown().attr("trouve", "true");
            }
        });
        if ($("#liste-mots > li[trouve]").length == $("#liste-mots > li").length) {
            $("#surface-gagne").slideDown();
            $("#surface-jeu").slideUp();
        }
    });
})();
