import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Pessoa } from '../../Pessoa';
import { PessoaService } from '../../pessoa.service';
import { ButtonsModule } from 'ngx-bootstrap/buttons';
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
  }

  ExibirFormularioTabela(): void{

    this.tituloFormulario = "Cadastre uma pessoa"
    this.formulario = new FormGroup({
      Name: new FormControl(null),
      LastName: new FormControl(null),
      Age: new FormControl(null)
    })  

    this.AlternaTabelaForm()  
  }

  Enviar(): void{
    const pessoa: Pessoa = this.formulario.value;

    console.log("Enviado", pessoa)

    const id = pessoa.UserID;

    console.log("id", id)


    if(id > 0){
      console.log("Atualizar")
      this.pessoaService.putPessoa(pessoa).subscribe(result =>{
        alert("Pessoa atualizada com sucesso");
        this.AtualizarLista()
        this.AlternaTabelaForm()
      })
    }else{
        this.pessoaService.postPessoa(pessoa).subscribe(result => {
        alert("Pessoa Cadastrada com sucesso no banco")
        this.AtualizarLista()
        this.AlternaTabelaForm()
    })
    }
  }

  Atualizar(userid: number): void{

    this.pessoaService.getPessoa(userid).subscribe((resultado) => {
      console.log("resultado -", resultado.userID)
      this.tituloFormulario = `Atualizar ${resultado.name} ${resultado.lastName}`;
      this.formulario = new FormGroup({
        UserID: new FormControl(resultado.userID),
        Name: new FormControl(resultado.name),
        LastName: new FormControl(resultado.lastName),
        Age: new FormControl(resultado.age),
      });
    });

    this.AlternaTabelaForm(); 
  }

  Deletar(userid: number): void{
    try {
      this.pessoaService.deletePessoa(userid).subscribe(result => {
        this.modalRef?.hide();
        alert("Usuário excluido com sucesso")
        this.AtualizarLista()
      })    
    } catch (error) {
      console.log(error)
    }
  }

  Voltar(): void{
    this.AlternaTabelaForm();
  }

  ExibirModal(userId: number, name: string, modalConfirmaExclusao: TemplateRef<any>) {
    try{
      console.log("Qual foi")
      this.modalRef = this.modalService.show(modalConfirmaExclusao);
      this.pessoaId = userId;
      this.nomePessoa = name;
    }catch(error){
      console.log(error)
    }
  }

  AtualizarLista(): void{
    this.pessoaService.getAllPessoas().subscribe(result => (this.listPessoas = result))
  }

  AlternaTabelaForm(): void{
    this.visibilidadeTabela = !this.visibilidadeTabela
    this.visibilidadeFormulario = !this.visibilidadeFormulario
  }

}
