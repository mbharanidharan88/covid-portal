import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-button',
  templateUrl: './app-button.component.html',
  styleUrls: ['./app-button.component.css']
})
export class AppButtonComponent implements OnInit {

  @Input() type: string = 'button';
  @Input() block: boolean = false;
  @Input() color: string = 'primary';
  @Input() text: string = '';
  @Input() disabled: boolean = false;
  @Input() loading: boolean = false;

  constructor() { }

  ngOnInit(): void {

  }

}
