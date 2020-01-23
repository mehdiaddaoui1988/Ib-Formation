define(["require", "exports"], function (require, exports) {
    "use strict";
    Object.defineProperty(exports, "__esModule", { value: true });
    var Voiture = /** @class */ (function () {
        function Voiture(modele, marque, prix) {
            if (marque === void 0) { marque = "Peugeot"; }
            if (prix === void 0) { prix = 1000; }
            this.modele = modele;
            this.prix = prix;
            this.estDemarree = false;
            this.marque = marque;
        }
        Voiture.prototype.vendre = function () {
            // Implémentation de vendre
        };
        Object.defineProperty(Voiture.prototype, "marque", {
            get: function () {
                return this._marque;
            },
            set: function (value) {
                if (!value) {
                    throw new Error("La valeur doit être fournie");
                }
                this._marque = value;
            },
            enumerable: true,
            configurable: true
        });
        // Démarrer la voiture
        Voiture.prototype.demarrer = function () {
            if (this.estDemarree) {
                new Error("La voiture est déjà démarrée");
            }
            this.estDemarree = true;
        };
        Voiture.prototype.f = function (a, c, b) {
            if (c instanceof Voiture) {
                return "";
            }
            else {
                return 0;
            }
        };
        return Voiture;
    }());
    exports.Voiture = Voiture;
});
