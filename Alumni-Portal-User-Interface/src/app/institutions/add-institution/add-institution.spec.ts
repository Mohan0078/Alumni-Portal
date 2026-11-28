import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddInstitution } from './add-institution';

describe('AddInstitution', () => {
  let component: AddInstitution;
  let fixture: ComponentFixture<AddInstitution>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddInstitution]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddInstitution);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
