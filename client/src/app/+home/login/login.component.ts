import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  ValidatorFn,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { AccountService } from 'src/app/shared/services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  @ViewChild('failedModal', { read: TemplateRef })
  failedModalTemplate: TemplateRef<any>;

  loginForm: FormGroup;
  maxDate: Date;
  validationErrors: string[] = [];
  modalRef: BsModalRef;
  failedModalRef: BsModalRef;

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
    this.loginForm = this.fb.group({
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
    this.accountService.login(this.loginForm.value).subscribe(
      (_) => {
        this.router.navigate(['userDashboard']);
      },
      (error) => {
        this.validationErrors = error;
        // pass something to a class or component that displays the error modal
      }
    );
  }

  openModalWithClass(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(
      template,
      Object.assign({}, { class: 'gray modal-lg' })
    );
  }

  onModalSubmit = () => {
    this.modalRef.hide();
  };

  onModalFailure = (errors: string[]) => {
    this.failedModalRef = this.modalService.show(
      this.failedModalTemplate,
      Object.assign({}, { class: 'gray modal-md' })
    );
  };
}
