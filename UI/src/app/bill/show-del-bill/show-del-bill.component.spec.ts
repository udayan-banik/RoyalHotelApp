import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowDelBillComponent } from './show-del-bill.component';

describe('ShowDelBillComponent', () => {
  let component: ShowDelBillComponent;
  let fixture: ComponentFixture<ShowDelBillComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowDelBillComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowDelBillComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
