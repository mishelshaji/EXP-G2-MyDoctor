import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NavbarPatientComponent } from './navbar-patient.component';

describe('NavbarPatientComponent', () => {
  let component: NavbarPatientComponent;
  let fixture: ComponentFixture<NavbarPatientComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NavbarPatientComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NavbarPatientComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
