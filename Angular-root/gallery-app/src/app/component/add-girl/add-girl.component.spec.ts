import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddGirlComponent } from './add-girl.component';

describe('AddGirlComponent', () => {
  let component: AddGirlComponent;
  let fixture: ComponentFixture<AddGirlComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddGirlComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddGirlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
