import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RepositoryService } from '../Shared/Services/repository.service';

@Component({
  selector: 'app-tasks-todo',
  templateUrl: './tasks-todo.component.html',
  styleUrls: ['./tasks-todo.component.css']
})
export class TasksTodoComponent implements OnInit {
  public tasks: TaskTodo[];

  constructor(private repo: RepositoryService) {
    this.repo.getData('api/v1/' + 'TaskTodo')
      .subscribe(res => {
        this.tasks = res as TaskTodo[];
      },
        (error) => {
          console.error(error);
        });
  }

  ngOnInit(): void {
  }

}
interface TaskTodo {
  name: string;
  description: string;
  completed: boolean;
}
