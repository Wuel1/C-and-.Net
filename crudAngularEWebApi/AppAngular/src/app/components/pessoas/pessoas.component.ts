import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Pessoa } from '../../Pessoa';
import { PessoaService } from '../../pessoa.service';

@Component({
  selector: 'app-pessoas',
  standalone: false,
  
  templateUrl: './pessoas.component.html',
  styleUrl: './pessoas.component.css'
})
export class PessoasComponent implements OnInit {

  formulario: any;
  tituloFormulario: any;
  
  constructor(private pessoaService: PessoaService) {}

  ngOnInit(): void {

    this.tituloFormulario = "Cadastre uma pessoa"
    this.formulario = new FormGroup({
      Name: new FormControl(null),
      LastName: new FormControl(null),
      Age: new FormControl(null)
    })    
  }

  Enviar(): void{
    const pessoa: Pessoa = this.formulario.value;

    this.pessoaService.postPessoa(pessoa).subscribe(result => (
      alert("Pessoa Cadastrada com sucesso no banco")
    ));
  }

}
