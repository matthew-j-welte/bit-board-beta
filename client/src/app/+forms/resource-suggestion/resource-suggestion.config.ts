import { FormConfig } from 'src/app/+helpers/form-helpers';

export const resourceSuggestionConfig: FormConfig = {
  formName: 'registration-form',
  groups: [
    {
      rows: [
        {
          fields: [
            {
              name: 'webURL',
              type: 'text',
              startingValue: '',
              required: true,
              label: 'Web URL',
              placeholder: 'https://youtube.com/#someVideo',
              min: 3,
              max: 36,
            },
          ],
        },
        {
          fields: [
            {
              name: 'rationale',
              type: 'textarea',
              startingValue: '',
              required: true,
              label: 'Rationale',
              placeholder:
                'Give a brief description of why this resource would be beneficial',
              min: 50,
              max: 1000,
              rows: 6,
            },
          ],
        },
        {
          fields: [
            {
              name: 'skillSelections',
              type: 'text',
              startingValue: [],
              required: true,
              label: 'Associated Skills',
              placeholder: 'Select skills below',
              readonly: true
            },
          ],
        },
      ],
    },
  ],
};
