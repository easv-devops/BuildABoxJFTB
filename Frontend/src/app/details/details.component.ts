import {Component, inject, Input, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Box} from "../boxcard/boxcard";
import {firstValueFrom} from "rxjs";
import {ActivatedRoute, Router} from "@angular/router";

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss'],
})
export class DetailsComponent {

  box: Box | any = {}

  productId: number | undefined;

  constructor(private http: HttpClient, private router: Router, private route: ActivatedRoute) {
 this.getBoxById();
  }



  async getBoxById() {
    const map = await firstValueFrom(this.route.paramMap)
    const id = map.get('id')
    const call = this.http.get<Box>("http://localhost:5000/products/" + id);
    this.box = await firstValueFrom<Box>(call);
  }


  goBack() {
    this.router.navigate(['products/'])
  }

  goToEdit() {
    this.router.navigate(['createBox/'])
  }

  deleteBox() {

  }
}
