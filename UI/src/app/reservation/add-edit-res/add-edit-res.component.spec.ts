import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditResComponent } from './add-edit-res.component';

describe('AddEditResComponent', () => {
  let component: AddEditResComponent;
  let fixture: ComponentFixture<AddEditResComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditResComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddEditResComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
