import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {
  public calificaciones : string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<string>(baseUrl + 'api/SampleData/CalificacioGeneral').subscribe(result => {
      this.calificaciones = "resultado";
    }, error => console.error(error));
  }
}
