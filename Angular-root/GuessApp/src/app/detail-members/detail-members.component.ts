import { IUser } from './../../models/IUser';
import { Component, Input, OnInit} from '@angular/core';

@Component({
  selector: 'app-detail-members',
  templateUrl: './detail-members.component.html',
  styleUrls: ['./detail-members.component.scss']
})
export class DetailMembersComponent implements OnInit{

  @Input() members! : IUser[];
  constructor() { }

  ngOnInit(): void {
    
  }

  userJoin(user: IUser){
    this.members.push(user);
  }

}
