import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';  // Import Router for navigation
import { CommonModule } from '@angular/common';
import { MenuService } from '../menu-management.service';

 @Component({
   selector: 'app-menu',
   standalone: true,
   imports: [CommonModule],
   templateUrl: './menu.component.html',
   styleUrls: ['./menu.component.css']
 })
export class MenuComponent implements OnInit {

  MenuDetails: any[] = [];
  restaurantEmail: string = '';
  totalAmount:number = 0;

  constructor(private menuService: MenuService, 
    private router: Router, 
    private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      const email = params['email'];
      if (email) {
        this.restaurantEmail = email;
        this.loadMenuDetails(email);
      }
    });
  }

  loadMenuDetails(email: string): void {
    this.menuService.getMenuByEmail(email).subscribe(
      res => {
        this.MenuDetails = (res as any[]).map(item => ({ ...item, itemCount: 0 }));
        
        console.log(this.MenuDetails);
      },
      err => console.error(err)
    );
  }

  getTotalAmount(): number {
    // Calculate total amount 
    this.totalAmount = this.MenuDetails.reduce((total, item) => total + (item.foodPrice * item.itemCount), 0);
    return this.totalAmount;
  }

  increase(restro:any) {
    restro.itemCount += 1;
  }
  decrease(restro:any) {
    restro.itemCount -= 1;
  } 

  onCheckOut() {
    const selectedItems = this.MenuDetails.filter(item => item.itemCount > 0);
    this.router.navigate(['/ordercheckout'], { state: { items: selectedItems, totalAmount: this.totalAmount } });
  }

  logout(): void {
    localStorage.clear();
    this.router.navigate(['/']);
  }
}
