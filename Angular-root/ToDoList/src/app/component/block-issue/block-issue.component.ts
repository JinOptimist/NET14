import { Component, Input, OnInit } from '@angular/core';
import { IIssue } from 'src/models/IIssue';

@Component({
  selector: 'block-issue',
  templateUrl: './block-issue.component.html',
  styleUrls: ['./block-issue.component.scss']
})
export class BlockIssueComponent implements OnInit {

  @Input() issue!: IIssue;
  constructor() {
    
   }

  ngOnInit(): void {
  }

}
