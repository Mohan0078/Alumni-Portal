import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InstitutionsList } from './institutions-list';

describe('InstitutionsList', () => {
  let component: InstitutionsList;
  let fixture: ComponentFixture<InstitutionsList>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InstitutionsList]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InstitutionsList);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
