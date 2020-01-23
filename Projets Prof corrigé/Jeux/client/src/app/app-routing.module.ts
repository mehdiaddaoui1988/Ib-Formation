import { PartiePlayComponent } from "./partie-play/partie-play.component";
import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { PartieListComponent } from "./partie-list/partie-list.component";

const routes: Routes = [
  { path: "", component: PartieListComponent },
  { path: "partie/:id", component: PartiePlayComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
