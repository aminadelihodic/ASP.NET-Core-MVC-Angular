import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrikaziProizvodjaceComponent } from './prikazi-proizvodjace.component';

describe('PrikaziProizvodjaceComponent', () => {
  let component: PrikaziProizvodjaceComponent;
  let fixture: ComponentFixture<PrikaziProizvodjaceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrikaziProizvodjaceComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PrikaziProizvodjaceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
