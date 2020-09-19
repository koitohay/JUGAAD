import { Component, OnInit, Inject } from '@angular/core';
import { RepositoryService } from '../Shared/Services/repository.service';
import { ErrorHandlerService } from '../Shared/Services/error-handler.service';

@Component({
  selector: 'app-tasks-todo',
  templateUrl: './tasks-todo.component.html',
  styleUrls: ['./tasks-todo.component.css']
})
export class TasksTodoComponent implements OnInit {
  public tasks: TaskTodo[];
  public errorMessage: string = '';

  constructor(private repo: RepositoryService, private errorHandler: ErrorHandlerService) {
    this.repo.getData('api/v1/' + 'TaskTodo')
      .subscribe(res => {
        this.tasks = res as TaskTodo[];
        $('#successModal').modal();
      },
        (error) => {
          this.errorHandler.handleError(error);
          this.errorMessage = this.errorHandler.errorMessage;
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
