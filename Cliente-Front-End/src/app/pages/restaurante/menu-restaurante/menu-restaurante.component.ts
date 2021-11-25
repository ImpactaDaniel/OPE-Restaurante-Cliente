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

  public columnsToDisplayMainDishes = ['mainDishphoto', 'mainDishName', 'mainDishDescription', 'mainDishPrice', 'mainDishDetails']
  public columnsToDisplaySideDishes = ['sideDishphoto', 'sideDishName', 'sideDishDescription', 'sideDishPrice', 'sideDishDetails']
  public columnsToDisplayBeverages = ['beveragePhoto', 'beverageName', 'beverageDescription', 'beveragePrice', 'beverageDetails']
  public columnsToDisplayDesserts = ['dessertPhoto', 'dessertName', 'dessertDescription', 'dessertPrice', 'dessertDetails']

  public expandedElement: any;
  public mainDishesProducts = new MatTableDataSource<any>();
  public sideDishesProducts = new MatTableDataSource<any>();
  public beveragesProducts = new MatTableDataSource<any>();
  public dessertsProducts = new MatTableDataSource<any>();

  constructor(@Inject('BASE_URL') public url: string, private restauranteService: RestauranteService) { }

  ngOnInit(): void {
    // this.mainDishesProducts.data = this.data?.invoice?.products;
    this.getProductList();
  }

  private getProductList() {

    // if (this.isSearching) {
    //     //
    //   });
    //   return;
    // }
    this.restauranteService.getAllProducts().subscribe(res => {
      console.log(res[0])
      this.dessertsProducts.data = res[0].products;
      // this.sideDishesProducts.data = res[1].products;
      this.mainDishesProducts.data = res[2].products;
      // this.beveragesProducts = res[3];
      
      // this.listSize = res.response.result.size;
    })
  }

  public changePaginator(event: any) {
    this.limit = event.pageSize;
    this.page = event.pageIndex;
    this.getProductList();
  }

  public search(event: any){
    // this.searchValue = !isNaN(event.value) ? event.value : event.target.value;

    // this.isSearching = true;
    // this.page = 0;
    // this.limit = 5;
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

}
