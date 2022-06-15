import { RoomType } from './../../models/RoomType';
import { IRoom } from './../../models/IRoom';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-single-room',
  templateUrl: './single-room.component.html',
  styleUrls: ['./single-room.component.scss']
})
export class SingleRoomComponent implements OnInit {
  @Input() Room!: IRoom;
  LOGO = "./../../images/programming.png";

  constructor() { }

  ngOnInit(): void {

  }

}
