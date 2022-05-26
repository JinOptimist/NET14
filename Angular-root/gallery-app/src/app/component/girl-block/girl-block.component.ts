import { Component, Input, OnInit } from '@angular/core';
import { IGirl } from 'src/models/IGirl';

@Component({
  selector: 'app-girl-block',
  templateUrl: './girl-block.component.html',
  styleUrls: ['./girl-block.component.scss']
})
export class GirlBlockComponent implements OnInit {
  @Input() girl!: IGirl;
  constructor() {
    console.log(this.girl);
  }

  ngOnInit(): void {
  }

}
