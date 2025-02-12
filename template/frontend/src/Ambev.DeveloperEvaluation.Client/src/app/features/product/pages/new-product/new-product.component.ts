import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { first } from 'rxjs/operators';

import { ToastService } from '../../../../shared/services/toast/toast.service';
import { ProductApiService } from '../../api/product.api';

@Component({
  selector: 'app-new-product',
  templateUrl: './new-product.component.html',
  styleUrls: ['./new-product.component.css']
})
export class NewProductComponent {
  loading = false;
  submitted = false;
  active = 1;
  changesPending: boolean = false;

  constructor(
    private readonly service: ProductApiService,
    private readonly router: Router,    
    private readonly toastr: ToastService) { }

  changeForm(changesPending: boolean) {
    this.changesPending = changesPending;
  }

  save(product: any) {
    this.service.register(product)
      .pipe(first())
      .subscribe({
        next: (v) => { },
        error: (error) => {
          if (error.status === 400) {
            this.toastr.warning('Não foi possível adicionar produto. Verifique as mensagens.');
          }
          else {
            this.toastr.error('Ocorreu um erro ao adicionar produto.');
          }
        },
        complete: () => {
          this.changesPending = false;

          this.toastr.success('Produto adicionado com sucesso.');
          this.router.navigate(['/product']);
        }
      })
  }
}
