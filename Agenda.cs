using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace WhatsappConsole
{
    public class Agenda : IAgenda 
    {
        private const string PATH = "Database/contatos.csv";
        private const string PATH1 = "Database/mensagens.csv";
        List<Contato> Contatos = new List<Contato>();
        List<Mensagem> Mensagens = new List<Mensagem>();
        
        /// <summary>
        /// Método construtor da classe Agenda: responsável por criar o diretório e o arquivo csv. 
        /// </summary>
        public Agenda(){
            if(!(Directory.Exists(PATH))){
                Directory.CreateDirectory("Database");
            }
            if(!(File.Exists(PATH))){
                File.Create(PATH).Close();
            }
            if(!(File.Exists(PATH1))){
                File.Create(PATH1).Close();
            }
        }

        /// <summary>
        /// Método da classe agenda: responsável por adicionar um novo contato no arquivo csv 
        /// </summary>
        /// <param name="_novoContato"> Recebe como argumento o objeto Contato (atributos : nome, telefone)</param>
        public void Cadastrar(Contato _novoContato)
        {
            var novoC = new string[]{ PrepararLinhaCSV(_novoContato)};
            File.AppendAllLines(PATH, novoC);
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine("Contato salvo com sucesso!");
            Console.ResetColor();
            Thread.Sleep(2000);
        }

        /// <summary>
        /// Método que lê as linhas do arquivo csv e excluí o contato escolhido pelo usuário.
        /// </summary>
        /// <param name="_excluirContato"> Recebe como argumento o objeto Contato (atributos : nome, telefone)</param>
        public void Excluir(Contato _excluirContato)
        {
            List<string> linhas = new List<string>();
            using(StreamReader leitor = new StreamReader(PATH)){
                string linha;
                while((linha = leitor.ReadLine()) != null){
                    linhas.Add(linha); 
                }
            }
             bool teste = linhas.Any(x => x.Split(";")[0].Split("=")[1] == _excluirContato.Nome.ToString());
             if(teste == true){
                linhas.RemoveAll(x => x.Contains(_excluirContato.Nome));

                using(StreamWriter escrever = new StreamWriter(PATH)){
                    foreach (string ln in linhas)
                    {
                        escrever.Write(ln + "\n");
                    }
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                System.Console.WriteLine("Contato excluído com sucesso!");
             }else{
                 Console.ForegroundColor = ConsoleColor.Red;
                 System.Console.WriteLine("Contato inexistente!");
             }
                Console.ResetColor();
                Thread.Sleep(2000);
        }

        /// <summary>
        /// Método sem arqumento responsável por listar todos os contatos do arquivo csv
        /// </summary>
        public void Listar()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            List<string> linhas = new List<string>();
            using(StreamReader leitor = new StreamReader(PATH)){
                string linha;
                while((linha = leitor.ReadLine()) != null){
                    System.Console.WriteLine($" Nome: {linha.Split(";")[0].Split("=")[1]}  - Telefone: {linha.Split(";")[1].Split("=")[1]}");
                }
            }
            Console.ResetColor();
        }

        /// <summary>
        /// Método usado para gerar a logo do sistema
        /// </summary>
        public void Whats(){
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Green;
            System.Console.WriteLine("-----------------------------------");
            System.Console.WriteLine("-             WHATSAPP            -");
            System.Console.WriteLine("-----------------------------------");
            Console.ResetColor();
        }

        /// <summary>
        /// Prepara as linhas a serem incorporadas ao arquivo csv
        /// </summary>
        /// <param name="novoContato"> Objeto Contato criado</param>
        /// <returns> Retorna a linha pronta para ser adicionada no arquivo csv</returns>
        private string PrepararLinhaCSV(Contato novoContato){
            return $"nome={novoContato.Nome};telefone={novoContato.Telefone}";
        }
    }
}