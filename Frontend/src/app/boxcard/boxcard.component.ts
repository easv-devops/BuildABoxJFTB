import {Component, Input, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {firstValueFrom} from "rxjs";
import {Box} from "./boxcard";
import {Router} from "@angular/router";

@Component({
  selector: 'app-boxcard',
  templateUrl: './boxcard.component.html',
  styleUrls: ['./boxcard.component.scss'],
})
export class BoxcardComponent  implements OnInit {
  boxes: Box[] = [];

  constructor(private http: HttpClient, private router: Router) {
    this.http = http;
    this.router = router;
  }

  ngOnInit() {
    this.getAllProducts();
  }

  async getAllProducts() {
    const call = this.http.get<Box[]>("http://localhost:5273/products");
    const result = await firstValueFrom<Box[]>(call);
    this.boxes = result;
  }

  @Input() box!: Box;

  goToDetails() {
      this.router.navigate(['details/'+this.box.productID])
  }

}


