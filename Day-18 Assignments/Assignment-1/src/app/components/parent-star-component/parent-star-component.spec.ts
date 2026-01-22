import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ParentStarComponent } from './parent-star-component';

describe('ParentStarComponent', () => {
  let component: ParentStarComponent;
  let fixture: ComponentFixture<ParentStarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ParentStarComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ParentStarComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
