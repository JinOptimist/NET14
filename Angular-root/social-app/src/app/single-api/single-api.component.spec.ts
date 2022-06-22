import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SingleApiComponent } from './single-api.component';

describe('SingleApiComponent', () => {
  let component: SingleApiComponent;
  let fixture: ComponentFixture<SingleApiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SingleApiComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SingleApiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
