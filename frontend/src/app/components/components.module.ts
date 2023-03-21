import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {NavbarComponent} from './navbar/navbar.component';
import {MatIconModule} from "@angular/material/icon";
import {SearchComponent} from './search/search.component';
import {FormsModule} from "@angular/forms";
import {MatInputModule} from "@angular/material/input";
import {MatButtonModule} from "@angular/material/button";


@NgModule({
  declarations: [
    NavbarComponent,
    SearchComponent
  ],
  exports: [
    NavbarComponent,
    SearchComponent
  ],
  imports: [
    CommonModule,
    MatIconModule,
    FormsModule,
    MatInputModule,
    MatButtonModule,
  ]
})
export class ComponentsModule {
}
