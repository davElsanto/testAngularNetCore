import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Usuario } from '../models/usuario';
import { catchError, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BackserviceService {

  private apiUrl = 'https://localhost:7118/api/Usuario';
  usuario: Usuario;

  constructor(private http: HttpClient) {
    this.usuario = {} as Usuario;
  }

  getUsuario(usuario: Usuario): Observable<Usuario> {
    const url = this.apiUrl + "";

    return this.http.get<Usuario>(url)
      .pipe();
  }

  
}
