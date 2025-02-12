import { HttpClient } from '@angular/common/http';
import { Component, Input } from '@angular/core';
import { FormControl } from '@angular/forms';
import { FormValidations } from '../../form-validations';


@Component({
  selector: 'app-error-msg',
  templateUrl: './error-msg.component.html',
  styleUrls: ['./error-msg.component.css']
})
export class ErrorMsgComponent{

  @Input() label = '';
  @Input() submitted = false;
  @Input() control = new FormControl();

  constructor(private httpClient: HttpClient) { }

  get errorMessage(): any{
    
    for (const propertyName in this.control.errors){
      if (this.control.errors.hasOwnProperty(propertyName) &&
        (this.control.dirty || this.submitted)) {
        return FormValidations.getErrorMsg(this.label, propertyName, this.control.errors[propertyName]);
      }
    }
    return null;
  }
}
