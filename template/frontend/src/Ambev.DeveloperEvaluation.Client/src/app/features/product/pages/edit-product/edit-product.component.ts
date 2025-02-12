import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { first } from 'rxjs/operators';

import { ToastService } from '../../../../shared/services/toast/toast.service';
import { ProductApiService } from '../../api/product.api';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent {
  loading = false;
  submitted = false;

  constructor(
    private readonly service: ProductApiService,
    private readonly router: Router,    
    private readonly toastr: ToastService) { }

  save(product: any) {
    this.service.update(product.id, product)
      .pipe(first())
      .subscribe({
        next: (v) => { },
        error: (error) => {
          if (error.status === 400) {
            this.toastr.warning('Não foi possível alterar produto. Verifique as mensagens.');
          }
          else {
            this.toastr.error('Ocorreu um erro ao alterar produto.');
          }
        },
        complete: () => {

          this.toastr.success('Produto alterado com sucesso.');
          this.router.navigate(['/product']);
        }
      })
  }
}
