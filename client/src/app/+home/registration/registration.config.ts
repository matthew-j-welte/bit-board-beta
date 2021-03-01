import { FormConfig } from 'src/app/shared/helpers/form-helpers';

export const registrationFormConfig: FormConfig = {
  formName: 'registration-form',
  groups: [
    {
      header: 'Personal',
      icon: 'fa-user',
      rows: [
        {
          fields: [
            {
              name: 'username',
              type: 'text',
              startingValue: '',
              required: true,
              label: 'Username',
              placeholder: 'da-below-average-coder-2020',
              min: 3,
              max: 36,
            },
            {
              name: 'password',
              type: 'password',
              startingValue: '',
              required: true,
              label: 'Password',
              placeholder: 'Strong Password!',
              min: 8,
              max: 256,
            },
          ],
        },
        {
          fields: [
            {
              name: 'firstName',
              type: 'text',
              startingValue: '',
              required: true,
              label: 'First Name',
              placeholder: 'Petey',
              max: 36,
            },
            {
              name: 'lastName',
              type: 'text',
              startingValue: '',
              required: true,
              label: 'Last Name',
              placeholder: 'Jimbob',
              max: 36,
            },
          ],
        },
        {
          fields: [
            {
              name: 'imageUrl',
              type: 'text',
              startingValue: '',
              required: false,
              label: 'User Profile Image',
              placeholder: 'https://imageland-crazy-images-woohoo.com/1',
              max: 1000,
            },
          ],
        },
      ],
    },
    {
      header: 'Technical',
      icon: 'fa-code',
      rows: [
        {
          fields: [
            {
              name: 'yearsExperience',
              type: 'text',
              startingValue: '',
              required: true,
              label: 'Total Years Experience',
              placeholder: '12',
              max: 2,
            },
            {
              name: 'title',
              type: 'text',
              startingValue: '',
              required: false,
              label: 'Professional Title',
              placeholder: 'Senior Software Engineer',
              max: 100,
            },
          ],
        },
        {
          fields: [
            {
              name: 'technicalSummary',
              type: 'textarea',
              startingValue: '',
              required: false,
              label: 'Technical Summary',
              placeholder: 'Quick summary about your experience...',
              max: 5000,
              rows: 8,
            },
          ],
        },
      ],
    },
    {
      header: 'Career',
      icon: 'fa-briefcase',
      rows: [
        {
          fields: [
            {
              name: 'currentEmployer',
              type: 'text',
              startingValue: '',
              required: false,
              label: 'Current Employer',
              placeholder: 'Mars Imaginary and Made-Up SpaceLabs Inc',
              max: 100,
            },
            {
              name: 'yearsAtEmployer',
              type: 'text',
              startingValue: '',
              required: false,
              label: 'Years At Employer',
              placeholder: '5',
              max: 2,
            },
          ],
        },
        {
          fields: [
            {
              name: 'jobDescription',
              type: 'textarea',
              startingValue: '',
              required: false,
              label: 'Job Description',
              placeholder:
                'Quick summary about your responsibilities, tech stack etc...',
              max: 2500,
              rows: 6,
            },
          ],
        },
      ],
    },
  ],
};
