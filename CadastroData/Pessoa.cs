using System;

namespace CadastroData
{
    class Pessoa
    {
        private DateTime dataEntrada;
        private string nome, sobrenome;

        public Pessoa()
        {
        }
        public Pessoa(string nome, string sobrenome, DateTime dataEntrada)
        {
            this.nome = nome;
            this.sobrenome = sobrenome;
            this.dataEntrada = dataEntrada;
        }
        public DateTime DataEntrada
        {
            get { return dataEntrada; }
            set { dataEntrada = value; }
        }
        public string Nome {
            get { return nome; }
            set { nome = value; }
        }
        public string Sobrenome {
            get { return sobrenome; }
            set { sobrenome = value; }
        }
        public String diferencaData ()
        {
            DateTime data = DateTime.Now;
            double mes = (dataEntrada.Month - data.Month);
            if (mes < 0)
            {
                mes +=12;
            }
            double dias = (data.Day - dataEntrada.Day);
            if ((data.Month == dataEntrada.Month) && (data.Day == dataEntrada.Day)) {

                Console.WriteLine($"Feliz aniversario !!! ");
                Console.ReadLine();
            }
            return "Faltam : " + mes + " meses e " + dias + " dias para o seu aniversario" ; 
        }
        public override string ToString()
        {
            String data = String.Format("{0:MM/dd/yyyy}", dataEntrada);
            return "Cadastro : " + Nome + " " + Sobrenome + " Data de Nascimento " + data;
        }
    }
}
