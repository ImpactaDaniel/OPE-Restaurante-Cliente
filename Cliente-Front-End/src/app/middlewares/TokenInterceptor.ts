import { AlertService } from 'src/app/services/alert.service';
import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";
import { catchError, concatAll, map } from "rxjs/operators";
import { TokenService } from "../services/token.service";

@Injectable()
export class RequestInterceptor implements HttpInterceptor {

  constructor(private tokenService: TokenService, private alertService: AlertService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    let newReq = req;
    if (this.tokenService.isAuthenticated() && !req.url.includes('viacep.com.br/ws/')) {
      let tokenResponse = this.tokenService.getToken();
      newReq = this.addToken(req, tokenResponse.token);
    }

    return next.handle(newReq)
      .pipe(catchError(error => {
        if (error instanceof HttpErrorResponse && (error.status === 401)) {
          this.refreshToken(newReq, next).then(res => {
            return res;
          });
        }
        return throwError(error);
      }));
  }

  private async refreshToken(req: HttpRequest<any>, next: HttpHandler): Promise<any> {
    return new Promise(async (s, _) => {
      console.log('refresh')
      // let refreshed = await this.tokenService.renewToken();
      // if (refreshed) {
      //   let tokenResponse = this.tokenService.getToken();
      //   req = this.addToken(req, tokenResponse.token);
      //   s(next.handle(req));
      // }
      let tokenResponse = this.tokenService.getToken();
        req = this.addToken(req, tokenResponse.token);
        s(next.handle(req));
    });
  }

  private addToken(request: HttpRequest<any>, token: string): HttpRequest<any> {
    return request.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`
      }
    });
  }
}
