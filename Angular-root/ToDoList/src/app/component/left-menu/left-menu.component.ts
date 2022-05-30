import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'left-menu',
  templateUrl: './left-menu.component.html',
  styleUrls: ['./left-menu.component.scss']
})
export class LeftMenuComponent implements OnInit {

  folders: string [];

  constructor() {

    this.folders = [
      'English',
      'Coding',
      'School',
      'Work',
      'Have a rest'
    ];
  }

  ngOnInit(): void {
  }

}
