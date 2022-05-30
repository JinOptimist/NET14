import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GirlBlockComponent } from './girl-block.component';

describe('GirlBlockComponent', () => {
  let component: GirlBlockComponent;
  let fixture: ComponentFixture<GirlBlockComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GirlBlockComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GirlBlockComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
