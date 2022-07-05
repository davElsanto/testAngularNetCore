import { Component, OnInit } from '@angular/core';
import { Usuario } from '../models/usuario';
import { BackserviceService } from '../services/backservice.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  usuario: Usuario
  nombre: string
  clave: string
  constructor(private back: BackserviceService) {
    this.usuario = {} as Usuario
    this.nombre = ""
    this.clave = ""
  }

  ngOnInit(): void {
  }

  login(){                
    console.log(this.nombre);
    console.log(this.clave);
    this.usuario.nombre = this.nombre;
    this.usuario.clave = this.clave;
    this.back.getUsuario(this.usuario)
      .subscribe(
        ok => console.log(ok),
        error => console.error(error)
      );
  }

}
