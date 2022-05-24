import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GirlsGalleryComponent } from './girls-gallery.component';

describe('GirlsGalleryComponent', () => {
  let component: GirlsGalleryComponent;
  let fixture: ComponentFixture<GirlsGalleryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GirlsGalleryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GirlsGalleryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
