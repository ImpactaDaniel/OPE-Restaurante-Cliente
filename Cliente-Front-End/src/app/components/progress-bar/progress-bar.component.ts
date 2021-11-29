import { Component, Input, OnInit } from '@angular/core';
import { ThemePalette } from '@angular/material/core';

@Component({
  selector: 'app-progress-bar',
  templateUrl: './progress-bar.component.html',
  styleUrls: ['./progress-bar.component.css']
})
export class ProgressBarComponent implements OnInit {

  // @Input() color: ThemePalette = 'primary'
  // @Input() value: number = 50
  constructor() { }

  ngOnInit(): void {
  }


}
