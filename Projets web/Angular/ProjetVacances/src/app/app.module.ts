import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppComponent } from './app.component';
import { FuseeItemComponent } from './fusees-item/fusee-item/fusee-item.component';
import { LancementListeComponent } from './lancements-liste/lancement-liste/lancement-liste.component';
import { LancementService } from 'src/service/lancement.service';
import { LancementDurService } from 'src/service/lancement-dur.service';
import { HttpClientModule } from '@angular/common/http';
import { LancementHttpService } from 'src/service/lancement-http.service';
import { LancementItemComponent } from './lancements-item/lancement-item/lancement-item.component';

@NgModule({
  declarations: [AppComponent, FuseeItemComponent, LancementListeComponent, LancementItemComponent],
  imports: [BrowserModule, NgbModule, HttpClientModule],
  providers: [
    {
      provide: LancementService,
      useClass: LancementHttpService
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
