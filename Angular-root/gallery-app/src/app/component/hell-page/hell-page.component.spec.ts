import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HellPageComponent } from './hell-page.component';

describe('HellPageComponent', () => {
  let component: HellPageComponent;
  let fixture: ComponentFixture<HellPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HellPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HellPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
