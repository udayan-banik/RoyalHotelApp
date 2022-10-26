import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditGuestComponent } from './add-edit-guest.component';

describe('AddEditGuestComponent', () => {
  let component: AddEditGuestComponent;
  let fixture: ComponentFixture<AddEditGuestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditGuestComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddEditGuestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
