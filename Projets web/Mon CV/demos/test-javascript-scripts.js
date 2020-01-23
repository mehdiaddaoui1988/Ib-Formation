// Syntaxe des fonctions en JS
// Ajoute une option au select
function ajouteOption(text) {
  var select = document.querySelector("#mon-select");
  var o = new Option(text);
  select.options.add(o);
}

var dateFin = new Date().getFullYear();
var dateDebut = dateFin - 120;
for (var i = dateDebut; i <= dateFin; i++) {
  ajouteOption(i);
}

var boutonAjout = document.querySelector("#mon-bouton");
boutonAjout.addEventListener("click", () => {
  var input = document.getElementById("nouvelle-option");
  if (input.value) {
    ajouteOption(input.value);
  }
  input.value ="";



});
