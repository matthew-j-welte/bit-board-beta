import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  ValidatorFn,
} from '@angular/forms';
import { Router } from '@angular/router';
import { FormConfig, FormFieldBuilder } from 'src/app/+helpers/form-helpers';
import { AccountService } from 'src/app/+services/account.service';
import { registrationFormConfig } from './registration.config';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css'],
})
export class RegistrationComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  registerForm: FormGroup;
  validationErrors: string[] = [];
  formConfig: FormConfig;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private accountService: AccountService
  ) {}

  ngOnInit(): void {
    this.buildForm();
  }

  buildForm() {
    this.formConfig = registrationFormConfig;
    this.registerForm = this.fb.group(
      FormFieldBuilder.buildCtlConfig(this.formConfig)
    );
  }

  matchValues(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {
      return control?.value === control?.parent?.controls[matchTo].value
        ? null
        : { isMatching: true };
    };
  }

  register() {
    console.log(this.registerForm.value);
    // this.accountService.register(this.registerForm.value).subscribe(
    //   (_) => {
    //     this.router.navigateByUrl('/userDashboard');
    //   },
    //   (error) => {
    //     this.validationErrors = error;
    //   }
    // );
  }

  cancel() {
    this.cancelRegister.emit(false);
  }
}
