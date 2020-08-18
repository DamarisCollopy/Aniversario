using System;
using System.Collections.Generic;

namespace CadastroData
{
    class Teste
    {
        static void Main(string[] args)
        {

            List<Program> pessoa = new List<Program>();

            int SAIR = 5;
            int opcao = Menu();

            while (opcao != SAIR)
            {
                switch (opcao)
                {
                    case 1:
                        CriarCadastro(pessoa);
                       
                        break;
                    case 2:
                        ConsultarCadastro(pessoa);
                        break;
                    case 3:
                        
                        break;
                    case 4:
                      
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
            Console.WriteLine("3) Excluir Pessoa");
            Console.WriteLine("4) Exit");
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
            String nome;
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
            String sobrenome;
            do
            {
                Console.Write("Informe o nome : ");
                sobrenome = Console.ReadLine();
                if (sobrenome.Length == 0)
                {
                    Console.WriteLine("Entre com o nome ");
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

        public static void CriarCadastro(List<Program> pessoa)
        {
            string nome, sobrenome;
            DateTime dataEntrada;

            nome = leNome("Entre com o nome :");
            sobrenome = leSobrenome("Entre com o sobrenome : ");
            dataEntrada = leDataEntrada("Entre com a data do seu aniversario :");

            Program criarCadastro = new Program(nome, sobrenome, dataEntrada);
            pessoa.Add(criarCadastro);
           
              
        }

        public static void ConsultarCadastro(List<Program> pessoa)
        {
            Console.WriteLine("Registro de Cadastro");
            foreach (Program valor in pessoa)
            {
                Console.Write(valor);
            }
        }
    }
}

