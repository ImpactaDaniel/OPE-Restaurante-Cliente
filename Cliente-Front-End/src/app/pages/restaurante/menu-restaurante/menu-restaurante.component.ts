import { Component, Inject, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { RestauranteService } from '../services/restaurante.service';

@Component({
  selector: 'app-menu-restaurante',
  templateUrl: './menu-restaurante.component.html',
  styleUrls: ['./menu-restaurante.component.css']
})
export class MenuRestauranteComponent implements OnInit {

  public limit: number = 5;
  public page: number = 0;
  public listSize: number = 0;
  // private isSearching = false;
  // public searchField = "employeeName";
  // public searchValue: string;

  public columnsToDisplayMainDishes = ['photo', 'name', 'accompaniments', 'price', 'details', 'cart', 'quantity']
  public columnsToDisplaySideDishes = ['photo', 'name', 'accompaniments', 'price', 'details', 'cart']
  public columnsToDisplayBeverages = ['photo', 'name', 'accompaniments', 'price', 'details', 'cart']
  public columnsToDisplayDesserts = ['photo', 'name', 'accompaniments', 'price', 'details', 'cart']

  public expandedElement: any;
  public mainDishesProducts = new MatTableDataSource<any>();
  public sideDishesProducts = new MatTableDataSource<any>();
  public beveragesProducts = new MatTableDataSource<any>();
  public dessertsProducts = new MatTableDataSource<any>();

  public mainDishQuantity: number = 0;
  public sideDishQuantity: number = 0;
  public beverageQuantity: number = 0;
  public dessertsQuantity: number = 0;

  constructor(@Inject('BASE_URL') public url: string, private restauranteService: RestauranteService) { }

  ngOnInit(): void {
    this.getProductList();
  }

  private getProductList() {
    this.restauranteService.getAllProducts().subscribe(res => {
      console.log(res[3])
      this.dessertsProducts.data = res[0].products;
      this.sideDishesProducts.data = res[1].products;
      this.mainDishesProducts.data = res[2].products;
      this.beveragesProducts.data = res[3].products;
    })
  }

  public changePaginator(event: any) {
    this.limit = event.pageSize;
    this.page = event.pageIndex;
    this.getProductList();
  }

  public search(event: any){
    this.getProductList();
  }

  public async details(id: number) {
    // let response = await this.employeeService.getEmployeeById(id).toPromise()
    // let employee = response.response.result
    // this.dialog.open(DialogEmployeeComponent, {
    //   maxWidth: '100%',
    //   data: {
    //     employee
    //   }
    // });
  }

  // public searchFieldChanged() {
  //   this.searchValue = "";
  // }

  public removeFilters() {
    // this.isSearching = false;
    // this.searchField = "employeeName";
    // this.searchValue = "";
    this.getProductList();
  }

  public minus(name: string) {

    if (name === 'mainDishes') {
      if (this.mainDishQuantity >= 1) {
        this.mainDishQuantity -= 1
        console.log(this.mainDishQuantity)
      }

    } else if (name === 'sideDishes') {
      if (this.sideDishQuantity >= 1) {
        this.sideDishQuantity -= 1
        console.log(this.sideDishQuantity)
      }
      
    } else if (name === 'beverages') {
      if (this.beverageQuantity >= 1) {
        this.beverageQuantity -= 1
        console.log(this.beverageQuantity)
      }
      
    } else if (name === 'desserts') {
      if (this.dessertsQuantity >= 1) {
        this.dessertsQuantity -= 1
        console.log(this.dessertsQuantity)
      }
      
    }
  }
  public plus() {
    this.mainDishQuantity += 1
    console.log(this.mainDishQuantity)
  }
  
}
