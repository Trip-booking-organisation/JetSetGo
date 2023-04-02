import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {NavbarComponent} from './navbar/navbar.component';
import {MatIconModule} from "@angular/material/icon";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {MatInputModule} from "@angular/material/input";
import {MatButtonModule} from "@angular/material/button";
import {ErrorComponent} from "./errors/errorPage/error.component";
import {MatTooltipModule} from "@angular/material/tooltip";
import {RoundedRectangleComponent} from './rounded-rectangle/rounded-rectangle.component';
import {LoadingAnimationComponent} from './loading-animation/loading-animation.component';
import {AutoCompleteComponent} from './auto-complete/auto-complete.component';
import {MatAutocompleteModule} from "@angular/material/autocomplete";
import {RouterLink, RouterLinkActive} from "@angular/router";
import {ModalDialogComponent} from './modal-dialog/modal-dialog.component';
import {MatDialogModule} from "@angular/material/dialog";


@NgModule({
  declarations: [
    NavbarComponent,
    ErrorComponent,
    LoadingAnimationComponent,
    AutoCompleteComponent,
    ErrorComponent,
    RoundedRectangleComponent,
    ModalDialogComponent
  ],
  exports: [
    NavbarComponent,
    RoundedRectangleComponent,
    LoadingAnimationComponent,
    AutoCompleteComponent
  ],
  imports: [
    CommonModule,
    MatIconModule,
    FormsModule,
    MatInputModule,
    MatButtonModule,
    MatTooltipModule,
    ReactiveFormsModule,
    MatAutocompleteModule,
    RouterLinkActive,
    RouterLink,
    MatDialogModule,
  ]
})
export class ComponentsModule {
}
