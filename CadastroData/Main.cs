using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CadastroData
{
    class Teste
    {
        static void Main(string[] args)
        {

            List<Pessoa> pessoas = new List<Pessoa>();

            int SAIR = 5;
            int opcao = Menu();

            while (opcao != SAIR)
            {
                switch (opcao)
                {
                    case 1:
                        CriarCadastro(pessoas);
                        break;
                    case 2:
                        ConsultarCadastro(pessoas);
                        break;
                    case 3:
                        ProcurarCadastro(pessoas);
                        break;
                    case 4:
                        Deletar(pessoas);
                        break;
                    case 5:
                        Console.WriteLine("Programa Encerrado!");
                        Console.ReadLine();
                        break;
                }
                opcao = Menu();
            }
        }

        static int Menu()
        {
            int opcao;
            Console.Clear();
            Console.WriteLine("Cadastro:");
            Console.WriteLine("1) Incluir Pessoa");
            Console.WriteLine("2) Consultar Pessoa");
            Console.WriteLine("3) Buscar Cadastro");
            Console.WriteLine("4) Deletar");
            Console.WriteLine("5) Sair");
            Console.Write("\r\nSelecione a opção: ");
            do
            {
                opcao = int.Parse(Console.ReadLine());
                if ((opcao < 1) || (opcao > 5))
                {
                    Console.WriteLine("Desculpe opção invalida");
                    Console.ReadLine();
                    return opcao;
                }
            }
            while ((opcao <= 0) || (opcao > 5));
            return opcao;
        }

        public static String leNome (String mensagem)
        {
            string nome;
           do
            {
                Console.Write("Informe o nome : ");
                nome = Console.ReadLine();
                if (nome.Length == 0)
                {
                    Console.WriteLine("Entre com o nome ");
                    Console.ReadLine();
                    
                } 
            } while (nome.Length == 0);
            return nome;
        }

        public static String leSobrenome(String mensagem)
        {
            string sobrenome;
            do
            {
                Console.Write("Informe o sobrenome : ");
                sobrenome = Console.ReadLine();
                if (sobrenome.Length == 0)
                {
                    Console.WriteLine("Entre com o sobrenome : ");
                    Console.ReadLine();

                }
            } while (sobrenome.Length == 0);
            return sobrenome;
        }

        public static DateTime leDataEntrada(String mensagem)
        {
            int dia, mes, ano;
            Console.Write("Informe a dia: ");
            dia = int.Parse(Console.ReadLine());
            Console.Write("Informe a mes: ");
            mes = int.Parse(Console.ReadLine());
            Console.Write("Informe a ano: ");
            ano = int.Parse(Console.ReadLine());
            DateTime dataEntrada = new DateTime(ano,mes,dia);
          
            do
            {
                if (dataEntrada == null)
                {
                    Console.WriteLine("Entre com a data ");
                    Console.ReadLine();

                }
            } while (dataEntrada == null);
            return dataEntrada;
        }

        public static void CriarCadastro(List<Pessoa> pessoas)
        {
            string nome, sobrenome;
            DateTime dataEntrada;

            nome = leNome("Entre com o nome :");
            sobrenome = leSobrenome("Entre com o sobrenome : ");
            dataEntrada = leDataEntrada("Entre com a data do seu aniversario :");
            

            Pessoa criarCadastro = new Pessoa(nome, sobrenome, dataEntrada);
            pessoas.Add(criarCadastro);
        }

        public static void ProcurarCadastro(List<Pessoa> pessoa)
        {
            string nome;
            nome = leNome("Entre com o nome :");
            try
            {
                var procurar = pessoa.Single(x => x.Nome == nome);
                Console.WriteLine(procurar.ToString());
                Console.ReadLine();
    
                Console.WriteLine( $"Dias para o proximo aniversario : {procurar.diferencaData()}");
                Console.ReadLine();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine(); 
            }

        }
        public static void Deletar(List<Pessoa> pessoas)
        {
            string nome;
            nome = leNome("Entre com o nome :");
            try
            {
                var procurar = pessoas.Single(x => x.Nome == nome);
                pessoas.Remove(procurar);
                Console.WriteLine("Cadastro deletado com sucesso!");
                Console.ReadLine();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
        public static void ConsultarCadastro(List<Pessoa> pessoas)
        {
            Console.WriteLine("Registro de Cadastro");
            foreach (Pessoa valor in pessoas)
            {
                Console.Write(valor.ToString());
                Console.ReadLine();

            }
        }
    }
}

