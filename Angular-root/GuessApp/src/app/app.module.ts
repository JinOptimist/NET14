import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { ContentComponent } from './content/content.component';
import { RoomsComponent } from './rooms/rooms.component';
import { SingleRoomComponent } from './single-room/single-room.component';
import { HttpClientModule } from '@angular/common/http';
import { DetailMembersComponent } from './detail-members/detail-members.component';
import { RoomDetailComponent } from './room-detail/room-detail.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CanvasDrawingComponent } from './canvas-drawing/canvas-drawing.component';



@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    ContentComponent,
    RoomsComponent,
    SingleRoomComponent,
    DetailMembersComponent,
    RoomDetailComponent,
    CanvasDrawingComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
