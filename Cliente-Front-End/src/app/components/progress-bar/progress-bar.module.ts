import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProgressBarComponent } from './progress-bar.component';
import { MatProgressBarModule } from '@angular/material/progress-bar';

@NgModule({
  imports: [
    CommonModule,
    MatProgressBarModule
  ],
  declarations: [ProgressBarComponent],
  exports: [ProgressBarComponent]
})
export class ProgressBarModule { }