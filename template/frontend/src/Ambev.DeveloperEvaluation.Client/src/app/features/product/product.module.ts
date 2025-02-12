import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FormProductComponent } from './components/form-product/form-product.component';
import { EditProductComponent } from './pages/edit-product/edit-product.component';
import { ListProductComponent } from './pages/list-product/list-product.component';
import { NewProductComponent } from './pages/new-product/new-product.component';
import { ProductRoutingModule } from './product-routing.module';
import { SharedModule } from '../../shared/shared.module';


@NgModule({
  declarations: [    
    FormProductComponent,
    ListProductComponent,
    NewProductComponent,
    EditProductComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule,
    ProductRoutingModule    
  ],
  exports: [
  ]
})
export class ProductModule { }
