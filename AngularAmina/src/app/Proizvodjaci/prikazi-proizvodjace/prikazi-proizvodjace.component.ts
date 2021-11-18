import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { ProizvodjaciVM } from '../models/proizvodjaci-vm';
import {MyConfig} from '../../MyConfig';
import { NotificationService } from 'src/app/notification.service';

@Component({
  selector: 'app-prikazi-proizvodjace',
  templateUrl: './prikazi-proizvodjace.component.html',
  styleUrls: ['./prikazi-proizvodjace.component.css']
})
export class PrikaziProizvodjaceComponent implements OnInit {

  proizvodjaciVM!: ProizvodjaciVM[];
  proizvodjacDodaj: ProizvodjaciVM | null = null;
  trazi: string = "";
  title!: "";
  adresaServera: string = MyConfig.adresaServera;

  constructor(private http: HttpClient, private notifyService : NotificationService) {}

  preuzmiPodatke() {
     this.http.get<ProizvodjaciVM[]>(MyConfig.adresaServera + '/Admin/AngularProizvodjaci?pretraga=' + this.trazi).subscribe((result) => {
      this.proizvodjaciVM = result;
      if(this.proizvodjaciVM.length == 0){
        this.notifyService.showError("Nema rezultata!", "Pretraga")
      }
    });

  }
  ngOnInit(): void{
    this.preuzmiPodatke();
  }

  getProizvodjaci() {
    return this.proizvodjaciVM;
  }

  refreshFilter() {
    this.trazi = "";
    this.preuzmiPodatke();
  }

  dodaj() {
    this.proizvodjacDodaj = new ProizvodjaciVM();
  }

  obrisi(s: ProizvodjaciVM) {
    this.http.get(MyConfig.adresaServera+ "/Admin/AngularProizvodjaci/Delete/"+s.id).subscribe((result)=>{
      let indexOf = this.proizvodjaciVM.indexOf(s);
      this.proizvodjaciVM.splice(indexOf, 1);
      this.notifyService.showError("Podaci o proizvođaču uspješno obrisani!", "Brisanje proizvođača")
    });
  }

  

  pretragaNaziv() {
    this.preuzmiPodatke();
  }



}
