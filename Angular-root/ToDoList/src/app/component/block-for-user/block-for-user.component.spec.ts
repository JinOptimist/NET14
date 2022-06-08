import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BlockForUserComponent } from './block-for-user.component';

describe('BlockForUserComponent', () => {
  let component: BlockForUserComponent;
  let fixture: ComponentFixture<BlockForUserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BlockForUserComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BlockForUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
