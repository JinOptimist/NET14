import { IUser } from './../models/IUser';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private apiUrl : string  = 'http://localhost:42059/api/Social/';

  constructor(private _http : HttpClient) { }

  getUser(id: number){
    return this._http.get<IUser>(this.apiUrl + `GetUser/${id}`);
  }
}
