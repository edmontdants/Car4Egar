import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyBorrowingsComponent } from './my-borrowings.component';

describe('MyBorrowingsComponent', () => {
  let component: MyBorrowingsComponent;
  let fixture: ComponentFixture<MyBorrowingsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MyBorrowingsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MyBorrowingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
