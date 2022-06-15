import { IRoom } from './../../models/IRoom';
import { RoomService } from './../../services/room.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-rooms',
  templateUrl: './rooms.component.html',
  styleUrls: ['./rooms.component.scss']
})
export class RoomsComponent implements OnInit {

  rooms!: IRoom[];

  constructor(private _roomService: RoomService) { }

  ngOnInit(): void {
    this._roomService.getRooms()
    .subscribe(rooms => this.rooms = rooms);
  }

}
