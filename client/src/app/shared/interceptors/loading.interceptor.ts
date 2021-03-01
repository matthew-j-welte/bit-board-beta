import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { BusyService } from '../services/busy.service';
import { finalize } from 'rxjs/operators';

@Injectable()
export class LoadingInterceptor implements HttpInterceptor {
  constructor(private busyService: BusyService) {}

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    const markBusy = request.headers.get('ngx-spinner') === 'true';
    if (markBusy) {
      // No need to send this to our server
      request.headers.delete('ngx-spinner');
      this.busyService.busy();
    }

    return next.handle(request).pipe(
      finalize(() => {
        if (markBusy) {
          this.busyService.idle();
        }
      })
    );
  }
}
