import { IUser } from './../models/IUser';
import { Component, Input, OnInit } from '@angular/core';
import {Router} from '@angular/router';

@Component({
  selector: 'app-single-user',
  templateUrl: './single-user.component.html',
  styleUrls: ['./single-user.component.scss']
})
export class SingleUserComponent implements OnInit {

  @Input() user! : IUser 
  constructor(private router : Router) { }

  ngOnInit(): void {
  }

  redirect(id: number){
    this.router.navigate(["detail/" + id]);
  }

}
