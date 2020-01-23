
(() => {
    // Cet espace est une closure
    // un contexte indépendant du reste
    $("#surface-config").submit((e) => {
        e.preventDefault();
        // Désactivation du bouton
        $("#bouton-submit-config").attr("disabled", "true");
        // J'affiche une image de progression
        $("#image-waiting").show();
        // je récupère le nombre de lettres
        var nombreDeLettres = $("#input-nombreLettres").val()!;

        // Je créé une promesse basée sur la requète http au service
        console.log(`Requète vers /anagramme/getLettres/${nombreDeLettres}`)
        $.get(`/anagramme/getLettres/${nombreDeLettres}`)
            .then((resultat: string) => {
                console.log("Résultat de la requète :" + resultat)
                $("#affichage-lettres").html(resultat);
                $("#input-motTente").attr("minLength", nombreDeLettres as string).attr("maxLength", nombreDeLettres as string)
                // La promesse est résolue : Tout s'est bien passé
                // J'efface la surface de config
                $("#surface-config").slideUp();
                // Affichage de la surface de jeu
                $("#surface-jeu").slideDown();
                $("#image-waiting").hide();
                $("#bouton-submit-config").removeAttr("disabled");

                $.getJSON(`/anagramme/getReponses/${resultat}`).then((resultats: string[]) => {
                    resultats.forEach(r => {
                        $("#liste-mots").append($("<li/>").html(r).hide())
                    });
                    $("#texte-indication").html(`${resultats.length} mots à trouver`)
                })

            })
            .catch((err) => {
                console.log("Erreur dans la requète")
                // Problème d'exécution de la requète http
                alert("Serveur indisponible");
                $("#image-waiting").hide();
                $("#bouton-submit-config").removeAttr("disabled");
            });



    })
    $("#bouton-reponse").click(() => {
        $("#liste-mots > li").each((i, e) => {
            $(e).slideDown().attr("trouve", "true");
        });

        $("#surface-abandon").slideDown();
    })
    $(".bouton-retour").click(() => {
        $("#surface-config").slideDown();
        $("#surface-jeu").slideUp();
        $("#surface-gagne").slideUp();
        $("#surface-abandon").slideUp();
        $("#liste-mots").empty();

    })
    $("#surface-jeu").submit((e) => {
        debugger
        e.preventDefault();
        // Je vérifie les lettres entrées
        var motEntre = ($("#input-motTente").val() as string).toUpperCase();
        if (
            motEntre.split('').sort().join('') != $("#affichage-lettres").html()
        ) {
            alert("Entrez un mot avec les bonnes lettres");
            return
        }
        $("#input-motTente").val("");
        $("#liste-mots > li").each((i, e) => {
            if ($(e).html() == motEntre) {
                $(e).slideDown().attr("trouve", "true");
            }
        })
        if ($("#liste-mots > li[trouve]").length == $("#liste-mots > li").length) {
            $("#surface-gagne").slideDown();
            $("#surface-jeu").slideUp();
        }



    })

})()

