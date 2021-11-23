import { ErrorHandler, Injectable } from "@angular/core";
import { AlertService } from "../services/alert.service";

@Injectable({ providedIn: 'root' })
export class GlobalErrorHandler implements ErrorHandler {

  constructor(private alertService: AlertService) { }

  handleError(error: any): void {
    console.log('GlobalToken error')
    console.error(error);
    try {
      if (error.status !== 400 && error.status !== 401) {
        this.alertService.showError();
        return;
      }
      console.error(error);
    } catch (err) {
      console.log('GlobalToken error')
      console.error(err);
    }
  }
}
