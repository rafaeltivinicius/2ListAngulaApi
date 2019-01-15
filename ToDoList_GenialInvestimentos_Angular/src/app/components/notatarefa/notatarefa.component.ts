import { Component, OnInit } from '@angular/core';
import { NotaTarefaService } from '../../core/services/notatarefa.service';
import { ItemService } from '../../core/services/item.service';
import { NotaTarefa } from '../../core/models/notatarefa';
import { Item } from '../../core/models/item';
import { UpdateNotaTarefaComponent } from '../dialogs/update/update.notatarefa.component'
import { DeleteNotaTarefaComponent } from '../dialogs/delete/delete.notatarefa.component'

import { MatDialog } from '@angular/material';

@Component({
  selector: 'app-notaTarefa',
  templateUrl: './notaTarefa.component.html',
  styleUrls: ['./notaTarefa.component.css']
})
export class NotaTarefaComponent implements OnInit {

  notaTarefas: NotaTarefa[];
  items: Item[] = new Array();
  discription: string = '';
  selectedAnyList: boolean = false;
  notaTarefa: NotaTarefa;

  constructor(private notaTarefaService: NotaTarefaService,
    public dialog: MatDialog,
    private itemService: ItemService) { }

  ngOnInit() {
    this.notaTarefaService
      .getall()
      .subscribe(notaTarefas => this.notaTarefas = notaTarefas);
  }

  createNotaTarefa() {
    this.notaTarefaService.create({ Title: this.discription } as NotaTarefa)
      .subscribe(notaTarefa => {
        this.notaTarefas.push(notaTarefa);
        this.showItems(notaTarefa);
      });;
      this.discription = '';
   }

  showItems(notaTarefa: NotaTarefa) {
    this.itemService.getallByNotaTarefaId(notaTarefa.Id)
      .subscribe(items => this.items = items);

    this.notaTarefa = notaTarefa;
    this.selectedAnyList = true;
  }

  deletenotaTarefa(notaTarefa: NotaTarefa, i: number) {
    this.notaTarefaService.delete(notaTarefa.Id);
    this.notaTarefas.splice(i, 1);
    this.items = [];
  }

  showUpdateDialog(notaTarefa: NotaTarefa, i: number): void {
    let dialogRef = this.dialog.open(UpdateNotaTarefaComponent, {
      width: '40%',
      data: notaTarefa
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result != undefined)
        this.notaTarefas[i] = result;
    });
  }

  showDeleteDialog(notaTarefa: NotaTarefa, i: number): void {
    let dialogRef = this.dialog.open(DeleteNotaTarefaComponent, {
      width: '30%',
      data: notaTarefa
    });

    dialogRef.afterClosed().subscribe(isDeleted =>
      this.spliceIfIsDelete(i, isDeleted)
    );
  }

  spliceIfIsDelete(i: number, isDeleted: boolean) {
    if (isDeleted) {
      this.notaTarefas.splice(i, 1);
      this.items = [];
    }
  }
}
