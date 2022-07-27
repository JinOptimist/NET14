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

  textValue: string = '';
  issues: IIssue[] = [];
  newIssue: IIssue;
  
  constructor(private apiService: ApiService) { 
    this.newIssue = {} as IIssue;


  }
  ngOnInit(): void {
    this.apiService
      .getIssues()
      .subscribe(x => this.issues = x.reverse());
  }

  // create issue in database and add to list 
  createIssue(){
    this.apiService
      .createIssue(this.newIssue)
      .subscribe((issue: IIssue) =>{
        this.issues.unshift(issue);
        this.textValue = ' ';
      });
  }

  // remove from list
  parentRemoveIssue(issueId: number){
    this.apiService
      .removeIssue(issueId)
      .subscribe(response => {
        if(true){
          this.issues = this.issues.filter(x => x.id != issueId);
        }
        
      });
  }

  // drag and drop
  drop(event: CdkDragDrop<string[]>) {
    moveItemInArray(this.issues, event.previousIndex, event.currentIndex);
  }

}
