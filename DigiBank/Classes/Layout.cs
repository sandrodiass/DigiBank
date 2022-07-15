using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DigiBank.Classes
{

    public class Layout
    {
        private static List<Pessoa> pessoas = new List<Pessoa>();
        private static int opção = 0;
        public static void TelaPrincipal()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("                                         ");
            Console.WriteLine("                 Digite a opção desejada ");
            Console.WriteLine("                 ======================= ");
            Console.WriteLine("                 1- para criar conta     ");
            Console.WriteLine("                 ======================= ");
            Console.WriteLine("                 2- para entrar com CPF e senha");
            Console.WriteLine("                 ======================= ");


            opção = int.Parse(Console.ReadLine());
            switch (opção)
            {
                case 1:
                    TelaCriarConta();
                    break;
                case 2:
                    TelaDeLogin();
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }

        }
        private static void TelaCriarConta()
        {
            Console.Clear();
            Console.WriteLine("                 Digite seu nome  ");
            string nome = Console.ReadLine();
            Console.WriteLine("                 ======================= ");
            Console.WriteLine("                 DIGITE SEU CPF      ");
            string cpf = Console.ReadLine();
            Console.WriteLine("                 ======================= ");
            Console.WriteLine("                 DIGITE SUA SENHA ");
            string senha = Console.ReadLine();
            Console.WriteLine("                 ======================= ");
            //criar uma conta
            ContaCorrente contaCorrente = new ContaCorrente();
            Pessoa pessoa = new Pessoa();
            pessoa.SetNome(nome);
            pessoa.SetCPF(cpf);
            pessoa.SetSenha(senha);
            pessoa.Conta = contaCorrente;
            pessoas.Add(pessoa);
            Console.Clear();
            Console.WriteLine("                                        ");
            Console.WriteLine("                  CONTA CADASTRADA COM SUCESSO  ");
            Console.WriteLine("                 ======================= ");
            Thread.Sleep(1000);
            TelaContaLogada(pessoa);

        }
        private static void TelaDeLogin()
        {
            Console.Clear();
            Console.WriteLine("                                         ");
            Console.WriteLine("                 DIGITE SEU CPF  ");
            Console.WriteLine("                 ======================= ");
            string cpf = Console.ReadLine();
            Console.WriteLine("                 2- para entrar com CPF e senha");
            string senha = Console.ReadLine();
            Console.WriteLine("                 ======================= ");
            Pessoa Pessoa = pessoas.FirstOrDefault(x => x.CPF == cpf && x.Senha == senha);
            if (Pessoa != null)
            {
                TelaBoasVindas(Pessoa);
                TelaContaLogada(Pessoa);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("                                                    ");
                Console.WriteLine("                                                     ");
                Console.WriteLine("                 poessoa não cadastrada              ");

            }
        }
        private static void TelaBoasVindas(Pessoa pessoa)
        {
            string msgtelabenvindo =
                $"{pessoa.Nome }  |  Banco: {pessoa.Conta.GetCodigoDoBanco()} " +
                $"|  Agencia:{pessoa.Conta.GetNumeroDaAgencia()}  | Conta:{pessoa.Conta.GetNumeroDaConta()}";
            Console.WriteLine("                                     ");
            Console.WriteLine("                                     ");
            Console.WriteLine("        Seja vem vindo, " + msgtelabenvindo);
            Console.WriteLine("                                     ");
            Console.WriteLine("                                     ");
        }

        private static void TelaContaLogada(Pessoa pessoa)
        {

            Console.Clear();
            TelaBoasVindas(pessoa);
            Console.WriteLine("                    DIGITE a opção DESEJADA");
            Console.WriteLine("                  =============================");
            Console.WriteLine("                   1- PARA REALIZAR UM DEPOSITO ");
            Console.WriteLine("                  =============================");
            Console.WriteLine("                   2- PARA REALIZAR UM SAQUE   ");
            Console.WriteLine("                  =============================");
            Console.WriteLine("                   3- CONSULTAR SALDO          ");
            Console.WriteLine("                  =============================");
            Console.WriteLine("                   4- EXTRATOS                   ");
            Console.WriteLine("                  =============================");
            Console.WriteLine("                   5- SAIR                       ");
            Console.WriteLine("                  =============================");
            Console.WriteLine("                  =============================");


            opção = int.Parse(Console.ReadLine());
            switch (opção)
            {
                case 1:
                    TelaDeposito(pessoa);
                    break;
                case 2:
                    TelaSaque(pessoa);
                    break;
                case 3:
                    TelaSaldo(pessoa);
                    break;
                case 4:
                    break;
                case 5:
                    TelaPrincipal();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("                 opção invalida          ");
                    break;
            }

        }
        public static void TelaDeposito(Pessoa pessoa)
        {
            Console.Clear();
            TelaBoasVindas(pessoa);
            Console.WriteLine("            Digite o valor do deposito      ");
            double valor = double.Parse(Console.ReadLine());
            Console.WriteLine("            =================================   ");
            pessoa.Conta.Deposita(valor);
            Console.Clear();
            TelaBoasVindas(pessoa);
            Console.WriteLine("                                                            ");
            Console.WriteLine("                                                            ");
            Console.WriteLine("          deposito realizado com sucesso                    ");
            Console.WriteLine("           =============================                   ");
            Console.WriteLine("                                                            ");
            Console.WriteLine("                                                           ");
            OpcaoVoltarLogado(pessoa);
        }
        public static void TelaSaque(Pessoa pessoa)
        {
            Console.Clear();
            TelaBoasVindas(pessoa);
            Console.WriteLine("            Digite o valor do Saque:     ");
            double valor = double.Parse(Console.ReadLine());
            Console.WriteLine("            =================================   ");
            bool oksaque = pessoa.Conta.Saca(valor);   

            Console.Clear();
            TelaBoasVindas(pessoa);
            Console.WriteLine("                                                            ");
            Console.WriteLine("                                                            ");
            if (oksaque)
            {
                Console.WriteLine("          Saque foi realizado com sucesso                    ");
                Console.WriteLine("           =============================                   ");

            }
            else
            {

                Console.WriteLine("           saldo  insuficiente                  ");
                Console.WriteLine("           =============================                   ");
            }
            Console.WriteLine("                                                            ");
            Console.WriteLine("                                                           ");
            OpcaoVoltarLogado(pessoa);
        }
        private static void TelaSaldo(Pessoa pessoa) 
        {

            Console.Clear();
            TelaBoasVindas(pessoa);
            Console.WriteLine($"               Seu saldo é :   {pessoa.Conta.ConsultaSaldo()}      ");
            Console.WriteLine($"              ============================      ");
            OpcaoVoltarLogado(pessoa  );
        }
        private static void TelaExtrato(Pessoa pessoa)
        {

            Console.Clear();
            TelaBoasVindas(pessoa);
            if (pessoa.Conta.extrato().Any()) 
            {
                double total = pessoa.Conta.extrato().Sum(x => x.Valor);

                Console.WriteLine("                                                   ");
                Console.WriteLine("                                                       ");
                Console.WriteLine($"              Sub total :   {total}         ");
                Console.WriteLine("        ==============================            ");
            }
            
            else
            { 
                    Console.WriteLine("    Não há Extrato a ser exibido!             ");
                    Console.WriteLine("        ==============================            ");
             }

            
          


            OpcaoVoltarLogado(pessoa);
        }

        private static void OpcaoVoltarLogado(Pessoa pessoa)
        {
            Console.WriteLine("          Entre com uma opção abaixo                   ");
            Console.WriteLine("           =============================                   ");
            Console.WriteLine("          1-VOLTAR PARA CONTA                    ");
            Console.WriteLine("           =============================                   ");
            Console.WriteLine("           2- Sair                   ");
            Console.WriteLine("           =============================                   ");
            opção = int.Parse(Console.ReadLine());
            if (opção == 1)
            {
                TelaContaLogada(pessoa);
            }
            else
            {

                TelaPrincipal();
            }
        }
        private static void OpcaoVolDeslogado()
        {
            Console.WriteLine("          Entre com uma opção abaixo                   ");
            Console.WriteLine("           =============================                   ");
            Console.WriteLine("          1-VOLTAR PARA menu principal                    ");
            Console.WriteLine("           =============================                   ");
            Console.WriteLine("           2- Sair                   ");
            Console.WriteLine("           =============================                   ");
            opção = int.Parse(Console.ReadLine());
            if (opção == 1)
            {
                TelaPrincipal();
            }
            else
            {

                Console.WriteLine("                  opção invalida              ");
                Console.WriteLine("                  ===============              ");
            }
        }
    }
}
