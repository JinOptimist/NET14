import { Component, OnInit } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { IFolder } from 'src/models/IFolder';

@Component({
  selector: 'left-menu',
  templateUrl: './left-menu.component.html',
  styleUrls: ['./left-menu.component.scss']
})
export class LeftMenuComponent implements OnInit {

  folders: IFolder[] = [];

  constructor(private http: HttpClient) {
    http
      .get<IFolder[]>('http://localhost:42059/api/ToDoList/GetFolders')
      .subscribe(response => this.folders = response);
  }

  ngOnInit(): void {
  }

}
