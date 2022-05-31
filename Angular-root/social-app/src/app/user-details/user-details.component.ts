import { UserService } from './../user.service';
import { IUser } from './../models/IUser';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {ThemePalette} from '@angular/material/core';


@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.scss']
})
export class UserDetailsComponent implements OnInit {

  user! : IUser;
  serverUrl : string = "http://localhost:42059/";

  constructor(private _activatedroute : ActivatedRoute,
    private _userService : UserService) { }

  ngOnInit(): void {
    this.GetUser();
  }

  GetUser() : void {
    const id = Number(this._activatedroute.snapshot.paramMap.get('id'));
    this._userService.getUser(id)
    .subscribe(user => this.user = user);
  }

  blockUser(id : number){
    this._userService.blockUser(id);
  }

}
