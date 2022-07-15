using DigiBank.contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBank.Classes
{
    public class Conta : Banco, IConta
    {
        public Conta()
        {
            this.NumeroDaAgencia = "001";
            Conta.NumeroDaContaSequencial++;
            this.Movimentacoes = new List<Extrato>();
        }
        public double Saldo { get; protected set; }
        public string NumeroDaAgencia { get; private set; }
        public string NumeroDaConta { get; protected set; }
        public static int NumeroDaContaSequencial { get; private set; }
        private List<Extrato> Movimentacoes;
        public double ConsultaSaldo()
        {
            return this.Saldo;
        }

        public void Deposita(double valor)
        {
            DateTime DataAtual = DateTime.Now;
            this.Movimentacoes.Add(new Extrato(DataAtual, "Deposito", valor));
            this.Saldo += valor;
        }


        public bool Saca(double valor)
        {
            if (valor > this.ConsultaSaldo())
            
                return false;
            DateTime DataAtual = DateTime.Now;
            this.Movimentacoes.Add(new Extrato(DataAtual, "Saque", valor));
            this.Saldo -= valor;
                return true;
            
            
        }

        public string GetCodigoDoBanco()
        {
            return this.CodigoDoBanco;
        }

        public string GetNumeroDaConta()
        {
            return this.NumeroDaConta;
        }
        public string GetNumeroDaAgencia()
        {
            return this.NumeroDaAgencia;
        }

        public List<Extrato> extrato()
        {
            return this.Movimentacoes;
        }
    }

}

