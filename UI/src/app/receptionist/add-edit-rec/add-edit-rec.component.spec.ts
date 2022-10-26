import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditRecComponent } from './add-edit-rec.component';

describe('AddEditRecComponent', () => {
  let component: AddEditRecComponent;
  let fixture: ComponentFixture<AddEditRecComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditRecComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddEditRecComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
