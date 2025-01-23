import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-pessoas',
  standalone: false,
  
  templateUrl: './pessoas.component.html',
  styleUrl: './pessoas.component.css'
})
export class PessoasComponent implements OnInit {

  formulario: any;
  tituloFormulario: any;
  
  constructor() {}

  ngOnInit(): void {

    this.tituloFormulario = "Cadastre uma pessoa"
    this.formulario = new FormGroup({
      Name: new FormGroup(null),
      LasName: new FormGroup(null),
      Age: new FormGroup(null)
    })
    
  }

}
