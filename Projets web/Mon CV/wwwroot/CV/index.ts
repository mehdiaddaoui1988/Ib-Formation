document.addEventListener("DOMContentLoaded", () => {
  // Le document est chargé

  document.getElementById("net")!.addEventListener("mouseenter", e => {
    document.getElementById("detail-net")!.className = "";
  });
  document.getElementById("net")!.addEventListener("mouseleave", e => {
    document.getElementById("detail-net")!.className = "invisible";
  });
});

