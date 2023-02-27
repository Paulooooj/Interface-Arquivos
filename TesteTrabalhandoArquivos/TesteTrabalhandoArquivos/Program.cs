using TesteTrabalhandoArquivos.Entities;
using System.Globalization;
namespace TesteTrabalhandoArquivos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Informe o diretório do arquivo: ");
            string diretorioDocumento = Console.ReadLine();

            try
            {
                string[] linhas = File.ReadAllLines(diretorioDocumento);

                string receberDiretorio = Path.GetDirectoryName(diretorioDocumento);
                string diretorioPasta = receberDiretorio + @"\Pasta Teste";
                string diretorioArquivo = diretorioPasta + @"\summary.csv";

                Directory.CreateDirectory(diretorioPasta);

                using (StreamWriter sw = File.AppendText(diretorioArquivo))
                {
                    foreach (string linha in linhas)
                    {
                        string[] campos = linha.Split(',');
                        string nome = campos[0];
                        double preco = double.Parse(campos[1]);
                        int quantidade = int.Parse(campos[2]);

                        Produto produto = new Produto(nome, preco, quantidade);

                        sw.WriteLine(produto.Nome + ", " + produto.Total().ToString("F2", CultureInfo.InvariantCulture));
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Ocorreu um Erro!!");
                Console.WriteLine(e.Message);
            }
        }
    }
}