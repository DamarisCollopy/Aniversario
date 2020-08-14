using System;

namespace CadastroData
{
    class Program
    {
        private DateTime dataEntrada;
        private String nome, sobrenome;

        public Program(String nome, String sobrenome, DateTime dataEntrada)
        {
            nome = nome;
            sobrenome = sobrenome;
            dataEntrada = dataEntrada;
        }

        public DateTime DataEntrada{get;set;}
        public String Nome {get;set;}
        public String Sobrenome {get;set;}

        
    }
}
