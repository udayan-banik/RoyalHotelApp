import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowDelPayComponent } from './show-del-pay.component';

describe('ShowDelPayComponent', () => {
  let component: ShowDelPayComponent;
  let fixture: ComponentFixture<ShowDelPayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowDelPayComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowDelPayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
