import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Secondcomponent } from './secondcomponent';

describe('Secondcomponent', () => {
  let component: Secondcomponent;
  let fixture: ComponentFixture<Secondcomponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Secondcomponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Secondcomponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
