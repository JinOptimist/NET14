import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/sevices/apiService';
import { IUser } from 'src/models/IUser';


@Component({
  selector: 'block-for-user',
  templateUrl: './block-for-user.component.html',
  styleUrls: ['./block-for-user.component.scss']
})
export class BlockForUserComponent implements OnInit {

  // user!: IUser;
  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    // this.apiService
    //   .getUser()
    //   .subscribe(x => this.user = x);
  }

}
