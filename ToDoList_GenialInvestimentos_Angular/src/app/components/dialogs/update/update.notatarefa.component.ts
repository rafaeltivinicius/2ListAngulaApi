import { Component, Inject } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { NotaTarefa } from '../../../core/models/notatarefa';
import { NotaTarefaService } from '../../../core/services/notatarefa.service';

@Component({
  selector: 'app-update',
  templateUrl: './update.notatarefa.component.html',
  styleUrls: ['./update.notatarefa.component.css']
})
export class UpdateNotaTarefaComponent  {
  public notaTarefaNotBind: NotaTarefa;

  constructor(private notaTarefaService: NotaTarefaService,
    public dialogRef: MatDialogRef<UpdateNotaTarefaComponent>,
    @Inject(MAT_DIALOG_DATA) public notaTarefa: NotaTarefa) {
    this.notaTarefaNotBind = Object.assign({}, notaTarefa)
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  salvar() {
    this.notaTarefaService.update(this.notaTarefaNotBind);
    this.dialogRef.close(this.notaTarefaNotBind);
  }
}
