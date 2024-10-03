import { Component, OnInit } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { catchError, of, tap } from 'rxjs';
import { Router } from '@angular/router';
import { RegisterDetailsService } from '../register-details.service';

@Component({
  selector: 'app-login-restaurant',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login-restaurant.component.html',
  styleUrl: './login-restaurant.component.css'
})
export class LoginRestaurantComponent implements OnInit{
  constructor(public service: RegisterDetailsService, private router: Router,){
  }
  ngOnInit(): void {
  }
  onLoginRestro(form:NgForm){
    console.log(form.value);
    this.service.login(form.value).pipe(
      tap((res: any) => {
        localStorage.setItem('token', res.token)
        localStorage.setItem('emailId', this.service.formData.emailID);
        this.router.navigateByUrl('restauranthome');
       
      }),
      catchError((err) => {
        if(err.status == 401 || err.status == 400) {
          // this.toaster.error('Incorrect username or password.', 'Authentication Failed');
          console.log("Invalid Username or password.");
        }
        else {
          console.log(err);
        }
        return of(null);
      })
    ).subscribe();
  }
}


