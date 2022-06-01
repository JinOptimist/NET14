import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { BlockIssueComponent } from './component/block-issue/block-issue.component';
import { MainContentComponent } from './component/main-content/main-content.component';

const routes: Routes = [
  {path: "", component: MainContentComponent}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
