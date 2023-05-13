import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyCarsComponent } from './my-cars.component';

describe('MyCarsComponent', () => {
  let component: MyCarsComponent;
  let fixture: ComponentFixture<MyCarsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MyCarsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MyCarsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
