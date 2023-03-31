import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {SearchComponent} from "./search.component";
import {MatIconModule} from "@angular/material/icon";
import {MatInputModule} from "@angular/material/input";
import {ReactiveFormsModule} from "@angular/forms";
import {ComponentsModule} from "../components/components.module";


@NgModule({
  declarations: [
    SearchComponent
  ],
  exports: [
    SearchComponent
  ],
  imports: [
    CommonModule,
    MatIconModule,
    MatInputModule,
    ReactiveFormsModule,
    ComponentsModule,
  ]
})
export class SearchModule {
}
