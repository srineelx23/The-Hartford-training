import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Firstcomponent } from './firstcomponent';

describe('Firstcomponent', () => {
  let component: Firstcomponent;
  let fixture: ComponentFixture<Firstcomponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Firstcomponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Firstcomponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
