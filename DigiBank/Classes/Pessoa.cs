using DigiBank.contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DigiBank.Classes
{
    public class Pessoa
    {
        public string Nome { get; protected set; }
        public string CPF { get; protected set; }
        public string Senha { get; protected set; }
        public IConta Conta { get; set; }

        public void SetNome(String nome) 
        {
            this.Nome = nome;
        
        }
        public void SetCPF(string cpf) 
        {
            this.CPF = cpf;
        }
        public void SetSenha(string senha )
        {
            this.Senha = senha;
        }
    }
 }

