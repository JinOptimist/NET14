import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FolderInContentComponent } from './folder-in-content.component';

describe('FolderInContentComponent', () => {
  let component: FolderInContentComponent;
  let fixture: ComponentFixture<FolderInContentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FolderInContentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FolderInContentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
