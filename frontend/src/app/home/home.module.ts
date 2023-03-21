import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {HomeComponent} from "./ui/home/home.component";
import {ComponentsModule} from "../components/components.module";
import {SupportComponent} from './ui/support/support.component';
import {SupportCardComponent} from './ui/support-card/support-card.component';
import {InfoComponent} from './ui/info/info.component';
import {MatIconModule} from "@angular/material/icon";
import {LoungeComponent} from './ui/lounge/lounge.component';
import { TravelersComponent } from './ui/travelers/travelers.component';
import { SubscribeComponent } from './ui/subscribe/subscribe.component';
import { FooterComponent } from './ui/footer/footer.component';


@NgModule({
  declarations: [
    HomeComponent,
    SupportComponent,
    SupportCardComponent,
    InfoComponent,
    LoungeComponent,
    TravelersComponent,
    SubscribeComponent,
    FooterComponent
  ],
  imports: [
    CommonModule,
    ComponentsModule,
    MatIconModule,
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
