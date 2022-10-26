import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditPayComponent } from './add-edit-pay.component';

describe('AddEditPayComponent', () => {
  let component: AddEditPayComponent;
  let fixture: ComponentFixture<AddEditPayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditPayComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddEditPayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
