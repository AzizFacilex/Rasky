import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RideInfoListComponent } from './ride-info-list.component';

describe('RideInfoListComponent', () => {
  let component: RideInfoListComponent;
  let fixture: ComponentFixture<RideInfoListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RideInfoListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RideInfoListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
