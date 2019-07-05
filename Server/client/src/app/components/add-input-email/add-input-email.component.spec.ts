import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddInputEmailComponent } from './add-input-email.component';

describe('AddInputEmailComponent', () => {
  let component: AddInputEmailComponent;
  let fixture: ComponentFixture<AddInputEmailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddInputEmailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddInputEmailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
