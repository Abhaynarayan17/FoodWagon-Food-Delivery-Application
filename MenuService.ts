import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../environments/environment.development';  
import { RestaurantHome } from './models/restaurant-home.model';

interface MenuItem {
  foodId: number;
  foodName: string;
  foodPrice: number;
}

interface MenuResponse {
  menu: MenuItem[];
  restaurantName: string;
}
@Injectable({
  providedIn: 'root'
})
export class MenuService {
  private apiUrl = `${environment.apiBaseUrl}/Menus`;

  constructor(private http: HttpClient) { }
  
  formData:RestaurantHome = new RestaurantHome();

  getMenuByEmail(email: string) {
    const tokenHeader = new HttpHeaders({ 'Authorization': 'Bearer ' + localStorage.getItem('token') });
    return this.http.get(`${this.apiUrl}/email/${email}`, { headers: tokenHeader });
  }
  
  addItem(){
    console.log(this.formData)
    return this.http.post(this.apiUrl,this.formData)
  }
  
  deleteItem(data:number) {
    var tokenHeader = new HttpHeaders({'Authorization':'Bearer '+localStorage.getItem('token')});
    return this.http.delete(`${this.apiUrl}/${(data)}`, { headers: tokenHeader });

  }

}
