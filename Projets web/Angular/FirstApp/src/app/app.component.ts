import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})


export class AppComponent {
  title = 'FirstApp';

  user = { nom: "Verschave", prenom: 'Guillaume' };

  users = [{ nom: 'Verschave', prenom: 'Guillaume', credit: 14 },
  { nom: 'Marcq', prenom: 'Vincent', credit: 0 },
  { nom: 'Didelot', prenom: 'Manon', credit: 22 },
  { nom: 'Salembier', prenom: 'Jérémy', credit: 8 }
  ];
  counter = 0;

  modifyCounter(increment: number = 1) {
    this.counter += increment;
  }

  deleteUser(u: any) {
    this.users.splice(this.users.indexOf(u), 1);
  }

  modifyCredit(user: any, increment: number) {
    user.credit += increment;
  }

}
