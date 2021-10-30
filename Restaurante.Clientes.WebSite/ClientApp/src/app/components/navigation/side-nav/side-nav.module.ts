import { SideNavComponent } from './side-nav.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';


@NgModule({
  declarations: [
    SideNavComponent
  ],
  imports: [
    CommonModule,
    MatIconModule,
    MatListModule
  ],
  exports: [
    SideNavComponent
  ]
})
export class SideNavModule { }
