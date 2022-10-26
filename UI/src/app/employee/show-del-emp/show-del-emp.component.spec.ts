import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowDelEmpComponent } from './show-del-emp.component';

describe('ShowDelEmpComponent', () => {
  let component: ShowDelEmpComponent;
  let fixture: ComponentFixture<ShowDelEmpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowDelEmpComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowDelEmpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
