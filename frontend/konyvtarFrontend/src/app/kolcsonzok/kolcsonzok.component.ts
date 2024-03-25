import { Component, OnInit } from '@angular/core';
import { BaseService } from '../base.service';

@Component({
  selector: 'app-kolcsonzok',
  templateUrl: './kolcsonzok.component.html',
  styleUrls: ['./kolcsonzok.component.css']
})
export class KolcsonzokComponent {

  kolcsonzok:any
  oszlopok=[
    {key:"id", text:"Azonosító", type:"plain"},
    {key:"nev", text:"Név", type:"text"},
    {key:"szulIdo", text:"Születési idő", type:"text"},
  ]

  constructor(private base:BaseService){
    this.base.getKolcsonzok().subscribe(
      (res)=>{
        this.kolcsonzok=res
        console.log("Kölcsönzők:", this.kolcsonzok)
      }
    )
  }
}
