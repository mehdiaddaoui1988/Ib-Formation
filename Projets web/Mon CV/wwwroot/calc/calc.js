var inputResultat = document.querySelector("#resultat");

var boutonCalc = document.querySelectorAll(".btn");

boutonCalc.forEach(element => {
  element.addEventListener("click", () => {
    inputResultat.value += element.value;
  });
});

var btnEgal = document.querySelector("#btnEgal");
btnEgal.addEventListener("click", () => {
  var resultat = eval(inputResultat.value);
  inputResultat.value = resultat;
});

var btnClear = document.querySelector("#clear");
btnClear.addEventListener("click", () => {
  inputResultat.value = "";
});
