import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {NavbarComponent} from './navbar/navbar.component';
import {MatIconModule} from "@angular/material/icon";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {MatInputModule} from "@angular/material/input";
import {MatButtonModule} from "@angular/material/button";
import {ErrorComponent} from "./errors/errorPage/error.component";
import {MatTooltipModule} from "@angular/material/tooltip";
import { RoundedRectangleComponent } from './rounded-rectangle/rounded-rectangle.component';


@NgModule({
  declarations: [
    NavbarComponent,
    ErrorComponent,
    RoundedRectangleComponent
  ],
    exports: [
        NavbarComponent,
        RoundedRectangleComponent
    ],
  imports: [
    CommonModule,
    MatIconModule,
    FormsModule,
    MatInputModule,
    MatButtonModule,
    MatTooltipModule,
    ReactiveFormsModule,
  ]
})
export class ComponentsModule {
}
