import { Injectable } from '@angular/core';
import { environment } from '../environments/environment.development';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { RegisterDetails } from './models/register-details.model';
@Injectable({
  providedIn: 'root'
})
export class RegisterDetailsService {

  url:string = environment.apiBaseUrl+'/Registerations'

  constructor(private http: HttpClient) { } //get and post

  Restrolist:RegisterDetails[] = []; // an array of restauarant details
  formData:RegisterDetails = new RegisterDetails(); // An instance of the RegisterDetails model

  refreshList(){
    this.http.get(this.url)
    .subscribe({
      next: res => {
        this.Restrolist = res as RegisterDetails[];
      },
      error:err=>{console.log(err)}
    })
  }
  //getting restodetails for customer homepage
  getRestroDetails(){
    var tokenHearder = new HttpHeaders({'Authorization':'Bearer' +localStorage.getItem('token')});
    return this.http.get(this.url,{headers : tokenHearder})
  }

//posting details of restaurant 
  postRegDetail(){
    return this.http.post(this.url,this.formData)  
  }
//login resto
  login(formData: any){
    return this.http.post(this.url+'/Login',formData)
  }

}



