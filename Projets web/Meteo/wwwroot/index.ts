class Ville {
    nom!: string;
    latitude!: string;
    longitude!: string;
}
class Donnees {
    date!: number;
    temperature!: number;
    nebulosite!: number;
    pluie!: number;
}


$(document).ready(() => {

    $.getJSON("http://192.168.107.20/getVilles").then((resultats: Ville[]) => {
        $("#chargement").remove();
        resultats.forEach(element => {
            $("#navbar-liste-villes")
                .append("<li class='nav-item'>")
                .append("<a  class='nav-link ville'>" + element.nom);
        });



        $(".ville").click((element) => {
            element.preventDefault();

            $(".accueil").fadeOut(500, () => {
                $(".container-liste").hide();
                $(".container-liste").fadeIn(200);
                $(".container-liste").removeAttr("hidden");

            });
            $(".container-liste").fadeIn(200);



            $(".ville").removeClass("active");
            $(element.target).addClass("active");
            //$("#meteo-locale").empty();
            $(".container-cards").empty();
            $("#ville-choisie").html("Chargement...")
            $("#gif-chargement").show();



            var ville = element.target.innerHTML;

            var meteoLocale = $.getJSON("http://192.168.107.20/getMeteoJours/" + ville).then((resultats: Donnees[]) => {
                $("#gif-chargement").hide();
                $("#ville-choisie").html(ville);
                resultats.forEach(element => {

                    var imageNebulosite = "./images/icones/";
                    if (element.pluie >= 50) {
                        imageNebulosite = "<img width='30px' height='30px' src='./images/icones/004-rainy.png'>"
                    }
                    else if (element.nebulosite >= 2 && element.pluie <= 50) {
                        imageNebulosite = "<img width='30px' height='30px' src='./images/icones/002-cloudy.png'>"
                    }
                    else {
                        imageNebulosite = "<img width='30px' height='30px' src='./images/icones/001-sunny.png'>"
                    }


                    var imageTemperature = "";
                    if (element.temperature <= 0) {
                        imageTemperature = "<img width='30px' height='30px' src='./images/icones/019-snowflake.png'>"
                    }
                    else {
                        imageTemperature = ""
                    }

                    // $("#meteo-locale").append("<h3 id='date'>" + new Date(element.date).toLocaleDateString());
                    // $("#meteo-locale").append(`<li  class="list-group-item"> Température : ${element.temperature} °C ${imageTemperature} `);
                    // $("#meteo-locale").append(`<li  class="list-group-item"> Nébulosité : ` + element.nebulosite);
                    // $("#meteo-locale").append(`<li  class="list-group-item"> Probabilité de pluie : ${element.pluie} %  <img width='50px' height='50px' src="${imageNebulosite}" >`)




                    $(".container-cards").append(`
                    <div class="col-md-4">
                        <div class="card  text-white bg-dark mb-3">
                            <div class="card-header">
                                <h4 class="card-date card-title">${new Date(element.date).toLocaleDateString()}</h4>
                            </div>
                            <div class="card-body">
                                <h5 class="card-temperature card-title">${element.temperature} °C ${imageTemperature}</h5>
                                <h5 class="card-nebulosite card-title">Nébulosité : ${element.nebulosite}</h5>
                                <h5 class="card-pluie card-title">Probabilité de pluie : ${element.pluie}% ${imageNebulosite}</h5>
                            </div
                        </div>
                    </div>`)
           




                })
            });
        })
    })


})