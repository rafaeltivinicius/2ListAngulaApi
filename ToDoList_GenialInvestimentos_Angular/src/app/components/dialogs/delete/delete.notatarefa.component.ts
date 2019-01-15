import { Component, Inject } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { NotaTarefa } from '../../../core/models/notatarefa';
import { NotaTarefaService } from '../../../core/services/notatarefa.service';

@Component({
  selector: 'app-delete.notatarefa',
  templateUrl: './delete.notatarefa.component.html',
  styleUrls: ['./delete.notatarefa.component.css']
})
export class DeleteNotaTarefaComponent {

  constructor(private NotaTarefaService: NotaTarefaService,
    public dialogRef: MatDialogRef<DeleteNotaTarefaComponent>,
    @Inject(MAT_DIALOG_DATA) public notaTarefa: NotaTarefa) {
  }

  onNoClick(): void {
    this.dialogRef.close(false);
  }

  delete() {
    this.NotaTarefaService.delete(this.notaTarefa.Id);
    this.dialogRef.close(true);
  }
}
