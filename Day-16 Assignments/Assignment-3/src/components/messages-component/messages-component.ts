import { Component } from '@angular/core';
import { MessageService } from '../../app/services/message-service';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-messages-component',
  imports: [FormsModule],
  templateUrl: './messages-component.html',
  styleUrl: './messages-component.css',
})
export class MessagesComponent {
   message = '';
  messages: string[] = [];

  constructor(private messageService: MessageService) {}

  addMessage() {
    this.messageService.addData(this.message);
    this.messages = this.messageService.getData();
    this.message = '';
  }
}
