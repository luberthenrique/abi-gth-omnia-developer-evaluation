import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import {  FormBuilder, FormGroup, Validators } from '@angular/forms';

import { AlertService } from '../../../../shared/services/alert/alert.service';
import { OrderApiService } from '../../api/order.api';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-form-order',
  templateUrl: './form-order.component.html',
  styleUrls: ['./form-order.component.css']
})
export class FormOrderComponent implements OnInit {
  form!: FormGroup;

  loading = false;
  submitted = false;



  @Output() salvar = new EventEmitter<any>();
  @Input() public edit: boolean = false;
  @Output() changeFormEmitter = new EventEmitter<boolean>();

  items = new Array<any>();
  selectedItem: any | null;

  constructor(
    private readonly orderService: OrderApiService,
    private readonly formBuilder: FormBuilder,
    private readonly alertService: AlertService,
    private readonly route: ActivatedRoute) {

  }

  ngOnInit() {
    this.form = this.formBuilder.group({
      id: [null],
      salesNumber: ['', Validators.required],
      orderDate: [new Date().toISOString().split('T')[0], Validators.required],
      client: ['', Validators.required],
      branch: ['', Validators.required],
      isCanceled: [false]
    });

    if (this.edit) {
      const id = this.route.snapshot.paramMap.get('id');
      this.orderService.getById(id)
        .subscribe(result => {

          this.form.patchValue(result.data, { emitEvent: false });
          this.f.orderDate.setValue(new Date(result.data.orderDate).toISOString().split('T')[0]);

          result.data.items.forEach(item => {
            this.items.push(item);
          });
        });
    }
  }

  get f() { return this.form.controls; }

  onSubmit() {
    this.submitted = true;

    // reset alerts on submit
    this.alertService.clear();

    // stop here if form is invalid
    if (this.form.invalid) {
      return;
    }

    this.salvar.emit(this.getOrder());
  }


  protected getOrder() {
    return {
      id: this.f['id'].value,
      salesNumber: this.f['salesNumber'].value,
      orderDate: this.f['orderDate'].value,
      client: this.f['client'].value,
      branch: this.f['branch'].value,
      items: this.items
    }
  }

  addItem(item: any) {

    let quantity: number = item.quantity;
    const product = this.items.find(c => c.productId === item.productId);
    if (product) {
      product.quantity = product.quantity + quantity;
    }
    else {
      this.items.push(item);
    }
  }

  editItem(item: any) {
    this.selectedItem = item;

    this.items = this.items.filter(c => c != item);
  }

  removeItem(item: any) {
    this.items = this.items.filter(c => c != item);
  }

  protected get isEditable() {
    return !this.f.isCanceled.value;
  };
}
