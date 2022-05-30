import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LeftMenuComponent } from './component/left-menu/left-menu.component';
import { MainContentComponent } from './component/main-content/main-content.component';
import { BlockIssueComponent } from './component/block-issue/block-issue.component';

@NgModule({
  declarations: [
    AppComponent,
    LeftMenuComponent,
    MainContentComponent,
    BlockIssueComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
