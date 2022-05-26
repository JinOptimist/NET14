import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IGirl } from "src/models/IGirl";

@Injectable({
    providedIn: 'root'
 })

export class ApiService{
    private apiServerDomain = 'http://localhost:42059';
    constructor(private http: HttpClient){}

    getGirls(): Observable<IGirl[]>{
        return this.http
            .get<IGirl[]>(`${this.apiServerDomain}/api/Gallery/GetGirls`);
    }
}