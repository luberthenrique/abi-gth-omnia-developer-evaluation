import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { first } from 'rxjs/operators';

import { ToastService } from '../../../../shared/services/toast/toast.service';
import { OrderApiService } from '../../api/order.api';

@Component({
  selector: 'app-new-order',
  templateUrl: './new-order.component.html',
  styleUrls: ['./new-order.component.css']
})
export class NewOrderComponent {
  loading = false;
  submitted = false;
  active = 1;
  changesPending: boolean = false;

  constructor(
    private readonly service: OrderApiService,
    private readonly router: Router,    
    private readonly toastr: ToastService) { }

  changeForm(changesPending: boolean) {
    this.changesPending = changesPending;
  }

  save(order: any) {
    this.service.register(order)
      .pipe(first())
      .subscribe({
        next: (v) => { },
        error: (error) => {
          if (error.status === 400) {
            this.toastr.warning('Não foi possível adicionar pedido. Verifique as mensagens.');
          }
          else {
            this.toastr.error('Ocorreu um erro ao adicionar pedido.');
          }
        },
        complete: () => {
          this.changesPending = false;

          this.toastr.success('Pedido adicionado com sucesso.');
          this.router.navigate(['/order']);
        }
      })
  }
}
