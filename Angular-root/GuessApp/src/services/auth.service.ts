import { IUserAuth } from './../models/IUserAuth';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable, BehaviorSubject} from 'rxjs';
import { IToken } from 'src/models/IToken';


@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private authApiUrl : string  = 'http://localhost:42059/token';

  constructor(private _http: HttpClient) { }

  login(user: IUserAuth) : Observable<Boolean>{

    return this._http.post<IToken>(this.authApiUrl, user)
    .pipe(
      map(result => {
        console.log(result);
        localStorage.setItem("access_token",result.access_token);
        return true
      })
    );
  }

  logout(){
    localStorage.removeItem("access_token");
  }
}
