import { Component, Input, OnInit } from '@angular/core';
import { IIssue } from 'src/models/IIssue';
import { HttpClient} from '@angular/common/http';

@Component({
  selector: 'main-content',
  templateUrl: './main-content.component.html',
  styleUrls: ['./main-content.component.scss']
})
export class MainContentComponent implements OnInit {

  issues: IIssue[] = [];

  constructor(private http: HttpClient) { 
    http
      .get<IIssue[]>('http://localhost:42059/api/ToDoList/GetIssues')
      .subscribe(response => this.issues = response);
      

  }

  ngOnInit(): void {
  }



}
