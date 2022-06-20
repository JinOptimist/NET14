import { LoginComponent } from './login/login.component';
import { RoomDetailComponent } from './room-detail/room-detail.component';
import { RoomsComponent } from './rooms/rooms.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [{path:"", component: RoomsComponent},
{path:"rooms", component: RoomsComponent},
{path:"detail/:id", component: RoomDetailComponent},
{path: "login", component: LoginComponent}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
