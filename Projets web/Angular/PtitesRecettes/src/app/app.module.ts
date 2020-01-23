import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { RecetteItemComponent } from './recette/recette-item/recette-item.component';
import { RecetteListComponent } from './recette/recette-list/recette-list.component';
import { RecettesService } from 'src/service/recettes.service';
import { RecettesDurService } from 'src/service/recettes-dur.service';
import { RecetteDetailsComponent } from './recette/recette-details/recette-details.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RecetteHttpService } from 'src/service/recette-http.service';

@NgModule({
  declarations: [
    AppComponent,
    RecetteItemComponent,
    RecetteListComponent,
    RecetteDetailsComponent,
  ],
  imports: [
    BrowserModule, NgbModule, HttpClientModule
  ],
  providers: [{
    provide: RecettesService,
    useClass: RecetteHttpService
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
