import { MenuModule } from 'primeng/menu';
import { MainRoutingModule } from './main-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { MainComponent } from './main.component';

@NgModule({
    declarations: [
        MainComponent
    ],
    imports: [
        ReactiveFormsModule,
        MainRoutingModule,
        MenuModule
    ],
    exports: [MainComponent],
    providers: []
})
export class MainModule {}