import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChilddetailComponent } from './childdetail.component';

describe('ChilddetailComponent', () => {
  let component: ChilddetailComponent;
  let fixture: ComponentFixture<ChilddetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChilddetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChilddetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
