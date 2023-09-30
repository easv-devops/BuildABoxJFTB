import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-create-box',
  templateUrl: './create-box.component.html',
  styleUrls: ['./create-box.component.scss'],
})
export class CreateBoxComponent  implements OnInit {

  constructor() { }

  ngOnInit() {}

  title = new FormControl('', [
    Validators.required,
    Validators.minLength(5)
  ]);

  description = new FormControl('', [
    Validators.required,
    Validators.minLength(5)
  ]);

  price = new FormControl('', [
    Validators.required,
  ]);

  imageUrl = new FormControl('', [
    Validators.required,
  ]);

  width = new FormControl('', [
    Validators.required,
  ]);

  length = new FormControl('', [
    Validators.required,
  ]);

  height = new FormControl('', [
    Validators.required,
  ]);

  formControlGroup = new FormGroup({
    title: this.title,
    description: this.description,
    price: this.price,
    imageUrl: this.imageUrl,
    width: this.width,
    length: this.length,
    height: this.height
  });


  createBox() {
    //todo lav det senere
  }
}
