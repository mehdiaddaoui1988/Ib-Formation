import { JeuCoreApiService } from "./../services/jeu-core-api.service";
import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { JeuService } from "src/services/jeu.service";
import { PartieListComponent } from "./partie-list/partie-list.component";
import { PartiePlayComponent } from "./partie-play/partie-play.component";

@NgModule({
  declarations: [AppComponent, PartieListComponent, PartiePlayComponent],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule],
  providers: [{ provide: JeuService, useClass: JeuCoreApiService }],
  bootstrap: [AppComponent]
})
export class AppModule {}
