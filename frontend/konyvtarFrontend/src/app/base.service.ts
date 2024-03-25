import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BaseService {

  url="http://localhost:7129/api"

  constructor(private http:HttpClient) { }

  getKolcsonzok(){
    return this.http.get(this.url+"/Kolcsonzesek")
  }
}
