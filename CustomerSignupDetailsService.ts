import { Injectable } from '@angular/core';
import { environment } from '../environments/environment.development';
import { HttpClient, } from '@angular/common/http';
import { CustomerSignupDetails } from './models/customer-signup-details.model';

@Injectable({
  providedIn: 'root'
})
export class CustomerSignupDetailsService {


  url:string = environment.apiBaseUrl+'/Signups'

  constructor(private http: HttpClient) { }
  
  formData:CustomerSignupDetails = new CustomerSignupDetails();

  postCustomerSignupDetails(){
    return this.http.post(this.url,this.formData)
  }

  CLogin(formData: any) {
    return this.http.post(this.url+'/Login',formData)
  }
  
}

