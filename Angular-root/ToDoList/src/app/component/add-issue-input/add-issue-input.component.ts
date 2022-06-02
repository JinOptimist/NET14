import { Component, OnInit } from '@angular/core';
import { IIssue } from 'src/models/IIssue';

@Component({
  selector: 'add-issue-input',
  templateUrl: './add-issue-input.component.html',
  styleUrls: ['./add-issue-input.component.scss']
})
export class AddIssueInputComponent implements OnInit {

  newIssue: IIssue;
  constructor() { 
    this.newIssue = {} as IIssue;
  }

  ngOnInit(): void {
  }

}
