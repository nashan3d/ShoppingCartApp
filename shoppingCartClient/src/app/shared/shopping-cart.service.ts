import { Injectable } from '@angular/core';
import { ProductCategory } from './product-category.model';
import { HttpClient } from "@angular/common/http";
import { Product } from './product.model';
import { Cart } from './cart.model';

@Injectable({
  providedIn: 'root'
})
export class ShoppingCartService {

  constructor(private http:HttpClient) { }

  readonly baseUrl =  "https://localhost:5001/api/ProductCategory";
  readonly baseUrl1 = "https://localhost:5001/api/Products";
  readonly baseUrl2 = "https://localhost:5001/api/Cart";
  listProductCategory : ProductCategory[];
  listProducts : Product[];
  listCarts : Cart[];
  orderTotal:number=0;

  populateProductCategories(){
    this.http.get(this.baseUrl)
    .toPromise()
    .then(res=>{
      this.listProductCategory = res as ProductCategory[];
      this.loadDeafultProducts();
    });

    
  }

  poplateProducts(productCategoryId:number){
    this.http.get(`${this.baseUrl1}/${productCategoryId}`)
    .toPromise()
    .then(res=>this.listProducts = res as Product[]);
  }

  loadDeafultProducts(){
    if(this.listProductCategory.length >0){
      this.poplateProducts(this.listProductCategory[0].id);
    }
  }

  addToCart(cart:Cart){
    return this.http.post(this.baseUrl2,cart);
  }

  loadCarts(){
    this.http.get(this.baseUrl2)
    .toPromise()
    .then(res=>{
      this.listCarts = res as Cart[];
      this.calculateOrderTotal(this.listCarts);
    });
  }

  deleteCartItem(id:number){
    return this.http.delete(`${this.baseUrl2}/${id}`);
  }

  calculateOrderTotal(carts:Cart[]){
    carts.forEach(x=>{
      this.orderTotal+=x.subTotal;
    })
  }
}
