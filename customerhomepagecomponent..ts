import { ChangeDetectorRef, Component, Inject, OnInit, PLATFORM_ID } from '@angular/core';
import { RegisterDetailsService } from '../register-details.service';
import { NgFor } from '@angular/common';
import { Router, RouterLink } from '@angular/router';
@Component({
  selector: 'app-customer-homepage',
  standalone: true,
  imports: [NgFor, RouterLink],
  templateUrl: './customer-homepage.component.html',
  styleUrl: './customer-homepage.component.css'
})
export class CustomerHomepageComponent implements OnInit {

  restrodetail: any[] = [];

  constructor (
    public service: RegisterDetailsService,
    private router : Router, 
    private cdr: ChangeDetectorRef) {}

    ngOnInit(): void {
      this.loadRestroDetails();
    }
 
  loadRestroDetails() : void {
    this. service.getRestroDetails().subscribe(
      res => {
        this.restrodetail = res as any[];
      this.cdr.detectChanges();
      console.log(res);
      
      },
      err => console.error(err)
    );
   
  }
cardFunc(email: string) {
    console.log('Selected restaurant email:', email); 
    localStorage.setItem('restroemail',email);
    this.router.navigate(['/menu'], { queryParams: { email: email } });
  }
}
  

