import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowCanResComponent } from './show-can-res.component';

describe('ShowCanResComponent', () => {
  let component: ShowCanResComponent;
  let fixture: ComponentFixture<ShowCanResComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowCanResComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowCanResComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
