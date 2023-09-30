import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IonicModule } from '@ionic/angular';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HomePage } from './home.page';

import { HomePageRoutingModule } from './home-routing.module';
import {ProductsComponent} from "../products/products.component";
import {CreateBoxComponent} from "../create-box/create-box.component";


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    HomePageRoutingModule,
    ReactiveFormsModule
  ],
  exports: [
    HomePage,
    ProductsComponent
  ],
  declarations: [HomePage, ProductsComponent, CreateBoxComponent]
})
export class HomePageModule {}
