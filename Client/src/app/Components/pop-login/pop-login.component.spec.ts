import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PopLoginComponent } from './pop-login.component';

describe('PopLoginComponent', () => {
  let component: PopLoginComponent;
  let fixture: ComponentFixture<PopLoginComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PopLoginComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PopLoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
