import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailMembersComponent } from './detail-members.component';

describe('DetailMembersComponent', () => {
  let component: DetailMembersComponent;
  let fixture: ComponentFixture<DetailMembersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetailMembersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailMembersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
