import { Component, OnInit } from '@angular/core';
import { ShoppingCartService } from '../shared/shopping-cart.service';
import { NgForm } from "@angular/forms";
import { Product } from '../shared/product.model';
import { Cart } from '../shared/cart.model';


@Component({
  selector: 'app-shopping-cart-main',
  templateUrl: './shopping-cart-main.component.html',
  styleUrls: ['./shopping-cart-main.component.css']
})
export class ShoppingCartMainComponent implements OnInit {

  constructor(public service:ShoppingCartService) { }

  ngOnInit(): void {
    this.service.populateProductCategories();    
    this.service.loadCarts()
    

  }

  ngAfterViewInit(){
    console.log(this.service.listProducts);
  }

  getListDefaultProductList(id:number){
    this.service.poplateProducts(id);
  }

  categorySelected(id:number){
    this.service.poplateProducts(id);
  }

  deleteCartItem(id:number){
    this.service.deleteCartItem(id).subscribe(
      res=>{
        this.service.orderTotal =0;
        this.service.loadCarts();
      },
      err=>{

      }
    );
  }

  addToCart(product:Product){
    let cart= new Cart();
    cart.itemName = product.productName,
    cart.price=product.price,
    cart.quantity=1,
    cart.subTotal=product.price*1;    

    this.service.orderTotal =0;

    this.service.addToCart(cart).subscribe(
      res=>{
        this.service.loadCarts();
      },
      err=>{
        console.log(err)
      }
    );
  }

  quantityChange(listCarts:Cart[]){   
    this.service.calculateOrderTotal(listCarts);
  }

  

  

}
