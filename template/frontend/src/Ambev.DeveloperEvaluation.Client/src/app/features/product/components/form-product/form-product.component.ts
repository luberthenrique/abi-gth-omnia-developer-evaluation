import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';

import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertService } from '../../../../shared/services/alert/alert.service';
import { ProductApiService } from '../../api/product.api';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-form-product',
  templateUrl: './form-product.component.html',
  styleUrls: ['./form-product.component.css']
})
export class FormProductComponent implements OnInit {
  form!: FormGroup;

  loading = false;
  submitted = false;

  @Output() salvar = new EventEmitter<any>();
  @Input() public edit: boolean = false;
  @Output() changeFormEmitter = new EventEmitter<boolean>();

  contoleEditando = AbstractControl;

  constructor(
    private readonly productService: ProductApiService,
    private readonly formBuilder: FormBuilder,
    private readonly alertService: AlertService,
    private readonly route: ActivatedRoute) {

  }

  ngOnInit() {
    this.form = this.formBuilder.group({
      id: [null],
      name: ['', Validators.required],
      price: [0, Validators.required],
    });
    let initialFormValue = this.form.value;

    this.form.valueChanges.subscribe(formWithChanges => {
      this.changeFormEmitter.emit(JSON.stringify(initialFormValue) !== JSON.stringify(formWithChanges))
    });

    if (this.edit) {
      const id = this.route.snapshot.paramMap.get('id');
      this.productService.getById(id)
        .subscribe(result => {

          this.form.patchValue(result.data, { emitEvent: false });
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

    let product = this.form.value;

    this.salvar.emit(product);
  }

  
  protected getProduct() {
    return {
      id: this.f['id'].value,
      name: this.f['name'].value,
      price: this.f['price'].value,
    }
  }
}
