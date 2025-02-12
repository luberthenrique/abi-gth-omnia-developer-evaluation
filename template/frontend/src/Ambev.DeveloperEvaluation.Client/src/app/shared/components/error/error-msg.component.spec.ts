import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { FormValidations } from '../../form-validations';
import { ErrorMsgComponent } from './error-msg.component';

describe('ErrorMsgComponent', () => {
  let component: ErrorMsgComponent;
  let fixture: ComponentFixture<ErrorMsgComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ErrorMsgComponent],
      imports: [ReactiveFormsModule, HttpClientTestingModule],
    }).compileComponents();

    fixture = TestBed.createComponent(ErrorMsgComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });

  it('should return null if there are no errors', () => {
    component.control = new FormControl('');
    component.label = 'Test Field';
    fixture.detectChanges();

    expect(component.errorMessage).toBeNull();
  });

  it('should return error message if control has errors and is dirty', () => {
    const mockError = 'This field is required';
    spyOn(FormValidations, 'getErrorMsg').and.returnValue(mockError);

    component.control = new FormControl('', { validators: Validators.required });
    component.control.markAsDirty();
    component.control.setErrors({ required: true });
    component.label = 'Test Field';

    fixture.detectChanges();

    expect(FormValidations.getErrorMsg).toHaveBeenCalledWith('Test Field', 'required', true);
    expect(component.errorMessage).toBe(mockError);
  });

  it('should return error message if control has errors and form is submitted', () => {
    const mockError = 'Invalid email format';
    spyOn(FormValidations, 'getErrorMsg').and.returnValue(mockError);

    component.control = new FormControl('', { validators: Validators.email });
    component.control.setErrors({ email: true });
    component.label = 'Email';
    component.submitted = true;

    fixture.detectChanges();

    expect(FormValidations.getErrorMsg).toHaveBeenCalledWith('Email', 'email', true);
    expect(component.errorMessage).toBe(mockError);
  });

  it('should return null if control has errors but is not dirty or submitted', () => {
    component.control = new FormControl('', { validators: Validators.required });
    component.control.setErrors({ required: true });
    component.label = 'Test Field';
    component.submitted = false;

    fixture.detectChanges();

    expect(component.errorMessage).toBeNull();
  });
});
