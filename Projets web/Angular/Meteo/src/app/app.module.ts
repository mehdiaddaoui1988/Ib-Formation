import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { VilleItemComponent } from './component/ville/ville-item/ville-item.component';
import { VilleListComponent } from './component/ville/ville-list/ville-list.component';
import { MeteoService } from 'src/service/meteo.service';
import { MeteoDurService } from 'src/service/meteo-dur.service';
import { VilleDetailsComponent } from './component/ville/ville-details/ville-details.component';
import { MeteoHttpFormateurService } from 'src/service/meteo-http-formateur.service';

@NgModule({
  declarations: [
    AppComponent,
    VilleItemComponent,
    VilleListComponent,
    VilleDetailsComponent
  ],
  imports: [
    BrowserModule, HttpClientModule
  ],
  providers: [{
    provide: MeteoService,
    useClass: MeteoHttpFormateurService
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
