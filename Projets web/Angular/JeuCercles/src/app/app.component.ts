import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'JeuCercles';
  boules = [
    {
      rayon: 200,
      posX: 50,
      posY: 50,
      colorFill: 'red',
      colorBorder: 'black',
    }, {
      rayon: 300,
      posX: 300,
      posY: 300,
      colorFill: 'blue',
      colorBorder: 'white',
    }, {
      rayon: 400,
      posX: 500,
      posY: 0,
      colorFill: 'green',
      colorBorder: 'red',
    }]


}
