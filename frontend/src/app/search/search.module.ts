import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {SearchComponent} from "./search.component";
import {MatIconModule} from "@angular/material/icon";
import {MatInputModule} from "@angular/material/input";
import {ReactiveFormsModule} from "@angular/forms";
import {ComponentsModule} from "../components/components.module";
import {MatAutocompleteModule} from "@angular/material/autocomplete";
import {MatDatepickerModule} from "@angular/material/datepicker";
import {MatNativeDateModule} from "@angular/material/core";
import {SearchCardComponent} from './ui/search-card/search-card.component';
import {MatDividerModule} from "@angular/material/divider";

@NgModule({
  declarations: [
    SearchComponent,
    SearchCardComponent
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
    MatAutocompleteModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatDividerModule
  ]
})
export class SearchModule {
}
