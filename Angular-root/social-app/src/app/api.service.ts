import { IApi } from './models/IApi';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiUrl : string  = 'http://localhost:42059/api';
  constructor(private http : HttpClient) { }

  getApis() : Observable<IApi[]>{
    return this.http.get<IApi[]>(this.apiUrl + "/Social/GetApis");
  }


}
