using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace WhatsappConsole
{
    public class Mensagem
    {
        public string Texto { get; set; }
        public string Destinatario { get; set; }
        private const string PATH1 = "Database/mensagens.csv";
        private const string PATH = "Database/contatos.csv";

        public bool Enviar(Contato _destinatarioContato, string _texto){
            List<string> linhas = new List<string>();
            using(StreamReader leitor = new StreamReader(PATH)){
                string linha;

                // Enquanto a linha do arquivo csv for diferente de vazio(null), o laço irá rodar
                while((linha = leitor.ReadLine()) != null){
                    linhas.Add(linha); 
                }
            }
            bool teste = linhas.Any(x => x.Split(";")[0].Split("=")[1] == _destinatarioContato.Nome.ToString());
            if(teste == true){
                this.Texto = _texto;
                this.Destinatario = _destinatarioContato.Nome;
                var novoM = new string[]{ PrepararLinhaCSVMensagem(Texto, Destinatario)};
                File.AppendAllLines(PATH1, novoM);
                Console.ForegroundColor = ConsoleColor.Blue;
                System.Console.WriteLine("Mensagem enviada com sucesso!");
                Console.ResetColor();
                Thread.Sleep(2000);
                return false;
            }else{
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Destinatário inválido!");
                Console.ResetColor();
                System.Console.WriteLine("Deseja tentar novamento? Responda com true (sim) ou false (não)");
                try
                {
                    teste = Convert.ToBoolean(Console.ReadLine());
                    if(teste == true){
                        Thread.Sleep(2000);
                        return true;
                    }else{
                        Thread.Sleep(2000);
                        return false;
                    }
                }
                catch (System.Exception)
                {
                    System.Console.WriteLine("Ocorreu um erro tente novamente!");
                    Thread.Sleep(2000);
                    return true;
                }
            }
        }
        private string PrepararLinhaCSVMensagem(string novaMensagem, string Destinatario ){
            return $"destinatario={Destinatario};texto={novaMensagem}";
        }
    }
}