import { Injectable } from '@angular/core';
import { environment } from '../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { LoginDetails } from './models/login-details.model';

@Injectable({
  providedIn: 'root'
})
export class LoginDetailsService {
  url:string = environment.apiBaseUrl+'/Registrations'

  constructor(private http: HttpClient) { }
  Restrolist:LoginDetails[] = [];
  formData:LoginDetails = new LoginDetails();
  refreshList(){
    this.http.get(this.url)
    .subscribe({
      next: res => {
        this.Restrolist = res as LoginDetails[];
      },
      error:err=>{console.log(err)}   
    })
  }

  postRestaurantLoginDetail(){
    return this.http.post(this.url,this.formData)
  }


}


