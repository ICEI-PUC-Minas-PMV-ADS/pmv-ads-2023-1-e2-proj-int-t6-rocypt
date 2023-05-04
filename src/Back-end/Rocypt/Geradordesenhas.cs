using system;

namespace GeradorDeSenhas {

    class Program {

    static void Main(string[] args) {
        
        int qtd = 10;
        
        string caracterespossiveis = 
        "ABCDEFGHIJKLMNOPQRSTUVWXYZÇ" +
        "ABCDEFGHIJKLMNOPQRSTUVWXYZÇ".ToLower +
        "0123456789" +
        "%$#@!";

        Random sorteio = new Random();
        int numeroSorteado = 0;
        StringBuilder password = new StringBuilder();

        for(int t = 0; t < qtd; t++){
        numeroSorteado = sorteio.Next(0, caracterespossiveis.Length - 1);
        // Next é um método de sorteio, nesse caso, é um sorteio entre o índice 0 e carac... -1
        password.Append(caracterespossiveis[numeroSorteado]);
        }

        Console.Write(password);
        Console.ReadKey();
    }


    }





}