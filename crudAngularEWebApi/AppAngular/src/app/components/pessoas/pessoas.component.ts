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

    // this.tituloFormulario = "Cadastre uma pessoa"
    // this.formulario = new FormGroup({
    //   Name: new FormControl(null),
    //   LastName: new FormControl(null),
    //   Age: new FormControl(null)
    // })    
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

    if(this.pessoaId > 0){
      this.pessoaService.putPessoa(pessoa).subscribe(result =>{
        alert("Pessoa atualizada com sucesso");
        this.AtualizarLista()
      })
    }else{
        this.pessoaService.postPessoa(pessoa).subscribe(result => {
        alert("Pessoa Cadastrada com sucesso no banco")
        this.AtualizarLista()
        this.AlternaTabelaForm()
    })
    }
  }

  Atualizar(pessoa: Pessoa): void{

    this.tituloFormulario = "Atualize o cadastro"
    this.formulario = new FormGroup({
      UserId: new FormControl(pessoa.UserID),
      Name: new FormControl(pessoa.Age),
      LastName: new FormControl(pessoa.LastName),
      Age: new FormControl(pessoa.Age)
    })

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

  Limpar(): void{
    console.log("Limpar")
  }

  Voltar(): void{
    this.AlternaTabelaForm();
  }

  ExibirModal(userId: number, name: string, modalConfirmaExclusao: TemplateRef<any>) {
    this.modalRef = this.modalService.show(modalConfirmaExclusao);
    this.pessoaId = userId;
    this.nomePessoa = name;
  }

  AtualizarLista(): void{
    this.pessoaService.getAllPessoas().subscribe(result => (this.listPessoas = result))
  }

  AlternaTabelaForm(): void{
    this.visibilidadeTabela = !this.visibilidadeTabela
    this.visibilidadeFormulario = !this.visibilidadeFormulario
  }

}
