import { HttpClient, HttpHeaders} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, of, tap } from 'rxjs';
import { SiteRole } from './models/enums/SiteRole';
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

  blockUser(id : number) : Observable<boolean>{
    var url = this.userUrl + "/Social/BlockUserApi?id=" + id;
    return this.http.get<boolean>(url);
  }

  unblockUser(id : number) : Observable<Boolean>{
    return this.http.get<boolean>(this.userUrl + "/Social/UnblockUserApi?id=" + id);
  }

  changeUserRole(id : number, role : string ){
    return this.http.get<boolean>(this.userUrl + `/Social/ChangeRole?id=${id}&role=${role}`);
  }

  searchUsers(term: string): Observable<IUser[]> {
    if (!term.trim()) {
      // if not search term, return empty hero array.
      return of([]);
    }
    return this.http.get<IUser[]>(`${this.userUrl}/Social/FindUserByName?name=${term}`).pipe(
      tap(x => x.length ?
        console.log(`found user matching "${term}"`):
        console.log(`no users matching "${term}"`)),
    );
  }
}

