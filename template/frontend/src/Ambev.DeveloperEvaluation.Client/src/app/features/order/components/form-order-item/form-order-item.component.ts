import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BehaviorSubject, debounceTime, distinctUntilChanged } from 'rxjs';
import { ProductApiService } from '../../../product/api/product.api';

@Component({
  selector: 'tr[app-form-order-item]',
  templateUrl: './form-order-item.component.html',
  styleUrls: ['./form-order-item.component.css']
})
export class FormOrderItemComponent implements OnInit {
  form: FormGroup;

  loading = false;
  submitted = false;

  protected products = new Array();
  protected selectedProduct: any;

  @Output() addItemEmitter = new EventEmitter<any>();

  @Input() public set item(item: any) {
    if (this.form && item) {
      const itemAdd = {
        productId: item.productId,
        productName: item.product.name,
        quantity: item.quantity,
        unitPrice: item.unitPrice,
        unitMeasure: item.product.unitMeasure.abbreviation
      };

      this.form.patchValue(itemAdd, { emitEvent: false });

      this.f.quantity.enable();
    }

  };
  @Input() isEditable: boolean;

  public isChecked$ = new BehaviorSubject(false);
  toggleChecked() {
    this.isChecked$.next(!this.isChecked$.value)
  }

  constructor(
    private productService: ProductApiService,
    private formBuilder: FormBuilder) {

  }

  ngOnInit() {
    this.form = this.formBuilder.group({
      id: [0],
      productId: [null, Validators.required],
      price: [{ value: '0', disabled: true }, Validators.required],
      quantity: [{ value: '1', disabled: true }, Validators.required],
      discount: [0]
    });

    this.productService.getAll({ name: '' }).subscribe(result => {
      this.products = result.data.products;
    });

    this.f.productId.valueChanges.subscribe(value => {
      if (value) {
        this.f.quantity.enable();

        this.selectedProduct = this.products.find(c => c.id == value);
        this.f.price.setValue(this.selectedProduct.price);
      }
      else {
        this.f.quantity.disable();
      }
    });

  }

  get f() { return this.form.controls; }

  protected addItem() {

    if (!this.form.valid) {
      return;
    }

    const item: any = {
      id: this.f.id.value,
      productId: this.f.productId.value,
      productName: this.selectedProduct.name,
      quantity: this.f.quantity.value,
      unitPrice: this.selectedProduct.price
    };

    this.resetForm();

    this.addItemEmitter.emit(item);
  }

  private resetForm() {

    this.f.productId.setValue(null);

    this.f.quantity.disable();
    this.f.quantity.setValue(1);
  }

  protected addQuantity() {
    let quantity = parseFloat(this.f.quantity.value);
    this.f.quantity.setValue(quantity + 1);
  }

  protected removeQuantity() {
    let quantity = parseFloat(this.f.quantity.value);

    if (quantity > 1) {

      this.f.quantity.setValue(quantity - 1);
    }
    else if (quantity > 0) {
      this.f.quantity.setValue(0);
    }
  }
}
