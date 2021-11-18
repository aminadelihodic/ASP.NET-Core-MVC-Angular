import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DodajProizvodjacaComponent } from './dodaj-proizvodjaca.component';

describe('DodajKorisnikaComponent', () => {
  let component: DodajProizvodjacaComponent;
  let fixture: ComponentFixture<DodajProizvodjacaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DodajProizvodjacaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DodajProizvodjacaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
