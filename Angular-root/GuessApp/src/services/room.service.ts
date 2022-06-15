import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { IRoom } from 'src/models/IRoom';

@Injectable({
  providedIn: 'root'
})
export class RoomService {

  private apiUrl : string  = 'http://localhost:42059/api';

  constructor(private _http : HttpClient) { }

  getRooms() : Observable<IRoom[]>{
    return this._http.get<IRoom[]>(this.apiUrl + "/GuessArt/GetRooms");
  }

  getRoom(id: number) : Observable<IRoom>{
    return this._http.get<IRoom>(this.apiUrl + `/GuessArt/GetSingleRoom?id=${id}`);
  }
}
