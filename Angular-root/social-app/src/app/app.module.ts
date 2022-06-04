import { NgModule, Component } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {MatButtonModule} from '@angular/material/button';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { NavbarComponent } from './components/navbar/navbar.component'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatButtonToggleModule} from '@angular/material/button-toggle';
import { ContentComponent } from './components/content/content.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { UsersComponent } from './components/users/users.component';
import { HttpClientModule } from '@angular/common/http';
import { SingleUserComponent } from './components/single-user/single-user.component';
import {MatCardModule} from '@angular/material/card';
import {MatTabsModule} from '@angular/material/tabs';
import {MatInputModule} from '@angular/material/input';
import { UserDetailsComponent } from './components/user-details/user-details.component';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';
import { Router } from '@angular/router';
import { UserSearchComponent } from './components/user-search/user-search.component';
import { ApiComponent } from './components/api/api.component';
import { SingleApiComponent } from './single-api/single-api.component';



@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    NavbarComponent,
    ContentComponent,
    UsersComponent,
    SingleUserComponent,
    UserDetailsComponent,
    UserSearchComponent,
    ApiComponent,
    SingleApiComponent
  ],
  imports: [
    MatSlideToggleModule,
    MatTabsModule,
    MatInputModule,
    MatCardModule,
    HttpClientModule,
    MatButtonToggleModule,
    MatButtonModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule { }
