import { Component, OnInit } from '@angular/core';
import { IGirl } from 'src/models/IGirl';

@Component({
  selector: 'add-girl',
  templateUrl: './add-girl.component.html',
  styleUrls: ['./add-girl.component.scss']
})
export class AddGirlComponent implements OnInit {
  girl: IGirl;

  constructor() {
    this.girl = {} as IGirl;
  }

  ngOnInit(): void {
  }

}
