import { Inject, Injectable } from '@angular/core';
import { TokenService } from '../token.service';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { EventEmitter } from 'events';

@Injectable({
  providedIn: 'root'
})
export class InvoiceHubServiceService {

  private hubConnection: HubConnection;
  public emmiter = new EventEmitter();

  constructor(private tokenService: TokenService, @Inject("BASE_URL") private url: string) { }

  private buildConnection() {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(`${this.url}invoice-hub`)
      .build();
  }

  public init() {
    this.buildConnection();
    this.startConnection();
    this.registerOnServerEvents();
  }

  public stopConnection() {
    console.log("Stopped the connection")
    this.hubConnection?.stop().catch(err => {
      console.error(err);
    });
  }

  private startConnection() {
    console.log("Trying to connect");
    this.hubConnection
      .start()
      .then(() => {
        this.hubConnection.invoke('connect', this.tokenService.getTokenData().id).then(() => {
          console.log('Hub connected!');
        });
      })
      .catch(error => {
        console.error(error);
        setTimeout(() => {
          this.startConnection();
        }, 5000);
      });
  }

  private registerOnServerEvents() {
    console.log("registered");
    this.hubConnection.on('InvoiceUpdated', (invoice, status) => {
      console.log(invoice, status);//this.emmiter.emit('invoiceUpdated', invoice, type);
    });
  }

}
