import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IGirl } from 'src/models/IGirl';

@Component({
  selector: 'app-girls-gallery',
  templateUrl: './girls-gallery.component.html',
  styleUrls: ['./girls-gallery.component.scss']
})
export class GirlsGalleryComponent implements OnInit {
  girls: IGirl[] = [];

  constructor(private http: HttpClient) {
    http
      .get<IGirl[]>('http://localhost:42059/api/Gallery/GetGirls')
      .subscribe(response => this.girls = response);
  }

  ngOnInit(): void {
  }
}
