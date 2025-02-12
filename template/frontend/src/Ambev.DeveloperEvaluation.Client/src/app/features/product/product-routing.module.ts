import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { EditProductComponent } from './pages/edit-product/edit-product.component';
import { ListProductComponent } from './pages/list-product/list-product.component';
import { NewProductComponent } from './pages/new-product/new-product.component';


const routes: Routes = [
  {
    path: '',
    component: ListProductComponent,
    //canActivate: [
    //  AuthGuardChild
    //]
  },
  {
    path: 'list',
    component: ListProductComponent,
    //canActivate: [
    //  AuthGuardChild
    //]
  },
  {
    path: 'new',
    component: NewProductComponent,
    //canActivate: [
    //  AuthGuardChild
    //]
  },
  {
    path: 'edit/:id',
    component: EditProductComponent,
    //canActivate: [
    //  AuthGuardChild
    //],
    
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class ProductRoutingModule { }
