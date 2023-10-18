using CadastroPeopleList;
using DataBaseClass;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace Controller
{
    public class CadastroPeople : ICadastroPeople
    {
        private static List<Person> peopleList = new List<Person>();
        Conexao conexao = new Conexao();
        SqlCommand cmd = new SqlCommand();
        public String mensagem;

        public void AddPerson()
        {
            Console.WriteLine("Digite o id da pessoa: ");
            int idPerson = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o nome da pessoa: ");
            string namePerson = Convert.ToString(Console.ReadLine());

            peopleList.Add(new Person(idPerson, namePerson));      
            cmd.CommandText = string.Format("insert into Pessoa (Id, Nome) values ('{0}', '{1}')" , idPerson, namePerson);

            //cmd.CommandText = "insert into Pessoa (Id, Nome) values (@Id, @Nome)";
            //cmd.Parameters.AddWithValue("@Id", idPerson);
            //cmd.Parameters.AddWithValue("@Nome", namePerson);

            try
            {
                cmd.Connection = conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
                this.mensagem = "Cadastrado com sucesso";
            }
            catch (SqlException e)
            {
                this.mensagem = "Erro ao tentar se conectar {0}" + e.Message;
            }                 
        }

        public void ShowPeople()
        {
            //if (peopleList.Count == 0)
            //{
            //    Console.WriteLine("Lista vazia");
            //}
            //else
            //{
            //    cmd.CommandText = "select * from Pessoa";
            //    try
            //    {
            //        cmd.Connection = conexao.Conectar();
            //        SqlDataReader dados = cmd.ExecuteReader();
            //        while (dados.Read())
            //        {
            //            Console.WriteLine("Id: {0}, Nome: {1}", dados["id"], dados["nome"]);
            //        }
            //        conexao.Desconectar();
            //    }
            //    catch (SqlException e)
            //    {
            //        this.mensagem = "Erro ao tentar se conectar" + e.Message;
            //    }

            //    /*
            //    foreach (Person person in peopleList)
            //    {
            //        Console.WriteLine(person);
            //    }
            //    */
            //}


            cmd.CommandText = "select * from Pessoa";
            try
            {
                cmd.Connection = conexao.Conectar();
                SqlDataReader dados = cmd.ExecuteReader();
                while (dados.Read())
                {
                    Console.WriteLine("Id: {0}, Nome: {1}", dados["id"], dados["nome"]);
                }
                conexao.Desconectar();
            }
            catch (SqlException e)
            {
                this.mensagem = "Lista vazia {0}" + e.Message;
            }
        }

        public void SearchPersonById()
        {
            if (peopleList.Count == 0)
            {
                Console.WriteLine("Lista vazia");
            }
            else
            {
                bool founded = false;
                Console.WriteLine("Buscar pessoa por ID");
                Console.WriteLine("Digite o id da pessoa: ");
                int searchPersonById = Convert.ToInt16(Console.ReadLine());
                cmd.CommandText = "select * from Pessoa where id = " + searchPersonById;
                foreach (Person person in peopleList)
                {
                    if (searchPersonById.Equals(person.Id))
                    {
                        Console.WriteLine("Pessoa encontrada");
                        Console.WriteLine(person.ToString());
                        founded = true;
                    }
                }
                if (!founded)
                {
                    Console.WriteLine("Pessoa não encontrada");
                }
            }

            //bool founded = false;
            //Console.WriteLine("Buscar pessoa por ID");
            //Console.WriteLine("Digite o id da pessoa: ");
            //int searchPersonById = Convert.ToInt16(Console.ReadLine());
            //cmd.CommandText = "select * from Pessoa where id = " + searchPersonById;
            //foreach (Person person in peopleList.ToList())
            //{
            //    if (searchPersonById.Equals(person.Id))
            //    {
            //        Console.WriteLine("Pessoa encontrada");
            //        Console.WriteLine(person.ToString());
            //        founded = true;
            //    }
            //}
            //if (!founded)
            //{
            //    Console.WriteLine("Pessoa não encontrada");
            //}

            try
            {
                cmd.Connection = conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch (SqlException e)
            {
                this.mensagem = "Lista vazia {0}" + e.Message;
            }

        }

        public void EditPerson()
        {
            /*
            if (peopleList.Count == 0)
            {
                Console.WriteLine("Lista vazia");
            }
            else
            {
                bool founded = false;
                Console.WriteLine("Editar Pessoa");
                Console.WriteLine("Informe o id da pessoa que deseja editar");
                int searchPersonById = Convert.ToInt32(Console.ReadLine()); 
                foreach (Person person in peopleList)
                {
                    if (searchPersonById.Equals(person.Id))
                    {
                        Console.WriteLine("Pessoa encontrada");
                        Console.WriteLine(person.ToString());
                        Console.WriteLine("Insira um novo nome para a pessoa: ");
                        string newNamePerson = Convert.ToString(Console.ReadLine());
                        founded = true;
                        person.alterarNome(newNamePerson);
                    }
                }
                if (!founded)
                {
                    Console.WriteLine("Pessoa não encontrada");
                }
            } 
            */

            cmd.CommandText = "update dbo.Pessoa set nome = 'aaaaaa' where id = 1";
            try
            {
                cmd.Connection = conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch (SqlException e)
            {
                this.mensagem = "Lista vazia {0}" + e.Message;
            }
        }

        public void RemovePerson()
        {
            //if (peopleList.Count == 0)
            //{
            //    Console.WriteLine("Lista vazia");
            //}
            //else
            //{
            //    bool founded = false;
            //    Console.WriteLine(" - Remover Pessoa - ");
            //    Console.WriteLine("Informe o id da pessoa que deseja remover: ");
            //    int removePersonById = Convert.ToInt16(Console.ReadLine());
            //    foreach (Person person in peopleList.ToList())
            //    {
            //        if (removePersonById.Equals(person.Id))
            //        {
            //            Console.WriteLine("Pessoa encontrada");
            //            Console.WriteLine(person.ToString());
            //            peopleList.Remove(person);
            //            Console.WriteLine("Pessoa removida");
            //        }
            //    }
            //    if (!founded)
            //    {
            //        Console.WriteLine("Pessoa não encontrada");
            //    }
            //}
            bool founded = false;
            Console.WriteLine(" - Remover Pessoa - ");
            Console.WriteLine("Informe o id da pessoa que deseja remover: ");
            int removePersonById = Convert.ToInt16(Console.ReadLine());
            cmd.CommandText = "delete from dbo.Pessoa where id = " + removePersonById;
            foreach (Person person in peopleList.ToList())
            {
                if (removePersonById.Equals(person.Id))
                {
                    Console.WriteLine("Pessoa encontrada");
                    Console.WriteLine(person.ToString());
                    founded = true;
                    peopleList.Remove(person);
                    Console.WriteLine("Pessoa removida");

                }
            }
            if (!founded)
            {
                Console.WriteLine("Pessoa não encontrada");
            }

            try
            {
                cmd.Connection = conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch (SqlException e)
            {
                this.mensagem = "Lista vazia {0}" + e.Message;
            }
        }

        public void SaveTextFile()
        {
            try
            {
                StreamWriter sw = new StreamWriter("C:\\Users\\Michael\\Desktop\\CadastroPeopleList\\Test.txt");  //Instancia um Objeto StreamWriter (Classe de Manipulação de Arquivos)
                foreach (Person person in peopleList)
                {
                    sw.WriteLine(person);
                }
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executando o Bloco de Comandos.");
            }
        }

        public void ReadDateFromFile()
        {
            StreamReader x;

            string Caminho = "C:\\Users\\Michael\\Desktop\\CadastroPeopleList\\Test.txt";
            x = File.OpenText(Caminho);
            while (x.EndOfStream != true)
            {
                string linha = x.ReadLine();
                Console.WriteLine(linha);
            }
            x.Close();
            Console.ReadKey();
        }
    }
}