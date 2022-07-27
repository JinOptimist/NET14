import {Component, OnInit} from '@angular/core';
import {CdkDragDrop, moveItemInArray, CdkDrag} from '@angular/cdk/drag-drop';
import { IFolder } from 'src/models/IFolder';
import { ApiService } from 'src/app/sevices/apiService';

@Component({
  selector: 'left-menu',
  templateUrl: './left-menu.component.html',
  styleUrls: ['./left-menu.component.scss']
})
export class LeftMenuComponent implements OnInit {

  folders: IFolder[] = [];

  constructor(private apiService: ApiService) {
    
  }

  ngOnInit(): void {
    this.apiService
      .getFolders()
      .subscribe(x => this.folders = x);

  }

  drop(event: CdkDragDrop<string[]>) {
    moveItemInArray(this.folders, event.previousIndex, event.currentIndex);
  }

}
