import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { first } from 'rxjs/operators';

import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastService } from '../../../../shared/services/toast/toast.service';
import { OrderApiService } from '../../api/order.api';
import { AlertService } from '../../../../shared/services/alert/alert.service';
import { DialogDeleteComponent } from '../../../../shared/components/dialog-delete/dialog-delete.component';

@Component({
  selector: 'app-list-order',
  templateUrl: './list-order.component.html',
  styleUrls: ['./list-order.component.css']
})
export class ListOrderComponent implements OnInit {
  orders = new Array<any>();

  page = 1;
  pageSize = 10;

  constructor(
    private readonly service: OrderApiService,
    private readonly router: Router,
    private readonly toastr: ToastService,
    private readonly alertService: AlertService,
    private readonly modalService: NgbModal
  ) { }

  ngOnInit(): void {
    this.service.getAll()
      .subscribe(result => {
        this.orders = result.data.orders;
      });
  }


  confirmDelete(obj: any): void {
    const modal = this.modalService.open(DialogDeleteComponent, { centered: true });
    modal.componentInstance.data = { titulo: 'produto', identificacao: obj.name, id: obj.id };

    modal.result.then((data) => {
      this.service.delete(obj.id)
        .pipe(first())
        .subscribe({
          next: () => {
            this.toastr.success('Produto excluído com sucesso.');
            this.ngOnInit();
        },
          error: (error) => {
            if (error.status === 400) {
              this.toastr.warning('Não foi possível excluir produto. Verifique as mensagens.');
            }
            else {
              this.toastr.error('Ocorreu um erro ao excluir produto.');
            }

          }
        }) ;

    }, (reason) => {
      // on dismiss
    });  
  }

}
