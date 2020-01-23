"use strict";
document.addEventListener("DOMContentLoaded", function () {
    // Le document est chargé
    document.getElementById("net").addEventListener("mouseenter", function (e) {
        document.getElementById("detail-net").className = "";
    });
    document.getElementById("net").addEventListener("mouseleave", function (e) {
        document.getElementById("detail-net").className = "invisible";
    });
});
