"use strict";
$(document).ready(function () {
    // Affiche l'accueil lors du chargement de la page
    $("#main").load("./accueil.html");
    $("a[href$='.html']").click(function (e) {
        // empêche le changement de page
        e.preventDefault();
        // je récupère le lien href du a cliqué
        var href = e.target.getAttribute("href");
        // je charge la page demandée dans le main
        $("#main").html("<h1>En chargement...</h1>");
        $("#main").load(href);
    });
});
