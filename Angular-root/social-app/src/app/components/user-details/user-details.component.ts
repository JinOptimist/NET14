import { UserService } from './../../user.service';
import { IUser } from './../../models/IUser';
import { SiteRole } from './../../models/enums/SiteRole';
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
  SiteRole = SiteRole;

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
    this._userService.blockUser(id)
    .subscribe(resp => {
      if(resp){
        this.user.isBlocked = true;
      }
      else{
        console.log("User block error");
      }
    });
  }

  unblockUser(id : number){
    this._userService.unblockUser(id)
    .subscribe(resp => {
      if(resp){
        this.user.isBlocked = false;
      }
      else{
        console.log("User unblock error");
      }
    });
  }

  adminRole(id: number, role : string){
    this._userService.changeUserRole(id, role)
    .subscribe(resp => {
      if(resp){
        this.GetUser();
      }
      else{
        console.log("Admin role erorr");
      }
    })
  }

  enumToBitValues(checRole: string){
    var roles = this.user.role.toString().split(", ");
    return roles.indexOf(checRole.toString()) != -1;
  }

}
