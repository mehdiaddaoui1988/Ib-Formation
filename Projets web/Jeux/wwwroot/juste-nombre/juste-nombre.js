"use strict";
(function () {
    $(".invisible").hide().removeClass("invisible");
    // Cette méthode sera exécutée à la fin du chargement de la page
    // Je disposerai de tous les éléments
    var nombreAleatoire;
    var nombreMaxEssais;
    /* -------------------------------------------------------------------------- */
    /*                             SUBMIT FORM CONFIG                             */
    /* -------------------------------------------------------------------------- */
    //#region FORM CONFIG
    $("#form-config").submit(function (e) {
        // L'évènement se déclenche lorsque le formulaire est valide.
        var nombreMax = $("#input-nombreMaximum").val();
        nombreMaxEssais = $("#input-nomreEssaisMax").val();
        nombreAleatoire = Math.floor(Math.random() * nombreMax);
        console.log(nombreAleatoire);
        $("#surface-config").slideUp();
        $("#surface-jeu").slideDown();
        $("#input-nombreTente").attr("max", nombreMax);
        e.preventDefault();
    });
    //#endregion
    /* -------------------------------------------------------------------------- */
    /*                               SUBMIT FORM JEU                              */
    /* -------------------------------------------------------------------------- */
    //#region FORM JEU
    $("#form-jeu").submit(function (e) {
        // var nombreTente = (document.getElementById("input-nombreTente") as HTMLInputElement).valueAsNumber;
        var nombreTente = $("#input-nombreTente").val();
        // var tbody = document.getElementById("tbody-resultats")!;
        var tbody = $("#tbody-resultats");
        if (nombreTente == nombreAleatoire) {
            $("#surface-jeu").slideUp();
            $("#surface-gagne").slideDown();
        }
        else {
            $("#table-resultats").slideDown();
            tbody.append($("<tr/>")
                .append($("<td/>")
                .html(nombreTente.toString()))
                .append($("<td/>")
                .html(new Date().getHours() + ":" + new Date().getMinutes() + ":" + new Date().getSeconds()))
                .append($("<td/>")
                .html(nombreTente > nombreAleatoire ? "Trop grand" : "Trop petit")));
            // Réinitialisation de la zone de l'input
            $("#input-nombreTente").val("").focus();
        }
        e.preventDefault();
        var nombreEssais = tbody.find("tr").length;
        if (nombreEssais >= nombreMaxEssais) {
            $("#surface-jeu").slideUp();
            $("#surface-perdu").slideDown();
        }
    });
    //#endregion
    /* -------------------------------------------------------------------------- */
    /*                               Bouton rejouer                               */
    /* -------------------------------------------------------------------------- */
    //#region BOUTON REJOUER
    $(".bouton-rejouer").click(function () {
        $("#surface-gagne").slideUp();
        $("#surface-perdu").slideUp();
        $("#surface-config").slideDown();
        $("#table-resultats").slideUp();
        $("#tbody-resultats").html("");
        $("#input-nombreTente").val("");
    });
    //#endregion
})();
