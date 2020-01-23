var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
define(["require", "exports", "./voiture"], function (require, exports, voiture_1) {
    "use strict";
    Object.defineProperty(exports, "__esModule", { value: true });
    var Quatre4 = /** @class */ (function (_super) {
        __extends(Quatre4, _super);
        function Quatre4(modele, marque) {
            return _super.call(this, modele, marque) || this;
        }
        Quatre4.prototype.demarrer = function () {
            _super.prototype.demarrer.call(this);
        };
        return Quatre4;
    }(voiture_1.Voiture));
    exports.Quatre4 = Quatre4;
});
