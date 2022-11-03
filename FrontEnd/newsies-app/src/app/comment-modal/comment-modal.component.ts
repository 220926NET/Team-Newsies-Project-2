import { Component, OnInit, Input } from '@angular/core';
import { Output, EventEmitter } from '@angular/core';
import Comment from 'src/models/Comment';
@Component({
  selector: 'app-comment-modal',
  templateUrl: './comment-modal.component.html',
  styleUrls: ['./comment-modal.component.css']
})


export class CommentModalComponent implements OnInit {

  @Output() exitModal = new EventEmitter<boolean>(); 
  
  @Input() comment : Comment = {
    name: "",
    content: "",
    sentiment: 0
  }; 

 
  constructor() { }

  ngOnInit(): void {
  }

  closeModal(){
    this.exitModal.emit(true); 
  }


  
}
