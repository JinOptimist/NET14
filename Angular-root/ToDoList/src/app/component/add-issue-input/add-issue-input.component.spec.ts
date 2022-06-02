import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddIssueInputComponent } from './add-issue-input.component';

describe('AddIssueInputComponent', () => {
  let component: AddIssueInputComponent;
  let fixture: ComponentFixture<AddIssueInputComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddIssueInputComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddIssueInputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
