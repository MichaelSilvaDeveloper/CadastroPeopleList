using Controller;
using System;
using System.Data.SqlClient;

namespace CadastroPeopleList
{
    internal class Program
    {
        private static ICadastroPeople iCadastroPeople;

        private static void AddPerson() => iCadastroPeople.AddPerson();

        private static void ShowPeople() => iCadastroPeople.ShowPeople();

        private static void SearchPersonById() => iCadastroPeople.SearchPersonById();

        private static void EditPerson() => iCadastroPeople.EditPerson();

        private static void RemovePerson() => iCadastroPeople.RemovePerson();

        private static void SaveTextFile() => iCadastroPeople.SaveTextFile();

        private static void ReadDateFromFile() => iCadastroPeople.ReadDateFromFile();

        private static void InvalidOption()
        {
            Console.WriteLine("Opção inválida");
        }

        private static ICadastroPeople getInstanceCadastroPeople()
        {
            return new CadastroPeople();  
        }

        static void Main(string[] args)
        {
            iCadastroPeople = getInstanceCadastroPeople();

            string option = "";
            while(option != "0")
            {
                Console.WriteLine("\n - CADASTRO PESSOA - ");
                Console.WriteLine("Escolha uma opção: ");
                Console.WriteLine("[ 1 ] - Adicionar Pessoa");
                Console.WriteLine("[ 2 ] - Exibir Pessoas");
                Console.WriteLine("[ 3 ] - Buscar Pessoa Por ID");
                Console.WriteLine("[ 4 ] - Editar Pessoa Por ID");
                Console.WriteLine("[ 5 ] - Remover Pessoa");
                Console.WriteLine("[ 6 ] - Salvar em Arquivo TXT");
                Console.WriteLine("[ 7 ] - Ler dados do aquivo TXT");

                Console.WriteLine("[ 0 ] - Sair");
                option = Convert.ToString(Console.ReadLine());

                switch (option)
                {
                    case "1":
                        Console.Clear();
                        AddPerson();
                        break;
                    case "2":
                        Console.Clear();
                        ShowPeople();
                        break;
                    case "3":
                        Console.Clear();
                        SearchPersonById();
                        break;
                    case "4":
                        Console.Clear();
                        EditPerson();                        
                        break;
                    case "5":
                        Console.Clear();
                        RemovePerson();
                        break;
                    case "6":
                        Console.Clear();
                        SaveTextFile();
                        break;
                    case "7":
                        Console.Clear();
                        ReadDateFromFile();
                        break;
                    case "0":
                        break;
                    default:
                        InvalidOption();
                        break;
                }
            }
        }   
    }
}