import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'main-content',
  templateUrl: './main-content.component.html',
  styleUrls: ['./main-content.component.scss']
})
export class MainContentComponent implements OnInit {

  issues: string[];
  constructor() { 
    this.issues = [
      'to do my best',
      'to do',
      'to do',
      'have a rest for 4 hours'
    ];
  }

  ngOnInit(): void {
  }

}
