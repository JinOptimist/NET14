import { Component, Input, OnInit } from '@angular/core';
import { IFolder } from 'src/models/IFolder';

@Component({
  selector: 'folder-in-content',
  templateUrl: './folder-in-content.component.html',
  styleUrls: ['./folder-in-content.component.scss']
})
export class FolderInContentComponent implements OnInit {

  @Input() folder!: IFolder;
  constructor() { }

  ngOnInit(): void {
  }

}
