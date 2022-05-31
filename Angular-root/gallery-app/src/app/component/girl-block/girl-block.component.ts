import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { IGirl } from 'src/models/IGirl';

@Component({
  selector: 'girl-block',
  templateUrl: './girl-block.component.html',
  styleUrls: ['./girl-block.component.scss']
})
export class GirlBlockComponent implements OnInit {

  @Input() girl!: IGirl;
  @Input() showControlls: boolean = true;

  @Output() onRemoveGirl = new EventEmitter<number>();

  constructor() {
    console.log(this.girl);
  }

  ngOnInit(): void {
  }

  removeGirl(girlId: number) {
    //Call parents remove method
    this.onRemoveGirl.emit(girlId);
  }

}
