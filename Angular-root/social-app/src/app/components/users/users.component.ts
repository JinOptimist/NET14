import { UserService } from './../../user.service';
import { Component, OnInit } from '@angular/core';
import { IUser } from 'src/app/models/IUser';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit {

  constructor(private _userService : UserService) { }

  users: IUser[] = []
  
  ngOnInit(): void {
    this._userService.getUsers()
    .subscribe(users => this.users = users);
  }

}
