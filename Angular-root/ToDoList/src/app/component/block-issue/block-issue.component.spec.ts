import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BlockIssueComponent } from './block-issue.component';

describe('BlockIssueComponent', () => {
  let component: BlockIssueComponent;
  let fixture: ComponentFixture<BlockIssueComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BlockIssueComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BlockIssueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
