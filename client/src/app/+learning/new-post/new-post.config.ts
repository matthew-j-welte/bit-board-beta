import { FormConfig } from 'src/app/shared/helpers/form-helpers';

export const newPostForm: FormConfig = {
  formName: 'registration-form',
  groups: [
    {
      header: 'New Post',
      icon: 'fa-paper-plane',
      rows: [
        {
          fields: [
            {
              name: 'content',
              type: 'textarea',
              startingValue: '',
              required: true,
              label: 'Content',
              rows: 12,
              showLabel: false,
              max: 10000,
            },
          ],
        },
      ],
    },
  ],
};
