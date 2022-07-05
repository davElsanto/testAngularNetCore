import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Usuario } from '../models/usuario';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BackserviceService {

  private apiUrl = 'api/usuario';
  usuario: Usuario;

  constructor(private http: HttpClient) {
    this.usuario = {} as Usuario;
  }

  getUsuario(usuario: Usuario): Observable<Usuario> {
    const url = this.apiUrl + "";

    return this.http.get<Usuario>(url);
  }

  
}
