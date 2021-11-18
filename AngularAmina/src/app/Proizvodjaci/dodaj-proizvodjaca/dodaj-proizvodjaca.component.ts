import {Component, Input, OnInit} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../MyConfig';
import {NotificationService} from '../../notification.service';
import { ProizvodjaciVM } from '../models/proizvodjaci-vm';

@Component({
  selector: 'app-dodaj-proizvodjaca',
  templateUrl: './dodaj-proizvodjaca.component.html',
  styleUrls: ['./dodaj-proizvodjaca.component.css']
})
export class DodajProizvodjacaComponent implements OnInit {

  constructor(private http: HttpClient, private notifyService : NotificationService) {}
  @Input()
proizvodjacDodaj: ProizvodjaciVM | null = null;

  /*uloga: string = "Odaberite";
  uloge:string[] = ["Admin","Klijent"];*/

  ngOnInit(): void {
  }

  Spasi() {

    //this.proizvodjacDodaj.uloga = this.uloga;

    this.http.post(MyConfig.adresaServera + "/Admin/AngularProizvodjaci/Create", this.proizvodjacDodaj, MyConfig.httpOpcije)
    .subscribe((result)=>{
      this.notifyService.showSuccess("Podaci o proizvođaču uspješno pohranjeni!", "Dodavanje proizvođača")
      //this.proizvodjacDodaj = new ProizvodjaciVM();
      window.location.reload();
    },
    (errorResponse)=>{
      for(var i in errorResponse.error)
      {
        for(var j in errorResponse.error[i].errors)
          this.notifyService.showError(errorResponse.error[i].errors[j].errorMessage, "Error");
      }

      
    }
    
    );
  }


}
