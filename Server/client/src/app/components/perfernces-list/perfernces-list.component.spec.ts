import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PerferncesListComponent } from './perfernces-list.component';

describe('PerferncesListComponent', () => {
  let component: PerferncesListComponent;
  let fixture: ComponentFixture<PerferncesListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PerferncesListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PerferncesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
