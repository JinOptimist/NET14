import {Component, OnInit} from '@angular/core';
import {CdkDragDrop, moveItemInArray, CdkDrag} from '@angular/cdk/drag-drop';
import { IIssue } from 'src/models/IIssue';
import { IFolder } from 'src/models/IFolder';
import { ApiService } from 'src/app/sevices/apiService';

@Component({
  selector: 'main-content',
  templateUrl: './main-content.component.html',
  styleUrls: ['./main-content.component.scss']
})
export class MainContentComponent implements OnInit {

  issues: IIssue[] = [];
  issue!: IIssue;
  folders: IFolder[] = [];
  
  constructor(private apiService: ApiService) {
  }
  ngOnInit(): void {
    this.apiService
      .getIssues()
      .subscribe(x => this.issues = x);

    this.apiService
      .getFolders()
      .subscribe(x => this.folders = x);
  }

  parentRemoveIssue(issueId: number){
    this.issues = this.issues.filter(x => x.id != issueId)
  }

  drop(event: CdkDragDrop<string[]>) {
    moveItemInArray(this.issues, event.previousIndex, event.currentIndex);
  }

}
