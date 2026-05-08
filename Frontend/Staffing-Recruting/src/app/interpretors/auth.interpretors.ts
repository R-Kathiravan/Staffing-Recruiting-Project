import { HttpInterceptorFn } from '@angular/common/http';
// 1. Import these two new tools
import { inject, PLATFORM_ID } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  // 2. Inject the Platform ID so we know where the code is running
  const platformId = inject(PLATFORM_ID);

  // 3. Wrap your localStorage logic inside this safety check!
  if (isPlatformBrowser(platformId)) {
    const token = localStorage.getItem('user-token'); // Or whatever you named it!

    if (token) {
      const clonedRequest = req.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`
        }
      });
      return next(clonedRequest); 
    }
  }

  // 4. If we are on the server, or if there is no token, just pass it through normally
  return next(req);
};