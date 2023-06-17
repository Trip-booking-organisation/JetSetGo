import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GenerateApiKeyComponent } from './generet-api-key/generate-api-key.component';
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatInputModule} from "@angular/material/input";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {MatDatepickerModule} from "@angular/material/datepicker";
import { CopyApiKeyComponent } from './copi-api-key/copy-api-key.component';
import {MatSelectModule} from "@angular/material/select";



@NgModule({
  declarations: [
    GenerateApiKeyComponent,
    CopyApiKeyComponent
  ],
  imports: [
    CommonModule,
    MatInputModule,
    ReactiveFormsModule,
    MatSelectModule,
  ]
})
export class ApiKeyModule { }
