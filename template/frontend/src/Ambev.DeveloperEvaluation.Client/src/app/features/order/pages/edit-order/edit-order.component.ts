import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { first } from 'rxjs/operators';

import { ToastService } from '../../../../shared/services/toast/toast.service';
import { OrderApiService } from '../../api/order.api';

@Component({
  selector: 'app-edit-order',
  templateUrl: './edit-order.component.html',
  styleUrls: ['./edit-order.component.css']
})
export class EditOrderComponent {
  loading = false;
  submitted = false;

  constructor(
    private readonly service: OrderApiService,
    private readonly router: Router,    
    private readonly toastr: ToastService) { }

  save(order: any) {
    this.service.update(order.id, order)
      .pipe(first())
      .subscribe({
        next: (v) => { },
        error: (error) => {
          if (error.status === 400) {
            this.toastr.warning('Não foi possível alterar pedido. Verifique as mensagens.');
          }
          else {
            this.toastr.error('Ocorreu um erro ao alterar pedido.');
          }
        },
        complete: () => {

          this.toastr.success('Pedido alterado com sucesso.');
          this.router.navigate(['/order']);
        }
      })
  }
}
