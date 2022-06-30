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
  private defailGirl: IGirl;
  girls: IGirl[] = [];

  newGirl: IGirl;

  constructor(private apiService: ApiService) {
    this.defailGirl = {
      name: '',
      url: ''
    } as IGirl;
    this.newGirl = { ... this.defailGirl };
  }

  ngOnInit(): void {
    this.apiService
      .getGirls()
      .subscribe(girls => this.girls = girls.reverse());
  }

  parentRemoveGirl(girlId: number) {
    this.apiService
      .removeGirls(girlId)
      .subscribe(reponse => {
        if (reponse) {
          this.girls = this.girls.filter(x => x.id != girlId);
        }
      });
  }

  createGirl() {
    this.apiService
      .createGirls(this.newGirl)
      .subscribe((girl: IGirl) => {
        this.girls.unshift(girl);
        this.newGirl = { ... this.defailGirl };
      });
  }

  clearGirl() {
    this.newGirl = { ... this.defailGirl };
  }
}
