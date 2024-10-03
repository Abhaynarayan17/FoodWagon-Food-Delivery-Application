import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { CustomerSignupDetailsService } from '../customer-signup-details.service';

@Component({
  selector: 'app-signup',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css'] // Updated to styleUrls
})
export class SignupComponent implements OnInit {

  alpha: string = "";
  constructor(
    public service: CustomerSignupDetailsService,
    private cdr: ChangeDetectorRef // Inject ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    // Initialize alpha value
    this.alpha = this.generateAlpha();
    // Ensure change detection picks up the initialization
    this.cdr.detectChanges();
  }

  onCustomerSignup(form: NgForm): void {
    console.log("Form data before submission:", form.value);
    this.service.formData.customerID=this.generateAlpha()

    this.service.postCustomerSignupDetails()
      .subscribe({
        next: res => {
          console.log(res);
        },
        error: err => {
          console.log(err);
        }
      });
      form.reset();
  }





  generateRandomString(length: number): string {
    const characters = '0123456789';
    let result = '';
    const charactersLength = characters.length;

    for (let i = 0; i < length; i++) {
      result += characters.charAt(Math.floor(Math.random() * charactersLength));
    }

    return result;
  }

  generateAlpha(): string {
    return this.generateRandomString(6);
  }
  
}
