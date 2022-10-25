import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpDatePatientComponent } from './up-date-patient.component';

describe('UpDatePatientComponent', () => {
  let component: UpDatePatientComponent;
  let fixture: ComponentFixture<UpDatePatientComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpDatePatientComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpDatePatientComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
