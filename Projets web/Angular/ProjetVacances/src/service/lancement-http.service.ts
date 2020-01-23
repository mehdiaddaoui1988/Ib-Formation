import { Injectable } from "@angular/core";
import { LancementService } from "./lancement.service";
import { Fusee } from "src/model/fusee";
import { Lancement } from "src/model/lancement";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: "root"
})
export class LancementHttpService extends LancementService {
  private urlApi = "https://localhost:44369/odata/";
  constructor(private httpClient: HttpClient) {
    super();
  }
  getLancements(): Promise<Lancement[]> {
    return this.httpClient
      .get<any>(this.urlApi + "Lancement_DAO")
      .toPromise()
      .then(resultats => {
        const lancement = resultats.value.map(dto => {
          const pocoLancement = new Lancement();
          pocoLancement.id = dto.Id;
          pocoLancement.chargeUtile = dto.ChargeUtile;
          pocoLancement.dateLancement = new Date(dto.DateLancement);
          pocoLancement.descriptionMission = dto.DescriptionMission;
          pocoLancement.etatAtterrissage = dto.EtatAtterrissage;
          pocoLancement.poidsChargeUtile = dto.PoidsChargeUtile;
          return pocoLancement;
        });
        return lancement;
      });
  }
  getLancementsFusee(f: Fusee): Promise<Lancement[]> {
    // return this.getLancements().then(resultats =>
    //   resultats.filter(r => r.id === f.id)
    // );
    return this.httpClient
      .get<any>(
        this.urlApi + "Lancement_DAO?$filter=IdFusee eq guid" + "'" + f.id + "'"
      )
      .toPromise()
      .then(resultats => {
        const lancement = resultats.value.map(dto => {
          const pocoLancement = new Lancement();
          pocoLancement.id = dto.Id;
          pocoLancement.chargeUtile = dto.ChargeUtile;
          pocoLancement.dateLancement = new Date(dto.DateLancement);
          pocoLancement.descriptionMission = dto.DescriptionMission;
          pocoLancement.etatAtterrissage = dto.EtatAtterrissage;
          pocoLancement.poidsChargeUtile = dto.PoidsChargeUtile;
          return pocoLancement;
        });
        return lancement;
      });
  }

  getFusees(): Promise<Fusee[]> {
    return this.httpClient
      .get<any>(this.urlApi + "Fusee_DAO")
      .toPromise()
      .then(resultats => {
        const fusees = resultats.value.map(dto => {
          const pocoFusee = new Fusee();
          pocoFusee.id = dto.Id;
          pocoFusee.entreprise = dto.Entreprise;
          pocoFusee.modele = dto.Modele;
          pocoFusee.nombreDeVols = dto.NombreDeVols;
          return pocoFusee;
        });
        return fusees;
      });
  }
}
