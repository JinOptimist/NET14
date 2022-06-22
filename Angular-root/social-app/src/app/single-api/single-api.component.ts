import { IApi } from './../models/IApi';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-single-api',
  templateUrl: './single-api.component.html',
  styleUrls: ['./single-api.component.scss']
})
export class SingleApiComponent implements OnInit {
  @Input() Api!: IApi;
  constructor() { }

  ngOnInit(): void {
  }

}
