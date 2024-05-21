using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atividade2105
{
    internal class Program
    {
        static void Main(string[] args)
        {
                String FG = "";
                Console.ReadKey();
                Cliente[] clientes = new Cliente[10];
                for (int i = 0; i < 10; i++)
                {
                    clientes[i] = new Cliente();
                }

                bool continuar = true;

                do
                {
                    Console.Write("Selecione uma opção:\n");
                    Console.WriteLine("1. Registro");
                    Console.WriteLine("2. Mostrar");
                    Console.WriteLine("3. Atendimento");
                    Console.WriteLine("4. Sair");

                    int opcao;
                    if (int.TryParse(Console.ReadLine(), out opcao))
                    {
                        switch (opcao)
                        {
                            case 1:
                                Console.WriteLine("Registro:");
                                for (int i = 0; i < clientes.Length; i++)
                                {
                                    Console.Write("Digite o nome do cliente {i + 1}: ");
                                    string nome = Console.ReadLine();
                                    Console.Write("Digite a prioridade do cliente {i + 1} (true/false): ");
                                    bool? prioridade = ParseBool(Console.ReadLine());
                                    clientes[i].Cadastrar(nome, prioridade);
                                }
                                arrumarprio(clientes);
                                break;
                            case 2:
                                Console.WriteLine("Clientes registrados:");
                                foreach (var cliente in clientes)
                                {
                                    Console.WriteLine("Nome: {cliente.Nome}, Prioridade: {cliente.Prioridade}");
                                }
                                break;
                            case 3:
                                Console.WriteLine("Atendimento:");

                                break;
                            case 4:
                                continuar = false;
                                break;
                            default:
                                Console.WriteLine("Opção incorreta.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida.");
                    }

                } while (continuar);
            }

            static void arrumarprio(Cliente[] clientes)
            {
                for (int i = 0; i < clientes.Length - 1; i++)
                {
                    if (clientes[i].Prioridade == false && clientes[i + 1].Prioridade == true)
                    {
                        Cliente clienteAux = clientes[i];
                        clientes[i] = clientes[i + 1];
                        clientes[i + 1] = clienteAux;
                    }
                }
            }

            static bool? ParseBool(string input)
            {
                if (bool.TryParse(input, out bool result))
                {
                    return result;
                }
                return null; // Return null if the input is not a valid boolean
            }

            public class Cliente
            {
                public string Nome { get; set; }
                public bool? Prioridade { get; set; }

                public void Cadastrar(string nome, bool? prioridade)
                {
                    Nome = nome;
                    Prioridade = prioridade;
                }
            }
        }
    }
    

