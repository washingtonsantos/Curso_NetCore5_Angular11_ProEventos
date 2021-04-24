import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  eventos: any = [];
  eventosFiltrados: any = [];

  larguraImagem: number = 50;
  marginImagem: number = 2;
  imagemVisivel: boolean = true;

  private _filtroLista: string = '';

  get filtroLista(): string {
    return this._filtroLista;
  }

  set filtroLista(value: string) {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarLista(this.filtroLista) : this.eventos;
  }

  filtrarLista(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      ( evento:
        { tema: string;local: string; }) =>
        evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
        evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
      )
  }

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEventos();
  }

  getEventos(): void {
    this.http.get('https://localhost:5001/api/evento').subscribe(
      resp => {
        this.eventos = resp;
        this.eventosFiltrados = this.eventos;
      },
      error => console.log(error)
    );
  }

  alterarImagem() {
    this.imagemVisivel = !this.imagemVisivel;
  }

}
