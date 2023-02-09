import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DepartmentSectionComponent } from './department-section.component';

describe('DepartmentSectionComponent', () => {
  let component: DepartmentSectionComponent;
  let fixture: ComponentFixture<DepartmentSectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DepartmentSectionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DepartmentSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
