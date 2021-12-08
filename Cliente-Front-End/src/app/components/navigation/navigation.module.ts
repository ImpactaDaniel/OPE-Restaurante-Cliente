import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from 'src/app/material.module';
import { SideNavComponent } from './side-nav/side-nav.component';



@NgModule({
  imports: [
    CommonModule,
    BrowserAnimationsModule,
    MaterialModule
  ],
  exports: [
    BrowserAnimationsModule,
    MaterialModule
  ]
})
export class NavigationModule { }
