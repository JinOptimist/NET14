import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IFolder } from "src/models/IFolder";
import { IIssue } from "src/models/IIssue";
import { IUser } from "src/models/IUser";

@Injectable({
    providedIn: 'root'
})

export class ApiService{
    private localhost = 'http://localhost:42059';

    constructor(private http: HttpClient){

    }

    getIssues(): Observable<IIssue[]>{
        return this.http
            .get<IIssue[]>(`${this.localhost}/api/ToDoList/GetIssues`);
    }
    getFolders(): Observable<IFolder[]>{
        return this.http
            .get<IFolder[]>(`${this.localhost}/api/ToDoList/GetFolders`);
    }
    createIssue(issue: IIssue): Observable<IIssue>{
        return this.http
            .post<IIssue>(
                `${this.localhost}/api/ToDoList/CreateIssue`,
                issue);
    }
    removeIssue(issueId: number): Observable<boolean>{
        return this.http
            .get<boolean>(`${this.localhost}/api/ToDoList/removeIssue?id=${issueId}`);
    }
    getUser(): Observable<IUser>{
        return this.http
            .get<IUser>(`${this.localhost}/api/ToDoList/GetUser`);
    }
}

