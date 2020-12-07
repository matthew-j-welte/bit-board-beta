import { HttpHeaders } from '@angular/common/http';

export const getNgxSpinnerHeader = () =>
  new HttpHeaders({ 'ngx-spinner': 'true' });
