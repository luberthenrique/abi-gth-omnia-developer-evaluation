import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { EditOrderComponent } from './pages/edit-order/edit-order.component';
import { ListOrderComponent } from './pages/list-order/list-order.component';
import { NewOrderComponent } from './pages/new-order/new-order.component';


const routes: Routes = [
  {
    path: '',
    component: ListOrderComponent,
    //canActivate: [
    //  AuthGuardChild
    //]
  },
  {
    path: 'list',
    component: ListOrderComponent,
    //canActivate: [
    //  AuthGuardChild
    //]
  },
  {
    path: 'new',
    component: NewOrderComponent,
    //canActivate: [
    //  AuthGuardChild
    //]
  },
  {
    path: 'edit/:id',
    component: EditOrderComponent,
    //canActivate: [
    //  AuthGuardChild
    //],
    
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class OrderRoutingModule { }
