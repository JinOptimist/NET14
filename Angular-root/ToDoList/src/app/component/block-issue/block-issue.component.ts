import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { IIssue } from 'src/models/IIssue';

@Component({
  selector: 'block-issue',
  templateUrl: './block-issue.component.html',
  styleUrls: ['./block-issue.component.scss']
})
export class BlockIssueComponent implements OnInit {

  @Input() issue!: IIssue;
  @Output() onRemoveIssue = new EventEmitter<number>();
  constructor() {
    
   }

  ngOnInit(): void {
  }

  removeIssue(issueId: number){
    this.onRemoveIssue.emit(issueId);
  }

}
