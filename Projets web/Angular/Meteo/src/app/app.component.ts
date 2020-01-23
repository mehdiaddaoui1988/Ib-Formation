import { Component } from '@angular/core';
import { pairs } from 'rxjs';
import { MeteoDurService } from 'src/service/meteo-dur.service';
import { Ville } from 'src/model/ville';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  title = 'Meteo :)';

  ngOnInit() { }
}
