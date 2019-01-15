import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NotaTarefaService } from './core/services/notatarefa.service';
import { ItemService } from './core/services/item.service';

import { AppComponent } from './app.component';
import { NotaTarefaComponent } from './components/notatarefa/notatarefa.component';
import { ItemComponent } from './components/item/item.component';
import { MaterialModule } from "./shared/material.module";
import { UpdateNotaTarefaComponent } from './components/dialogs/update/update.notatarefa.component';
import { DeleteNotaTarefaComponent } from './components/dialogs/delete/delete.notatarefa.component'

import { MatDialogModule, MatDialog } from '@angular/material';


@NgModule({
  declarations: [
    AppComponent,
    NotaTarefaComponent,
    ItemComponent,
    UpdateNotaTarefaComponent,
    DeleteNotaTarefaComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MaterialModule,
    MatDialogModule
  ],
  providers: [
    ItemService,
    NotaTarefaService,
    MatDialog
  ],
  entryComponents: [
    UpdateNotaTarefaComponent,
    DeleteNotaTarefaComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
