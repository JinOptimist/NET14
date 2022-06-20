import { AuthService } from './../../services/auth.service';
import { IUserAuth } from './../../models/IUserAuth';
import { IUser } from './../../models/IUser';
import { Component, OnInit } from '@angular/core';
import {MatFormFieldModule} from '@angular/material/form-field';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  user: IUserAuth
  
  constructor(private _authService: AuthService) { 
    this.user = {} as IUserAuth;
  }

  ngOnInit(): void {
  }

  login(){
    this._authService.login(this.user)
    .subscribe(result => {
      debugger;
      if(result){
        alert("Log");
      }
    })
  }

}
