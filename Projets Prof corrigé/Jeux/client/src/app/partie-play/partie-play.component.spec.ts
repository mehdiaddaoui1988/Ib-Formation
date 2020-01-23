import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PartiePlayComponent } from './partie-play.component';

describe('PartiePlayComponent', () => {
  let component: PartiePlayComponent;
  let fixture: ComponentFixture<PartiePlayComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PartiePlayComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PartiePlayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
