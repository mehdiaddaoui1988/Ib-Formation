"use strict";
var Ville = /** @class */ (function () {
    function Ville() {
    }
    return Ville;
}());
var Donnees = /** @class */ (function () {
    function Donnees() {
    }
    return Donnees;
}());
$(document).ready(function () {
    $.getJSON("http://192.168.107.20/getVilles").then(function (resultats) {
        $("#chargement").remove();
        resultats.forEach(function (element) {
            $("#navbar-liste-villes")
                .append("<li class='nav-item'>")
                .append("<a  class='nav-link ville'>" + element.nom);
        });
        $(".ville").click(function (element) {
            element.preventDefault();
            $(".accueil").fadeOut(500, function () {
                $(".container-liste").hide();
                $(".container-liste").fadeIn(200);
                $(".container-liste").removeAttr("hidden");
            });
            $(".container-liste").fadeIn(200);
            $(".ville").removeClass("active");
            $(element.target).addClass("active");
            //$("#meteo-locale").empty();
            $(".container-cards").empty();
            $("#ville-choisie").html("Chargement...");
            $("#gif-chargement").show();
            var ville = element.target.innerHTML;
            var meteoLocale = $.getJSON("http://192.168.107.20/getMeteoJours/" + ville).then(function (resultats) {
                $("#gif-chargement").hide();
                $("#ville-choisie").html(ville);
                resultats.forEach(function (element) {
                    var imageNebulosite = "./images/icones/";
                    if (element.pluie >= 50) {
                        imageNebulosite = "<img width='30px' height='30px' src='./images/icones/004-rainy.png'>";
                    }
                    else if (element.nebulosite >= 2 && element.pluie <= 50) {
                        imageNebulosite = "<img width='30px' height='30px' src='./images/icones/002-cloudy.png'>";
                    }
                    else {
                        imageNebulosite = "<img width='30px' height='30px' src='./images/icones/001-sunny.png'>";
                    }
                    var imageTemperature = "";
                    if (element.temperature <= 0) {
                        imageTemperature = "<img width='30px' height='30px' src='./images/icones/019-snowflake.png'>";
                    }
                    else {
                        imageTemperature = "";
                    }
                    // $("#meteo-locale").append("<h3 id='date'>" + new Date(element.date).toLocaleDateString());
                    // $("#meteo-locale").append(`<li  class="list-group-item"> Température : ${element.temperature} °C ${imageTemperature} `);
                    // $("#meteo-locale").append(`<li  class="list-group-item"> Nébulosité : ` + element.nebulosite);
                    // $("#meteo-locale").append(`<li  class="list-group-item"> Probabilité de pluie : ${element.pluie} %  <img width='50px' height='50px' src="${imageNebulosite}" >`)
                    $(".container-cards").append("\n                    <div class=\"col-md-4\">\n                        <div class=\"card  text-white bg-dark mb-3\">\n                            <div class=\"card-header\">\n                                <h4 class=\"card-date card-title\">" + new Date(element.date).toLocaleDateString() + "</h4>\n                            </div>\n                            <div class=\"card-body\">\n                                <h5 class=\"card-temperature card-title\">" + element.temperature + " \u00B0C " + imageTemperature + "</h5>\n                                <h5 class=\"card-nebulosite card-title\">N\u00E9bulosit\u00E9 : " + element.nebulosite + "</h5>\n                                <h5 class=\"card-pluie card-title\">Probabilit\u00E9 de pluie : " + element.pluie + "% " + imageNebulosite + "</h5>\n                            </div\n                        </div>\n                    </div>");
                });
            });
        });
    });
});
