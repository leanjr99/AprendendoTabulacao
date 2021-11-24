using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AprendendoTabulacao
{
    class Program
    {
        static void Main(string[] args)
        {
            Leitura();
        }
        public class Dados
        {
            public string funcionario { get; set; }
            public string usuarioAD { get; set; }
            public string conta { get; set; }
            public string situacao { get; set; }
            public string grupo { get; set; }
            public string setor { get; set; }
            public string unidade { get; set; }
            public string periodo { get; set; }
            public string privilegio { get; set; }
            public string acessoremoto { get; set; }
            public string assinatura { get; set; }
            public string revisaoacesso { get; set; }
            public string obs { get; set; }
        }
        public static void Leitura()
        {
            string arquivo = @"D:\Cópia de Contas de Usuários e Emails.txt";
            string Novoarquivo = @"D:\Cópia de Contas de Usuários e Emails.OUT";
            List < Dados > lista = new List<Dados>();

            using (StreamReader ler = new StreamReader(arquivo))
            {
                while (!ler.EndOfStream)
                {
                    string linha = ler.ReadLine();
                    Dados l = new Dados();
                    try
                    {
                        linha = ler.ReadLine();
                        string[] ColetarDados = linha.Split(';');
                        lista.Add(new Dados
                        {
                            funcionario = ColetarDados[0],
                            usuarioAD = ColetarDados[1],
                            conta = ColetarDados[2],
                            situacao = ColetarDados[3],
                            grupo = ColetarDados[4],
                            setor = ColetarDados[5],
                            unidade = ColetarDados[6],
                            periodo = ColetarDados[7],
                            privilegio = ColetarDados[8],
                            acessoremoto = ColetarDados[9],
                            assinatura = ColetarDados[10],
                            revisaoacesso = ColetarDados[11],
                            obs = ColetarDados[12],

                        });
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Erro");
                        throw;
                    }
                }
            }
                var ListaOrdenada = lista.OrderBy(x => x.funcionario).ToList();
                using (StreamWriter gravar = new StreamWriter(Novoarquivo))
                {
                    foreach (var obj in ListaOrdenada)
                    {
                    Console.WriteLine(string.Format("{0}|{1}|{2}|{3}|{4}",
                                                   obj.funcionario.Trim(),
                                                   obj.usuarioAD.Trim(),
                                                   obj.conta.Trim(),
                                                   obj.situacao.Trim(),
                                                   obj.setor.Trim()
                                                   )) ;
                    }
                }
            }
        }
    } 

