import { Component } from '@angular/core';
import { HubConnection, HubConnectionBuilder, LogLevel } from '@aspnet/signalr';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  messages: string[] = [];
  ngOnInit() {
     //this.hubConnection=new HubConnection("http://localhost:62659/TicketManagerHub",{logger:LogLevel.Trace});
     const connection = new HubConnectionBuilder()
     .withUrl("http://localhost:50313/TicketNotificationHub")
     .configureLogging(LogLevel.Information)
     .build();
 
      
     connection.start()
      .then(res => {
        console.log('connection started');
        this.http.get("http://localhost:50313/api/values/5").subscribe(res => {
      console.log(res);
    })
      })
        .catch(err => {
          console.error((err));
        })


        connection.on('ReceiveMessage', function (name) {
          this.messages.push(name);
      });
  }
  constructor(private http: HttpClient) {
    this.messages.push('First messagemsg');
   
  }
}
