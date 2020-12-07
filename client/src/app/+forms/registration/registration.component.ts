import { Component, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  ValidatorFn,
} from '@angular/forms';
import { Router } from '@angular/router';
import { FormConfig, FormFieldBuilder } from 'src/app/+helpers/form-helpers';
import { Register } from 'src/app/+models/dtos/register_dto';
import { AccountService } from 'src/app/+services/account.service';
import { registrationFormConfig } from './registration.config';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css'],
})
export class RegistrationComponent implements OnInit {
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

  buildForm(): void {
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

  register(): void {
    const registration: Register = this.registerForm.value;
    registration.yearsExperience = +registration.yearsExperience;
    registration.yearsAtEmployer = +registration.yearsAtEmployer;

    this.accountService.register(registration).subscribe(
      (_) => {
        this.router.navigate(['userDashboard']);
      },
      (error) => {
        this.validationErrors = error;
      }
    );
  }
}
