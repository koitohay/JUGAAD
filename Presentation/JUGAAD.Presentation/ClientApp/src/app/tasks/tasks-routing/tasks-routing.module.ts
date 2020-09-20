import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { TasksTodoComponent } from '../../tasks-todo/tasks-todo.component';

const routes: Routes = [
  { path: 'tasks-todo', component: TasksTodoComponent }
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ],
  declarations: []
})
export class TasksRoutingModule { }
