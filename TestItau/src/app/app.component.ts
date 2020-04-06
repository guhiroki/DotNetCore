import { Component, OnInit } from '@angular/core';
import { EntidadeManualService } from '../services/entidade-manual.service';
import { ProdutoCosifService } from '../services/produto-cosif.service'
import { ProdutoService } from '../services/produto.service'
import { EntidadeManualExibir } from 'src/Modelos/EntidadeManualExibir';
import { EntidadeManualBase } from 'src/Modelos/EntidadeManualBase';
import { DropDownModel } from 'src/Modelos/DropDownModel';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: [
    './app.component.css',
    "../../node_modules/bootstrap/dist/css/bootstrap.min.css"
  ]
})
export class AppComponent implements OnInit {
  title = 'TestItau';

  entidadesManuais: EntidadeManualExibir[];
  produtosDropDown: DropDownModel[];
  produtosCosifDropDown: DropDownModel[];
  entidadeManual: EntidadeManualBase;
  habilitarCampos: boolean;
  habilitarProdutoCosifDD: boolean;

  constructor(
    private entidadeManualService: EntidadeManualService,
    private produtoCosifService: ProdutoCosifService,
    private produtoService: ProdutoService
    ) {
    
  }

  ngOnInit(): void {
    this.iniciarEntidadeManual();
    this.habilitarCampos = true;
    this.habilitarProdutoCosifDD = false
    this.entidadeManualService.get().subscribe(ems => {
      this.entidadesManuais = ems;
    })
    this.produtoService.get().subscribe(ps => {
      this.produtosDropDown = ps;
      this.habilitarProdutoCosifDD = true
    })
  }

  aoSelecionarProduto(codigoProduto) {
    this.entidadeManual.CodigoProduto = codigoProduto;
    this.produtoCosifService.get(codigoProduto).subscribe(pcs => {
      this.produtosCosifDropDown = pcs;
    })
  }

  aoSelecionarProdutoCosif(codigoProdutoCosif) {
    this.entidadeManual.CodigoProdutoCosif = codigoProdutoCosif
  }

  aoClicarEmNovo() {
    this.habilitarCampos = false;
  }

  aoClicarEmIncluir() {
    this.entidadeManualService.post(this.entidadeManual).subscribe(result =>{
      this.limparEntidadeManual();
      this.entidadeManualService.get().subscribe(ems => {
        this.entidadesManuais = ems;
      })
    })
  }

  aoClicarEmLimpar() {
    this.limparEntidadeManual();
  }

  private limparEntidadeManual() {
    this.entidadeManual.Ano = 0;
    this.entidadeManual.Mes = 0;
    this.entidadeManual.CodigoProduto = '';
    this.entidadeManual.CodigoProdutoCosif = '';
    this.entidadeManual.Descricao = '';
    this.entidadeManual.Valor = 0;
    this.habilitarProdutoCosifDD = false;
    this.habilitarCampos = true;
  }
  
  private iniciarEntidadeManual() {
    let _entidadeManual = {
      Ano: 0,
      Mes: 0,
      CodigoProduto: '',
      CodigoProdutoCosif: '',
      Descricao: '',
      Valor: 0
    }
    this.entidadeManual = _entidadeManual;
  }
}
