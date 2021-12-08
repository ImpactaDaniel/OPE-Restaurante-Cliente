import { Injectable } from '@angular/core';
import Swal from 'sweetalert2';

@Injectable({
  providedIn: 'root'
})
export class AlertService {

  constructor() { }


  public showError(title?: string, message?: string, callBack?: () => any): void {
    Swal.fire({
      position: 'center',
      icon: 'error',
      title: title || 'Ops.. Algo deu errado!',
      text: message || 'Tente novamente mais tarde',
      timer: 5000,
      showConfirmButton: true,
      didClose: callBack
    });
  }

  public showSuccess(title?: string, message?: string, callBack?: () => any): void {
    Swal.fire({
      position: 'center',
      icon: 'success',
      title: title || 'Sucesso!',
      text: message || 'Sucesso!',
      showConfirmButton: true,
      didClose: callBack
    });
  }

  public showQuestion(title?: string, message?: string, callBack?: () => any): void{
    Swal.fire({
      position: 'center',
      icon: 'question',
      title: title || 'Confirmar?',
      text: message || 'Confirma?',
      showConfirmButton: true,
      showCancelButton: true
    }).then(res => {
      if(res.isConfirmed)
        callBack();
    });
  }
}
