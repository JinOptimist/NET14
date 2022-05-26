import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { FormsModule } from '@angular/forms';

import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { DragDropModule } from '@angular/cdk/drag-drop';

import { MatInputModule } from '@angular/material/input';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HellPageComponent } from './component/hell-page/hell-page.component';
import { LeftMenuComponent } from './component/left-menu/left-menu.component';
import { HeaderComponent } from './component/header/header.component';
import { GirlsGalleryComponent } from './component/girls-gallery/girls-gallery.component';
import { GirlBlockComponent } from './component/girl-block/girl-block.component';
import { AddGirlComponent } from './component/add-girl/add-girl.component';

@NgModule({
  declarations: [
    AppComponent,
    HellPageComponent,
    LeftMenuComponent,
    HeaderComponent,
    GirlsGalleryComponent,
    GirlBlockComponent,
    AddGirlComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,

    FormsModule,

    MatButtonModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
    DragDropModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
