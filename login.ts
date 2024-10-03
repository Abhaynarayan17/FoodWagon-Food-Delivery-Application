import { Component, OnInit } from '@angular/core';

import { FormsModule, NgForm } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { CustomerSignupDetailsService } from '../customer-signup-details.service';
import { catchError, of, tap } from 'rxjs';
@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {

  constructor(public service: CustomerSignupDetailsService, private router: Router){
  }
  ngOnInit(): void {
  }
  onCLogin(form:NgForm){
    console.log(form.value);
  this.service.CLogin(form.value).pipe(
    tap((res: any) => {
      localStorage.setItem('token', res.token)   //authentication token
      localStorage.setItem('emailId', this.service.formData.emailID);  //customerEmail ID
      this.router.navigate(['/customerhomepage']);
      
    }),
    catchError((err) => {
      if(err.status == 401 || err.status == 400) {
        // this.toaster.error('Incorrect username or password.', 'Authentication Failed');
        console.log("Invalid Email or password.");
      }
      else {
        console.log(err);
      }
      return of(null);
    })
  ).subscribe();


}
}





  

    

