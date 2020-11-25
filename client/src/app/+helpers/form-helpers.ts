import { Validators } from '@angular/forms';

export class FormFieldBuilder {
  static buildCtlConfig(field: FormFieldHelper) {
    const conf = [field.startingValue]
    const validators = []
    if (field.required) { validators.push(Validators.required); }
    if (field.min) { validators.push(Validators.minLength(field.min)) }
    if (field.max) { validators.push(Validators.maxLength(field.max)) }

    conf.push(validators);
    return conf;
  }
}

export interface FormFieldHelper {
  name: string;
  type: string;
  label?: string;
  placeholder?: string;
  startingValue: any;
  required: boolean;
  min?: number;
  max?: number;
  rows?: number;
}

export interface FormRowHelper {
  fields: FormFieldHelper[];
}

export interface FormGroupHelper {
  rows: FormRowHelper[]
  header: string
  icon: string
}