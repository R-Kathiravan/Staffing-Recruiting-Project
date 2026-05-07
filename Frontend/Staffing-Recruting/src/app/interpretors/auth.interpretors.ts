import { HttpInterceptorFn } from '@angular/common/http';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  // 1. Grab the token we just saved in Step 1
  const token = localStorage.getItem('user-token');

  // 2. If a token exists, clone the request and attach it!
  if (token) {
    const clonedRequest = req.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`
      }
    });
    // Send the modified request to the backend
    return next(clonedRequest); 
  }

  // 3. If no token (like when they are first logging in), just let the request pass normally
  return next(req);
};