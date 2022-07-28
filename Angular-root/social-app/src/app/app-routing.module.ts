import { ApiComponent } from './components/api/api.component';
import { UserDetailsComponent } from './components/user-details/user-details.component';
import { UsersComponent } from './components/users/users.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';


const routes: Routes = [{path: "users", component: UsersComponent},
{path: "", component: UsersComponent},
{path: 'detail/:id', component: UserDetailsComponent },
{path: 'api', component: ApiComponent}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
