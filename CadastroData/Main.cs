using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace CadastroData
{
    class Teste
    {
        static void Main(string[] args)
        {
            List<Pessoa> pessoas = new List<Pessoa>();

            int SAIR = 6;
            int opcao = Menu();

            while (opcao != SAIR)
            {
                switch (opcao)
                {
                    case 1:
                        CriarCadastro(pessoas);
                        EscreverArquivo(pessoas);
                        LerArquivo(pessoas);
                        break;
                    case 2:
                        ConsultarCadastro(pessoas);
                        break;
                    case 3:
                        ProcurarCadastro(pessoas);
                        break;
                    case 4:
                        Editar(pessoas);
                        break;
                    case 5:
                        Deletar(pessoas);
                        break;
                    case 6:
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
            Console.WriteLine("2) Consultar Cadastro");
            Console.WriteLine("3) Buscar Cadastro");
            Console.WriteLine("4) Editar");
            Console.WriteLine("5) Deletar");
            Console.WriteLine("6) Sair");
            Console.Write("\r\nSelecione a opção: ");
            do
            {
                opcao = int.Parse(Console.ReadLine());
                if ((opcao < 1) || (opcao > 6))
                {
                    Console.WriteLine("Desculpe opção invalida");
                    Console.ReadLine();
                    return opcao;
                }
            }
            while ((opcao <= 0) || (opcao > 6));
            return opcao;
        }
        public static String leNome(String mensagem)
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
        public static int leDia(String mensagem)
        {
            int dia;
            do
            {
                Console.Write("Informe o dia do seu nascimento : ");
                dia = int.Parse(Console.ReadLine());
                if (dia <= 0)
                {
                    Console.WriteLine("Informe uma data valida : ");
                    Console.ReadLine();

                }
            } while (dia <= 0);
            return dia;
        }
        public static int leMes(String mensagem)
        {
            int mes;
            do
            {
                Console.Write("Informe o mês do seu nascimento : ");
                mes = int.Parse(Console.ReadLine());
                if ((mes <= 0) || (mes > 12))
                {
                    Console.WriteLine("Informe uma mês valida : ");
                    Console.ReadLine();

                }
            } while ((mes <= 0) || (mes > 12));
            return mes;
        }
        public static int leAno(String mensagem)
        {
            int ano;
            do
            {
                Console.Write("Informe o ano do seu nascimento : ");
                ano = int.Parse(Console.ReadLine());
                if (ano <= 0)
                {
                    Console.WriteLine("Informe um ano valida : ");
                    Console.ReadLine();

                }
            } while (ano <= 0);
            return ano;
        }
        public static DateTime leDataEntrada(String mensagem)
        {
            int dia, mes, ano;
            dia = leDia("Informe o dia do seu nascimento: ");
            mes = leMes("Informe o mês do seu nascimento : ");
            ano = leAno("Informe o ano do seu nascimento : ");
            DateTime dataEntrada = new DateTime(ano, mes, dia);

            return dataEntrada;
        }
        public static void CriarCadastro(List<Pessoa> pessoas)
        {
            string nome, sobrenome;
            DateTime dataEntrada;
            string opcao = "s";
            while (true)
            {
                nome = leNome("Entre com o nome :");
                sobrenome = leSobrenome("Entre com o sobrenome : ");
                dataEntrada = leDataEntrada("Entre com a data do seu aniversario :");
                Pessoa criarCadastro = new Pessoa(nome, sobrenome, dataEntrada);
                pessoas.Add(criarCadastro);
                Console.Write("Deseja inserir mais usuarios: s/n ");
                opcao = (Console.ReadLine());
                if (opcao != "s")
                {
                    break;
                }
            }
        }
        public static void ProcurarCadastro(List<Pessoa> pessoas)
        {
            string nome, sobrenome;
            nome = leNome("Entre com o nome :");
            sobrenome = leSobrenome("Entre com o sobrenome");
          
            try
            {
                var procurar = pessoas.Single(x => x.Nome == nome && x.Sobrenome == sobrenome);
                Console.WriteLine(procurar.ToString());
                Console.ReadLine();

                Console.WriteLine($"Dias para o proximo aniversario : {procurar.diferencaData()}");
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
            string nome, sobrenome;
            nome = leNome("Entre com o nome :");
            sobrenome = leSobrenome("Entre com o sobrenome");
            try
            {
                var procurar = pessoas.SingleOrDefault(x => x.Nome == nome && x.Sobrenome == sobrenome);
                pessoas.Remove(procurar);
                Console.WriteLine("Cadastro deletado com sucesso!");
                Console.ReadLine();
                DeleteArquivo(pessoas);
                Console.WriteLine("Arquivo deletado com sucesso!");
                Console.ReadLine();
                EscreverArquivo(pessoas);
                LerArquivo(pessoas);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
        public static void Editar(List<Pessoa> pessoas)
        {
            string nome, sobrenome;
            DateTime dataEntrada;
            nome = leNome("Entre com o nome :");
            sobrenome = leSobrenome("Entre com o sobrenome : ");
            try
            {
                var procurar = pessoas.SingleOrDefault(x => x.Nome == nome && x.Sobrenome == sobrenome);
                DeleteArquivo(pessoas);
                pessoas.Remove(procurar);
                Console.WriteLine("Informe as correções !");
                nome = leNome("Entre com o nome :");
                sobrenome = leSobrenome("Entre com o sobrenome : ");
                dataEntrada = leDataEntrada("Entre com a data do seu aniversario :");
                Pessoa criarCadastro = new Pessoa(nome, sobrenome, dataEntrada);
                pessoas.Add(criarCadastro);
                Console.WriteLine("Cadastro editado com sucesso!");
                Console.ReadLine();
                EscreverArquivo(pessoas);
                LerArquivo(pessoas);
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
            {
                foreach (Pessoa valor in pessoas)
                {
                    Console.Write(valor.ToString());
                    Console.ReadLine();
                    Console.WriteLine($"Dias para o proximo aniversario : {valor.diferencaData()}");
                    Console.ReadLine();
                }
            }
        }
        private static void EscreverArquivo(List<Pessoa> pessoas)
        {

            var diretorio = @"C:\Users\Damaris-PC\source\repos\Damis1988\Arquivo";

            if (!Directory.Exists(diretorio))
            {
                Directory.CreateDirectory(diretorio);
            }
            else
            {
                Console.WriteLine("AVISO: O diretório já existe.");
            }
            var nomeArquivo = "cadastro.csv";
            var caminhoArquivo = Path.Combine(diretorio, nomeArquivo);
            var csv = new StringBuilder();

            if (!File.Exists(caminhoArquivo))
            {
                csv.AppendLine("NOME;SOBRENOME;DATA");
                File.WriteAllText(caminhoArquivo, csv.ToString());
            }
            csv.Clear();

            foreach (Pessoa valor in pessoas)
            {
                csv.AppendLine($"{valor}");
            }
            File.AppendAllText(caminhoArquivo, csv.ToString());
        }
        private static void LerArquivo(List<Pessoa> pessoas)
        {
            var diretorio = @"C:\Users\Damaris-PC\source\repos\Damis1988\Arquivo";
            var nomeArquivo = "cadastro.csv";
            var caminhoArquivo = Path.Combine(diretorio, nomeArquivo);

       
            var linhas = File.ReadAllLines(caminhoArquivo);

            ArraySegment<string> linhasSegmento = new ArraySegment<string>(linhas);
           
            var dados = linhasSegmento.Slice(1);

            foreach (var linha in dados)
            {
                Pessoa p = new Pessoa();
                //Caracteres de separação dos elementos:
                Char[] tokens = new Char[] { ';', ',', '\n' };
                string[] dadosCadastro = linha.Split(tokens);
            }

            Console.WriteLine("Cadastro:");
            foreach (var c in pessoas)
            {
                Console.WriteLine($"Cadastro: {c}");
            }
        }
        private static void DeleteArquivo(List<Pessoa> pessoas)
        {
            var diretorio = @"C:\Users\Damaris-PC\source\repos\Damis1988\Arquivo";
            var nomeArquivo = "cadastro.csv";
            var caminhoArquivo = Path.Combine(diretorio, nomeArquivo);

            if (Directory.Exists(diretorio))
            {
                Directory.Delete(diretorio,true);
            }
            else
            {
                Console.WriteLine("AVISO: Diretorio nao existe.");
            }

        }
    }
}

