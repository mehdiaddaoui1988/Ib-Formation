(() => {
    // Cette méthode sera exécutée à la fin du chargement du document
    // Donc je disposerai de tous les éléments
    $(".invisible").hide().removeClass("invisible");
    var nombreAleatoire: number;
    var nombreEssaisMax: number;
    $("#formulaire-config").submit(e => {

        // Empeche le formulaire de changer de page
        e.preventDefault();
        // cette méthode sera éxécutée en cas de click sur le bouton valider la config
        var nombreMaximum = $("#input-nombreMaximum").val() as number;
        nombreEssaisMax = $("#input-nombreEssaisMax").val() as number;
        nombreAleatoire = Math.floor(Math.random() * nombreMaximum);
        console.log(nombreAleatoire);

        // Masquage de la surface de config
        $("#surface-config").slideUp();
        //document.getElementById("surface-config")!.className = "invisible";

        // Affichage de la surface de jeu
        $("#surface-jeu").slideDown();
        //document.getElementById("surface-jeu")!.className = "";

        // Mise en place de l'attribut max du nombre entré
        $("#input-nombreTente").attr("max", nombreMaximum);
        //document.getElementById("input-nombreTente")!.setAttribute("max", nombreMaximum.toString());



    })

    // Je prend les éléments du document qui ont class="bouton-rejouer"


    $(".bouton-rejouer").click(() => {
        $("#surface-config").slideDown().removeClass("invisible");
        $("#tbody-resultats").html("");//.empty().addClass("coucou").attr("id-coucou", "coucou").removeClass("toto");
        $("#table-resultats").slideUp();
        $("#input-nombreTente").val("");
        $("#surface-gagne").slideUp();
        $("#surface-perdu").slideUp();
    })


    $("#formulaire-jeu").submit((e) => {
        e.preventDefault();
        var tbody = $("#tbody-resultats")!;
        var nombreTente = $("#input-nombreTente").val();
        if (nombreTente == nombreAleatoire) {
            $("#surface-jeu").slideUp();
            $("#surface-gagne").slideDown();
        } else {

            $("#table-resultats").slideDown();
            tbody.append(
                $("<tr/>")
                    .append($("<td/>")
                        .html(nombreTente!.toString())
                    )
                    .append($("<td/>")
                        .html(`${new Date().getHours()}:${new Date().getMinutes()}:${new Date().getSeconds()}`)
                    )
                    .append($("<td/>")
                        .html(nombreTente! > nombreAleatoire ? 'Trop grand' : 'Trop petit')
                    )
            )

        }

        var nombreEssais = tbody.find("tr").length;
        if (nombreEssais >= nombreEssaisMax) {
            $("#surface-jeu").slideUp();
            $("#surface-perdu").slideDown();
        }
        // Réinitialisation de l'input d'entrée du nombre
        $("#input-nombreTente").val("");

    })
})()



