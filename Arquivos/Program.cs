using System;
using System.IO;
using System.Globalization;
using Arquivos.Entities;

namespace Arquivos
{
    class Program
    {
        static void Main(string[] args)
        {
            string caminhoOrigem;

            Console.Write("Informe o caminho completo: ");
            caminhoOrigem = Console.ReadLine();

            try
            {
                string pastaOrigem;
                string pastaDestino;
                string arquivoDestino;

                string[] lines = File.ReadAllLines(caminhoOrigem); //ler as linhas do arquivo que se encontra nessa pasta e salvar na matriz

                pastaOrigem = Path.GetDirectoryName(caminhoOrigem); //Pega o caminho do arquivo informado
                pastaDestino = pastaOrigem + @"\out"; //Pega o caminho de origem e concatena com \out em uma string
                arquivoDestino = pastaDestino + @"\summary.csv"; //concatena o caminho com o nome do arquivo

                Directory.CreateDirectory(pastaDestino); //cria o diretório com base na string acima

                using (StreamWriter sw = File.AppendText(arquivoDestino))//chamada do método para escrever em um arquivo
                {
                    foreach (string line in lines) //para cada linha na matriz faça
                    {
                        string[] fields = line.Split(", "); //criada uma nova matriz fields para armazenar os dados do novo arquivo
                        string nome = fields[0]; //colocando cada dado em uma posição dentro da matriz fields
                        double preco = double.Parse(fields[1], CultureInfo.InvariantCulture);
                        int qtd = int.Parse(fields[2]);

                        Produtos prod = new Produtos(nome, preco, qtd); //instanciando um novo produto com os dados capturados do arquivo

                        sw.WriteLine(prod.Nome + ", " + prod.Total().ToString("F2", CultureInfo.InvariantCulture)); //escrevendo novo arquivo com os dados capturados e instanciados e realizando o cálculo da quantidade
                    }
                }

                Console.WriteLine("Processo Finalizado com sucesso!");
                
            }
            catch (IOException e)
            {
                Console.WriteLine("Ocorreu um erro: ");
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
