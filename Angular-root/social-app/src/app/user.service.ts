import { HttpClient, HttpHeaders} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IUser } from './models/IUser';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private userUrl : string  = 'http://localhost:42059/api';
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http : HttpClient) { }

  getUsers() : Observable<IUser[]>{
    return this.http.get<IUser[]>(this.userUrl + "/Social/GetUsers");
  }

  getUser(id: number) : Observable<IUser>{
    return this.http.get<IUser>(this.userUrl + "/Social/GetUser/" + id);
  }

  blockUser(id : number) : Observable<any>{
    return this.http.post<any>(this.userUrl + "/Social/BlockUserApi?id=" + id, id,  this.httpOptions);
  }
}
