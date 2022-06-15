import { UserService } from './../../services/user.service';
import { IRoom } from 'src/models/IRoom';
import { Component, OnInit, AfterViewInit} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RoomService } from 'src/services/room.service';
import { CommonModule } from '@angular/common';  
import { BrowserModule } from '@angular/platform-browser';
import { DetailMembersComponent } from '../detail-members/detail-members.component';
import * as signalR from "@microsoft/signalr"
import { IUser } from 'src/models/IUser';

@Component({
  selector: 'app-room-detail',
  templateUrl: './room-detail.component.html',
  styleUrls: ['./room-detail.component.scss']
})
export class RoomDetailComponent implements OnInit{

  room!:IRoom;
  private hubConnection!: signalR.HubConnection;

  constructor(private _activeRoute: ActivatedRoute,
    private _roomService: RoomService,
    private _userService: UserService) { }


  ngOnInit(): void {
    this.getRoom();
    this.startConnection();
    }

  getRoom(): void{
    const id = Number(this._activeRoute.snapshot.paramMap.get('id'));
    this._roomService.getRoom(id)
    .subscribe(room => this.room = room);
  }


  userConnect(group: number){
    this.hubConnection.invoke("UserConnect", group);
  }

  startConnection(){
    this.hubConnection = new signalR.HubConnectionBuilder()
                            .withUrl('http://localhost:42059/guessArt')
                            .build();
    this.hubConnection
      .start()
      .then(() => {
        this.userConnect(this.room.id);
      })
      .catch(err => console.log('Error while starting connection: ' + err))

      this.hubConnection.on('UserJoin', (userName: string, userId: number) => {
        this._userService.getUser(userId)
        .subscribe(user => this.room.members.push(user));
      })
  }

}
