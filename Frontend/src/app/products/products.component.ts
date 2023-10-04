import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {firstValueFrom} from "rxjs";
import {Box} from "../boxcard/boxcard";


@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss'],
})
export class ProductsComponent implements OnInit {
  boxes: Box[] = [];

  constructor(private http: HttpClient) {
    this.http = http;
  }



  ngOnInit() {
    this.getAllProducts();
  }

  async getAllProducts() {
    const call = this.http.get<Box[]>("http://localhost:5273/products");
    const result = await firstValueFrom<Box[]>(call);
    this.boxes = result;
  }
}
