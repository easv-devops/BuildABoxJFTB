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
export class DetailsComponent implements OnInit {
  route: ActivatedRoute = inject(ActivatedRoute);
  productId: number | undefined;

  constructor(private http: HttpClient, private router: Router) {
    this.http = http;
    this.router = router;
  }

  ngOnInit() {
    this.productId = parseInt(this.route.snapshot.params['productID'], 10);
    this.getBoxById();
  }

  async getBoxById() {
    const call = this.http.get<Box>("http://localhost:5000/products/" + this.productId);
    this.box = await firstValueFrom<Box>(call);
  }

  @Input() box!: Box;

  goBack() {
    this.router.navigate(['products/'])
  }

  goToEdit() {
    this.router.navigate(['createBox/'])
  }

  deleteBox() {

  }
}
