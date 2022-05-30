import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'main-content',
  templateUrl: './main-content.component.html',
  styleUrls: ['./main-content.component.scss']
})
export class MainContentComponent implements OnInit {

  issues: any[];
  constructor() { 
    this.issues = [
      {text:"to do my best"},
      {text:"to do 1"},
      {text:"to do my homework"},
      {text:"go to work"}
    ];
  }

  ngOnInit(): void {
  }

  addIssue(){
    this.issues.push({text:`to do ${this.issues.length}`})
  }
  deleteIssue(issue: any){
    this.issues = this.issues.filter(x => x.text != issue);
  }


}
