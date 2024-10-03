import { Routes } from '@angular/router';
import { RegisterRestaurantComponent } from './register-restaurant/register-restaurant.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { LoginRestaurantComponent } from './login-restaurant/login-restaurant.component';
import { RestaurantHomeComponent } from './restaurant-home/restaurant-home.component';
import { OrderCheckoutComponent } from './order-checkout/order-checkout.component';
import { CustomerHomepageComponent } from './customer-homepage/customer-homepage.component';
import { MenuComponent } from './menu/menu.component';
import { StatusUpdateComponent } from './statusupdate/statusupdate.component';
import { VieworderComponent } from './vieworder/vieworder.component';


export const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'RegisterRestaurant', component: RegisterRestaurantComponent},
    { path: 'Login', component: LoginComponent },
    { path: 'LoginRestaurant', component: LoginRestaurantComponent },
    { path: 'Signup', component: SignupComponent },
    { path: 'customerhomepage', component: CustomerHomepageComponent},
    { path: 'restauranthome', component: RestaurantHomeComponent},
    { path: 'ordercheckout', component: OrderCheckoutComponent},
    { path: 'menu', component: MenuComponent },
    { path: 'statusupdate',component: StatusUpdateComponent},
    { path: 'vieworder', component: VieworderComponent}

];
