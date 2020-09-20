import { Component, OnInit, Inject, ViewChild, AfterViewInit } from '@angular/core';
import { RepositoryService } from '../Shared/Services/repository.service';
import { ErrorHandlerService } from '../Shared/Services/error-handler.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-tasks-todo',
  templateUrl: './tasks-todo.component.html',
  styleUrls: ['./tasks-todo.component.css']
})
export class TasksTodoComponent implements OnInit, AfterViewInit  {
  public tasks: TaskTodo[];
  public errorMessage: string = '';

  public displayedColumns = ['name', 'description', 'completed', 'details', 'update', 'delete'];
  public dataSource = new MatTableDataSource<TaskTodo>();

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(private repo: RepositoryService, private errorHandler: ErrorHandlerService) {
    
  }

  ngOnInit(): void {
    this.getAllOwners();
  }
  public getAllOwners = () => {
    this.repo.getData('api/v1/' + 'TaskTodo')
      .subscribe(res => {
        this.dataSource.data = res as TaskTodo[];
      },
        (error) => {
          this.errorHandler.handleError(error);
          this.errorMessage = this.errorHandler.errorMessage;
        });
  }

  public doFilter = (value: string) => {
    this.dataSource.filter = value.trim().toLocaleLowerCase();
  }

  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }
}
interface TaskTodo {
  name: string;
  description: string;
  completed: boolean;
}
