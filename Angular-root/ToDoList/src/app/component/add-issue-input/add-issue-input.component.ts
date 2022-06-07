import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/sevices/apiService';
import { IIssue } from 'src/models/IIssue';

@Component({
  selector: 'add-issue-input',
  templateUrl: './add-issue-input.component.html',
  styleUrls: ['./add-issue-input.component.scss']
})
export class AddIssueInputComponent implements OnInit {

  newIssue: IIssue;
  constructor(private apiService: ApiService) { 
    this.newIssue = {} as IIssue;
  }

  ngOnInit(): void {
  }
  createIssue(){
    this.apiService
      .createIssue(this.newIssue)
      .subscribe();
  }

}
