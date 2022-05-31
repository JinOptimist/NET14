import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddGirlComponent } from './component/add-girl/add-girl.component';
import { GirlsGalleryComponent } from './component/girls-gallery/girls-gallery.component';

const routes: Routes = [
  { path: "add-girl", component: AddGirlComponent },
  { path: "", component: GirlsGalleryComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
