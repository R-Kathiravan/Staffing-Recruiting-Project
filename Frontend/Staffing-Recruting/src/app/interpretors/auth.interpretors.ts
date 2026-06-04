import { HttpInterceptorFn, HttpErrorResponse } from '@angular/common/http';
import { inject, PLATFORM_ID } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { Router } from '@angular/router';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const platformId = inject(PLATFORM_ID);
  const router = inject(Router);

  let finalRequest = req;

  if (isPlatformBrowser(platformId)) {
    const token = localStorage.getItem('user-token');

    if (token) {
      finalRequest = req.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`
        }
      });
    }
  }

  return next(finalRequest).pipe(
    catchError((error: HttpErrorResponse) => {

      if (error.status === 401 || error.status == 500) {
        console.warn("Unauthorized! Redirecting to login...");

        if (isPlatformBrowser(platformId)) {
          localStorage.removeItem('user-token');
        }

        router.navigate(['/login']);
      }

      return throwError(() => error);
    })
  );
};