import { Validators } from '@angular/forms';

export class FormFieldBuilder {
  public static buildCtlConfig(form: FormConfig) {
    const conf = {};

    form.groups.forEach((group) => {
      group.rows.forEach((row) => {
        row.fields.forEach((field) => {
          conf[field.name] = this.buildFieldCtlConfig(field);
        });
      });
    });

    return conf;
  }

  private static buildFieldCtlConfig(field: FormFieldConfig) {
    const fieldConfig = [field.startingValue];
    const validators = [];
    
    if (field.required) {
      validators.push(Validators.required);
    }
    if (field.min) {
      validators.push(Validators.minLength(field.min));
    }
    if (field.max) {
      validators.push(Validators.maxLength(field.max));
    }

    fieldConfig.push(validators);
    return fieldConfig;
  }
}

export interface FormFieldConfig {
  name: string;
  type: string;
  label?: string;
  placeholder?: string;
  startingValue: any;
  required: boolean;
  min?: number;
  max?: number;
  rows?: number;
  readonly?: boolean;
}

export interface FormRowConfig {
  fields: FormFieldConfig[];
}

export interface FormGroupConfig {
  rows: FormRowConfig[];
  header?: string;
  icon?: string;
}

export interface FormConfig {
  formName: string;
  groups: FormGroupConfig[];
}
