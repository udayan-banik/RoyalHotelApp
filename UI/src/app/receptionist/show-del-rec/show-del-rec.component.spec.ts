import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowDelRecComponent } from './show-del-rec.component';

describe('ShowDelRecComponent', () => {
  let component: ShowDelRecComponent;
  let fixture: ComponentFixture<ShowDelRecComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowDelRecComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowDelRecComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
