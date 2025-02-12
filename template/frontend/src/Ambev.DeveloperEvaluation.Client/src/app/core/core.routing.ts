import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'order',
    loadChildren: () => import('../features/order/order.module').then(x => x.OrderModule)
  },  
  {
    path: 'product',
    loadChildren: () => import('../features/product/product.module').then(x => x.ProductModule)
  },  
  {
    path: '',
    loadChildren: () => import('../features/home/home.module').then(x => x.HomeModule)
  },
];


@NgModule({
  imports: [RouterModule.forRoot(routes, {})],
  exports: [RouterModule]
})
export class CoreRoutingModule { }

