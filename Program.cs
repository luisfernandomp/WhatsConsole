using System;
using System.Collections.Generic;
using System.Threading;

namespace WhatsappConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Mensagem novaMensagem = new Mensagem();
            Agenda agenda = new Agenda();
            Contato c = new Contato();

            bool teste = true;
            string msg = "", op = "";

            while (teste == true){
                agenda.Whats();
                System.Console.WriteLine("-       MENU DE OPÇÕES            -");
                System.Console.WriteLine("- 1 - Criar novo contato          -");
                System.Console.WriteLine("- 2 - Excluir contato             -");
                System.Console.WriteLine("- 3 - Enviar mensagem             -");
                System.Console.WriteLine("- 0 - Sair                        -");
                System.Console.WriteLine("-----------------------------------");
                op = Console.ReadLine();
                System.Console.WriteLine("Aguarde...");
                Thread.Sleep(2000);
                switch (op)
                {
                    case "1": 
                        agenda.Whats();
                        System.Console.WriteLine("------------ ADICIONAR CONTATO\n");
                        System.Console.Write("Nome: ");
                        c.Nome = Console.ReadLine();
                        System.Console.Write("Telefone: ");
                        c.Telefone = Console.ReadLine();
                        agenda.Cadastrar(c);
                    ;break;
                    case "2":
                        agenda.Whats();
                        System.Console.WriteLine("------------ EXCLUIR CONTATO\n");
                        System.Console.WriteLine("____SEUS___CONTATOS_________");
                        agenda.Listar();
                        System.Console.WriteLine("____________________________");
                        System.Console.Write("Nome: ");
                        c.Nome = Console.ReadLine();
                        System.Console.Write("Telefone: ");
                        c.Telefone = Console.ReadLine();
                        agenda.Excluir(c);
                    ;break;
                    case "3": 
                        bool t = true;
                        while(t == true){
                            agenda.Whats();
                            System.Console.WriteLine("____SEUS___CONTATOS_________");
                            agenda.Listar();
                            System.Console.WriteLine("____________________________");
                            System.Console.WriteLine("Mensagem: \n");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            msg = Console.ReadLine();
                            if(msg != "" && msg.Length > 0){
                                Console.ResetColor();
                                Thread.Sleep(2000);
                                System.Console.Write("Destinatário (Escreva o nome): ");
                                c.Nome = Console.ReadLine();
                                t = novaMensagem.Enviar(c, msg);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                            }else{
                                Console.ResetColor();
                                System.Console.WriteLine("A mensagem não pode estar vazia!");
                                System.Console.WriteLine("Deseja tentar novamento? Responda com true (sim) ou false (não)");
                                try
                                {
                                    t = Convert.ToBoolean(Console.ReadLine());
                                }
                                catch (System.Exception e)
                                {
                                    System.Console.WriteLine("Ocorreu um erro tente novamente!" + e);
                                }
                            }
                        }
                    ;break;
                    case "0": 
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        System.Console.WriteLine("Até logo...");
                        Thread.Sleep(2000);
                        Console.ResetColor();
                        System.Environment.Exit(0);
                    ;break;
                    default: 
                        Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine("Opção inválida!");
                        Thread.Sleep(2000);
                        Console.ResetColor();
                    ;break;
                }
            }
        }
        
    }
}
