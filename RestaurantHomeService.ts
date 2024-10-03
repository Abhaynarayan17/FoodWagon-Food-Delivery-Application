import { Injectable } from '@angular/core';
import { environment } from '../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { RestaurantHome } from './models/restaurant-home.model';

@Injectable({
  providedIn: 'root'
})
export class RestaurantHomeService {
  url:string = environment.apiBaseUrl+'/Registerations'

  constructor(private http: HttpClient) { }
  Restrolist:RestaurantHome[] = [];
  formData:RestaurantHome = new RestaurantHome();
  refreshList(){
    this.http.get(this.url)
    .subscribe({
      next: res => {
        this.Restrolist = res as RestaurantHome[];
      },
      error:err=>{console.log(err)}   
    })
  }
  getDetails() {
    return 'Register Details Service is working!';
  }

  postRestaurantRegistrationDetail(){
    return this.http.post(this.url,this.formData)
  }

  login(formData: any){
    return this.http.post(this.url+'/Login',formData)
  }
}
