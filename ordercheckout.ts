import { NgFor } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-order-checkout',
  templateUrl: './order-checkout.component.html',
  standalone: true,
  imports:[NgFor],
    styleUrls: ['./order-checkout.component.css']
})
export class OrderCheckoutComponent implements OnInit {

  items: any[] = [];
  totalAmount: number = 0;

  constructor(private router: Router) {

    const navigation = this.router.getCurrentNavigation();
    const state = navigation?.extras?.state as { items: any[]; totalAmount: number };

    if (state) {
      
      this.items = state.items;
      this.totalAmount = state.totalAmount;
    }
    console.log(this.items)
  }

  ngOnInit(): void {

  }

  onConfirmPurchase(): void {
     console.log('Order confirmed:', this.items, 'Total:', this.totalAmount);
     //post 
     this.router.navigate(['/statusupdate'], { state: { items: this.items, totalAmount: this.totalAmount } });
  }
}
