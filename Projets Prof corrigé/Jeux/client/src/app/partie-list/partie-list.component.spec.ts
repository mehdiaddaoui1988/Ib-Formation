import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PartieListComponent } from './partie-list.component';

describe('PartieListComponent', () => {
  let component: PartieListComponent;
  let fixture: ComponentFixture<PartieListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PartieListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PartieListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
