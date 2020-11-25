import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  ValidatorFn,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { title } from 'process';
import { first, last } from 'rxjs/operators';
import {
  FormFieldBuilder,
  FormFieldHelper,
  FormGroupHelper,
} from 'src/app/+helpers/form-helpers';
import { AccountService } from 'src/app/+services/account.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css'],
})
export class RegistrationComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  registerForm: FormGroup;
  validationErrors: string[] = [];
  formGroupings: FormGroupHelper[];

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private accountService: AccountService
  ) {}

  ngOnInit(): void {
    this.buildFormComponents();
    this.intitializeForm();
  }

  buildFormComponents() {
    const username: FormFieldHelper = {
      name: 'username',
      type: 'text',
      startingValue: '',
      required: true,
      label: 'Username',
      placeholder: 'da-below-average-coder-2020',
      min: 3,
      max: 36,
    };

    const password: FormFieldHelper = {
      name: 'password',
      type: 'password',
      startingValue: '',
      required: true,
      label: 'Password',
      placeholder: 'Strong Password!',
      min: 8,
      max: 36,
    };

    const firstName: FormFieldHelper = {
      name: 'firstName',
      type: 'text',
      startingValue: '',
      required: true,
      label: 'First Name',
      placeholder: 'Petey',
      max: 36,
    };

    const lastName: FormFieldHelper = {
      name: 'lastName',
      type: 'text',
      startingValue: '',
      required: true,
      label: 'Last Name',
      placeholder: 'Jimbob',
      max: 36,
    };

    const profileImageUrl: FormFieldHelper = {
      name: 'profileImageUrl',
      type: 'text',
      startingValue: '',
      required: false,
      label: 'User Profile Image',
      placeholder: 'https://imageland-crazy-images-woohoo.com/1',
      max: 1000,
    };

    const yearsExperience: FormFieldHelper = {
      name: 'yearsExperience',
      type: 'text',
      startingValue: '',
      required: true,
      label: 'Total Years Experience',
      placeholder: '12',
      max: 2,
    };

    const professionalTitle: FormFieldHelper = {
      name: 'professionalTitle',
      type: 'text',
      startingValue: '',
      required: false,
      label: 'Professional Title',
      placeholder: 'Senior Software Engineer',
      max: 100,
    };

    const technicalSummary: FormFieldHelper = {
      name: 'technicalSummary',
      type: 'textarea',
      startingValue: '',
      required: false,
      label: 'Technical Summary',
      placeholder: 'Quick summary about your experience...',
      max: 5000,
      rows: 8,
    };

    const currentEmployer: FormFieldHelper = {
      name: 'currentEmployer',
      type: 'text',
      startingValue: '',
      required: false,
      label: 'Current Employer',
      placeholder: 'Mars Imaginary and Made-Up SpaceLabs Inc',
      max: 100,
    };

    const yearsAtEmployer: FormFieldHelper = {
      name: 'yearsAtEmployer',
      type: 'text',
      startingValue: '',
      required: false,
      label: 'Years At Employer',
      placeholder: '5',
      max: 2,
    };

    const jobDescription: FormFieldHelper = {
      name: 'jobDescription',
      type: 'textarea',
      startingValue: '',
      required: false,
      label: 'Job Description',
      placeholder:
        'Quick summary about your responsibilities, tech stack etc...',
      max: 2500,
      rows: 6
    };

    const userGroup: FormGroupHelper = {
      header: 'Personal',
      icon: 'fa-user',
      rows: [
        { fields: [username, password] },
        { fields: [firstName, lastName] },
        { fields: [profileImageUrl] },
      ],
    };

    const technicalGroup: FormGroupHelper = {
      header: 'Technical',
      icon: 'fa-code',
      rows: [
        { fields: [yearsExperience, professionalTitle] },
        { fields: [technicalSummary] },
      ],
    };

    const careerGroup: FormGroupHelper = {
      header: 'Technical',
      icon: 'fa-briefcase',
      rows: [
        { fields: [currentEmployer, yearsAtEmployer] },
        { fields: [jobDescription] },
      ],
    };
    
    this.formGroupings = [userGroup, technicalGroup, careerGroup];

    // TODO: Make this so that we dont have to duplicate the keys to be match
    //       up with the name property in each of the fields passed in
    //       also possible I can do away with all the variables above and just
    //       store it in a large config and then write a function that parse
    //       this config and then generates a fb.group
    this.registerForm = this.fb.group({
      username: FormFieldBuilder.buildCtlConfig(username),
      password: FormFieldBuilder.buildCtlConfig(password),
      firstName: FormFieldBuilder.buildCtlConfig(firstName),
      lastName: FormFieldBuilder.buildCtlConfig(lastName),
      yearsExperience: FormFieldBuilder.buildCtlConfig(yearsExperience),
      technicalSummary: FormFieldBuilder.buildCtlConfig(technicalSummary),
      professionalTitle: FormFieldBuilder.buildCtlConfig(professionalTitle),
      profileImageUrl: FormFieldBuilder.buildCtlConfig(profileImageUrl),
      currentEmployer: FormFieldBuilder.buildCtlConfig(currentEmployer),
      yearsAtEmployer: FormFieldBuilder.buildCtlConfig(yearsAtEmployer),
      jobDescription: FormFieldBuilder.buildCtlConfig(jobDescription),
    });
  }

  intitializeForm() {
    
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
