import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IGirl } from 'src/models/IGirl';
import { ApiService } from 'src/app/sevices/apiService';

@Component({
  selector: 'app-girls-gallery',
  templateUrl: './girls-gallery.component.html',
  styleUrls: ['./girls-gallery.component.scss']
})
export class GirlsGalleryComponent implements OnInit {
  girls: IGirl[] = [];

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.apiService
      .getGirls()
      .subscribe(girls => this.girls = girls);
  }

  parentRemoveGirl(girlId: number) {
    this.girls = this.girls.filter(x => x.id != girlId);
  }
}
