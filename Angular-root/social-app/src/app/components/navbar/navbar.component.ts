import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import {MatButtonModule} from '@angular/material/button';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  currentUrl : string = "";
  constructor(private router : Router) { }

  ngOnInit(): void {
    this.router.events.subscribe(() => {
      this.currentUrl = this.router.url;
    })
  }

  getCurrentRoute(url : string) : boolean{
    return this.router.url === url;
  }


}
