import { Component, OnInit, TemplateRef } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  ValidatorFn,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { AccountService } from 'src/app/+services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  registerForm: FormGroup;
  maxDate: Date;
  validationErrors: string[] = [];
  modalRef: BsModalRef;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private accountService: AccountService,
    private modalService: BsModalService
  ) {}

  ngOnInit(): void {
    this.intitializeForm();
  }

  intitializeForm(): void {
    this.registerForm = this.fb.group({
      username: ['', Validators.required],
      password: [
        '',
        [Validators.required, Validators.minLength(4), Validators.maxLength(8)],
      ],
    });
  }

  matchValues(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {
      return control?.value === control?.parent?.controls[matchTo].value
        ? null
        : { isMatching: true };
    };
  }

  login(): void {
    this.accountService.login(this.registerForm.value).subscribe(
      (_) => {
        this.router.navigate(['userDashboard']);
      },
      (error) => {
        this.validationErrors = error;
      }
    );
  }

  openModalWithClass(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(
      template,
      Object.assign({}, { class: 'gray modal-lg' })
    );
  }
}
