import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Pessoa } from '../../Pessoa';
import { PessoaService } from '../../pessoa.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-pessoas',
  standalone: false,
  
  templateUrl: './pessoas.component.html',
  styleUrl: './pessoas.component.css'
})
export class PessoasComponent implements OnInit {

  formulario: any;
  tituloFormulario: any;
  listPessoas: Pessoa[] | any
  nomePessoa: string | undefined;
  pessoaId!: number;

  visibilidadeTabela: boolean = true;
  visibilidadeFormulario: boolean = false;

  modalRef: BsModalRef | undefined;
  
  constructor(private pessoaService: PessoaService, private modalService: BsModalService) {}

  ngOnInit(): void {

    this.pessoaService.getAllPessoas().subscribe(result => {
      this.listPessoas = result;
      console.log(result)
    })

    this.tituloFormulario = "Cadastre uma pessoa"
    this.formulario = new FormGroup({
      Name: new FormControl(null),
      LastName: new FormControl(null),
      Age: new FormControl(null)
    })    
  }

  ExibirFormularioTabela(): void{

    this.visibilidadeTabela = !this.visibilidadeTabela
    this.visibilidadeFormulario = !this.visibilidadeFormulario

    this.tituloFormulario = "Cadastre uma pessoa"
    this.formulario = new FormGroup({
      Name: new FormControl(null),
      LastName: new FormControl(null),
      Age: new FormControl(null)
    })    
  }

  Enviar(): void{
    const pessoa: Pessoa = this.formulario.value;

    this.pessoaService.postPessoa(pessoa).subscribe(result => {
      this.visibilidadeFormulario = !this.visibilidadeFormulario
      this.visibilidadeTabela = !this.visibilidadeTabela
      alert("Pessoa Cadastrada com sucesso no banco")
      this.pessoaService.getAllPessoas().subscribe(result => (this.listPessoas = result))
  });
  }

  Atualizar(pessoa: Pessoa): void{
    this.tituloFormulario = "Atualize o cadastro"
    this.formulario = new FormGroup({
      Name: new FormControl(pessoa.Age),
      LastName: new FormControl(pessoa.LastName),
      Age: new FormControl(pessoa.Age)
    })

    const newPessoa = this.formulario.value;
    
    this.pessoaService.putPessoa(newPessoa).subscribe(result => alert("Teste"))
  }

  Deletar(userid: number): void{
    try {
      this.pessoaService.deletePessoa(userid).subscribe(result => {
        this.modalRef?.hide();
        alert("Usuário excluido com sucesso")
        this.pessoaService.getAllPessoas().subscribe(result => (this.listPessoas = result))
      })    
    } catch (error) {
      console.log(error)
    }
  }

  Limpar(): void{
    console.log("Limpar")
  }

  Voltar(): void{
    this.visibilidadeTabela = true;
    this.visibilidadeFormulario = false;
  }

  ExibirModal(userId: number, name: string, modalConfirmaExclusao: TemplateRef<any>) {
    this.modalRef = this.modalService.show(modalConfirmaExclusao);
    this.pessoaId = userId;
    this.nomePessoa = name;
  }

}
