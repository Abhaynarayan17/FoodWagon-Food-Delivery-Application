import { Component } from '@angular/core';
import { RegisterDetailsService } from '../register-details.service';
import { FormsModule, NgForm } from '@angular/forms';

@Component({
  selector: 'app-register-restaurant',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './register-restaurant.component.html',
  styleUrl: './register-restaurant.component.css'
})
export class RegisterRestaurantComponent {
  
  constructor(public service:RegisterDetailsService){}

  onRegister(form:NgForm){
    this.service.postRegDetail()
    .subscribe({
      next: res =>{
        console.log(res);
      },
      error: err => {console.log(err)}
    })
    form.reset();
}

}



