import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule} from '@angular/common/http';

import { FormsModule } from '@angular/forms';
import {MatInputModule} from '@angular/material/input';

import {DragDropModule} from '@angular/cdk/drag-drop';

import {MatButtonModule} from '@angular/material/button';
import { MatSliderModule } from '@angular/material/slider';
import {MatIconModule} from '@angular/material/icon';
import {MatFormFieldModule} from '@angular/material/form-field';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LeftMenuComponent } from './component/left-menu/left-menu.component';
import { MainContentComponent } from './component/main-content/main-content.component';
import { BlockIssueComponent } from './component/block-issue/block-issue.component';
import { FolderInContentComponent } from './component/folder-in-content/folder-in-content.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AddIssueInputComponent } from './component/add-issue-input/add-issue-input.component';

@NgModule({
  declarations: [
    AppComponent,
    LeftMenuComponent,
    MainContentComponent,
    BlockIssueComponent,
    FolderInContentComponent,
    AddIssueInputComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatSliderModule,
    MatButtonModule,
    MatIconModule,
    MatFormFieldModule,
    FormsModule,
    MatInputModule,
    DragDropModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
