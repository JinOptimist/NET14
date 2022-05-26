import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HellPageComponent } from './component/hell-page/hell-page.component';
import { LeftMenuComponent } from './component/left-menu/left-menu.component';
import { HeaderComponent } from './component/header/header.component';
import { GirlsGalleryComponent } from './component/girls-gallery/girls-gallery.component';
import { GirlBlockComponent } from './component/girl-block/girl-block.component';

@NgModule({
  declarations: [
    AppComponent,
    HellPageComponent,
    LeftMenuComponent,
    HeaderComponent,
    GirlsGalleryComponent,
    GirlBlockComponent
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
