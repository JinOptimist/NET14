import { Component, Input, OnInit } from '@angular/core';
import { IIssue } from 'src/models/IIssue';
import { HttpClient} from '@angular/common/http';
import { IFolder } from 'src/models/IFolder';

@Component({
  selector: 'main-content',
  templateUrl: './main-content.component.html',
  styleUrls: ['./main-content.component.scss']
})
export class MainContentComponent implements OnInit {

  issues: IIssue[] = [];
  issue!: IIssue;
  folders: IFolder[] = [];
  
  constructor(private http: HttpClient) { 
    http
      .get<IIssue[]>('http://localhost:42059/api/ToDoList/GetIssues')
      .subscribe(response => this.issues = response);
    http
      .get<IFolder[]>('http://localhost:42059/api/ToDoList/GetFolders')
      .subscribe(response => this.folders = response);

    http
      .post<IIssue>('http://localhost:42059/api/ToDoList/AddIssue', this.issue);
      

  }

  ngOnInit(): void {
  }

  parentRemoveIssue(issueId: number){
    this.issues = this.issues.filter(x => x.id != issueId)
  }
  
  addIssue(issue: string){
    
  }


}
