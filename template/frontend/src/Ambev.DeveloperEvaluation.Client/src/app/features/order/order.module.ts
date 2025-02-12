import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FormOrderComponent } from './components/form-order/form-order.component';
import { EditOrderComponent } from './pages/edit-order/edit-order.component';
import { ListOrderComponent } from './pages/list-order/list-order.component';
import { NewOrderComponent } from './pages/new-order/new-order.component';
import { OrderRoutingModule } from './order-routing.module';
import { SharedModule } from '../../shared/shared.module';
import { FormOrderItemComponent } from './components/form-order-item/form-order-item.component';


@NgModule({
  declarations: [    
    FormOrderComponent,
    FormOrderItemComponent,
    ListOrderComponent,
    NewOrderComponent,
    EditOrderComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule,
    OrderRoutingModule    
  ],
  exports: [
  ]
})
export class OrderModule { }
