using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace AgendaTelefonica {
    class Agenda {

        public int Opcao { get; set; }
        public string Nome { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public int ID;

        public Agenda() {

        }

        public Agenda(int opcao) {
            Opcao = opcao;

        }

        public Agenda(string nome, string telefone, string email) {
            Nome = nome;
            Telefone = telefone;
            Email = email;

        }

        public Agenda(int id, string nome, string telefone, string email) : this (nome, telefone, email) { 
            ID = id;
            Nome = nome;
            Telefone = telefone;
            Email = email;

        }

        public int Id {
            get { return ID; }

            set {

                if (value > 0) {
                    ID = value;

                } else {
                    Console.WriteLine("\n\t\t\t\tID inválido!");
                    Console.Write("\t\t\t\tInforme ID um valido: ");
                    value = int.Parse(Console.ReadLine());
                    ID = value;

                }

            }

        }

      

        public override string ToString() {
            return $"Nome: {Nome} | Id: {ID} | Telefone: {Telefone} | E-mail: {Email}";
        }

        

    }
}
