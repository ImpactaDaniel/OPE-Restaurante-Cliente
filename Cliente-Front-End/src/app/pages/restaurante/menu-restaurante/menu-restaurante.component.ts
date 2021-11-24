import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-menu-restaurante',
  templateUrl: './menu-restaurante.component.html',
  styleUrls: ['./menu-restaurante.component.css']
})
export class MenuRestauranteComponent implements OnInit {

  public columnsToDisplayMainDishes = ['mainDishphoto', 'mainDishName', 'mainDishDescription', 'mainDishPrice', 'mainDishDetails']
  public columnsToDisplaySideDishes = ['sideDishphoto', 'sideDishName', 'sideDishDescription', 'sideDishPrice', 'sideDishDetails']
  public columnsToDisplayBeverages = ['beveragePhoto', 'beverageName', 'beverageDescription', 'beveragePrice', 'beverageDetails']
  public columnsToDisplayDesserts = ['dessertPhoto', 'dessertName', 'dessertDescription', 'dessertPrice', 'dessertDetails']

  public expandedElement: any;
  public mainDishesProducts = new MatTableDataSource<any>();
  public sideDishesProducts = new MatTableDataSource<any>();
  public beveragesProducts = new MatTableDataSource<any>();
  public dessertsProducts = new MatTableDataSource<any>();

  constructor() { }

  ngOnInit(): void {
    // this.mainDishesProducts.data = this.data?.invoice?.products;
    // this.sideDishesProducts.data = this.data?.invoice?.products;
    // this.beveragesProducts.data = this.data?.invoice?.products;
    // this.dessertsProducts.data = this.data?.invoice?.products;
  }

}
