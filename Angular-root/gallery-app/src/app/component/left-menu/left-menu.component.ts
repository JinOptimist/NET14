import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'left-menu',
  templateUrl: './left-menu.component.html',
  styleUrls: ['./left-menu.component.scss']
})
export class LeftMenuComponent implements OnInit {

  links: any[];

  constructor() {
    this.links = [
      { text: 'smile', url: 'https://angular.io/api/common/NgForOf' },
      { text: 'google', url: 'https://angular.io/api/common/NgForOf' },
      { text: 'yandex', url: 'https://angular.io/api/common/NgForOf' }
    ];
  }

  ngOnInit(): void {
  }

  addLink() {
    this.links.push(
      {
        text: `link${this.links.length}`,
        url: 'https://angular.io/api/common/NgForOf'
      });
  }

  removeLink(linkText: string) {
    this.links = this.links.filter(x => x.text != linkText);
  }

}
