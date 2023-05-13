import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyPaymentsComponent } from './my-payments.component';

describe('MyPaymentsComponent', () => {
  let component: MyPaymentsComponent;
  let fixture: ComponentFixture<MyPaymentsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MyPaymentsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MyPaymentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
