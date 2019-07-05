import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MailLoginComponent } from './mail-login.component';

describe('MailLoginComponent', () => {
  let component: MailLoginComponent;
  let fixture: ComponentFixture<MailLoginComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MailLoginComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MailLoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
