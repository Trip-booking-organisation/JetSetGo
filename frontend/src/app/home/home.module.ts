import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {HomeComponent} from "./ui/home/home.component";


@NgModule({
  declarations: [HomeComponent],
  imports: [
    CommonModule,
  ],
  bootstrap: [
    HomeComponent
  ],
  exports: [
    HomeComponent
  ]
})
export class HomeModule {
}
