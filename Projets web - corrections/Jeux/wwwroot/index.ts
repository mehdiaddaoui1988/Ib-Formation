$(document).ready(() => {
    $("#main").load("./accueil.html");
    $("a[href$='.html']").click((e) => {
        // J'empèche le lien (<a>) de changer de page
        // C'est son rôle par défaut
        e.preventDefault();
        // Je récupère l'attribut href du a clické

        var href = e.currentTarget.getAttribute("href");
        // Je journalise
        console.log("Navigated to : " + href);
        // Je charge la page demandée dans le main <div id="main"...

        $("#main").html("<h2>En chargement</h2>");
        $("#main").load(href!);
    })
})