import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChildStarComponent } from './child-star-component';

describe('ChildStarComponent', () => {
  let component: ChildStarComponent;
  let fixture: ComponentFixture<ChildStarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ChildStarComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChildStarComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
