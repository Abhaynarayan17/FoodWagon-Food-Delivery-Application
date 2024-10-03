import { Injectable } from '@angular/core';
import { environment } from '../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { CustomerLoginDetails } from './models/customer-login-details.model';

@Injectable({
  providedIn: 'root'
})
export class CustomerLoginDetailsService {
  url:string = environment.apiBaseUrl+'/RestroRegistration'

  constructor(private http: HttpClient) { }
  Restrolist:CustomerLoginDetails[] = [];
  formData:CustomerLoginDetails = new CustomerLoginDetails();
  refreshList(){
    this.http.get(this.url)
    .subscribe({
      next: res => {
        this.Restrolist = res as CustomerLoginDetails[];
      },
      error:err=>{console.log(err)}   
    })
  }

  postCustomerLoginDetails(){
    return this.http.post(this.url,this.formData)
  }}



