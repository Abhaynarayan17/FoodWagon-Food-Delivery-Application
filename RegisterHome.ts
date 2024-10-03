import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common'; // Import CommonModule for *ngIf and *ngFor
import { FormsModule, NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { MenuService } from '../menu-management.service';

@Component({
  selector: 'app-restaurant-home',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './restaurant-home.component.html',
  styleUrls: ['./restaurant-home.component.css']
})
export class RestaurantHomeComponent implements OnInit {

  showAddItemForm: boolean = false;
  
  // Initialize an array to hold menu items
  menuItems: any;

  constructor(private router: Router, 
    public service: MenuService, 
    private cdr: ChangeDetectorRef) {}

  ngOnInit(): void {
    this.DisplayFood();
    
  }

  // Show the add item form
  addItem() {
    this.showAddItemForm = true;    //toggles visiblity of the form
  }

  // Handle form submission
  submitItem(form: NgForm) {
    this.service.formData.foodId = Math.floor(Math.random() * 1000000),
    this.service.formData.emailId = localStorage.getItem('emailId')||"",
    this.service.addItem()
      .subscribe({
        next: res => {
          this.DisplayFood();
          console.log(res);
          form.reset();

        },
        error: err => {
          console.error(err);
        }
      });

      form.reset();
  }

  // Handle delete action
  deleteItem(item: any) {
    if (confirm('Are you sure you want to delete this item?'+item)) {
      this.service.deleteItem(item).subscribe({
        next: () => {
          this.DisplayFood();
        },
        error: err => {console.error(err)}
      });
    }

  }

  // Navigate to view orders page
  viewOrders() {
    this.router.navigate(['vieworder']);
  }

  // Handle logout
  logout() {
    this.router.navigateByUrl('');
  }

  DisplayFood(){
    this.service.getMenuByEmail(localStorage.getItem('emailId')||"").subscribe(
      res => {
        this.menuItems = res;
        console.log(res);
        this.cdr.detectChanges();
      },
      err => console.error(err)
    );


  }
}
