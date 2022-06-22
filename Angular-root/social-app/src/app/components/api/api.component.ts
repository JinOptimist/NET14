import { IApi } from './../../models/IApi';
import { ApiService } from './../../api.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-api',
  templateUrl: './api.component.html',
  styleUrls: ['./api.component.scss']
})
export class ApiComponent implements OnInit {
  _apis!: IApi[];
  constructor(private _apiService: ApiService) { }

  ngOnInit(): void {
    this._apiService.getApis()
    .subscribe(apis => this._apis = apis);
  }

}
