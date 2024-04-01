namespace JogoAdivinhacao.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int numAleatorio, numChutado, i, pontos, dificuldade;
                IniciaVariaveis(out numAleatorio, out i, out pontos, out dificuldade);
                numChutado = RecebeTentativas(numAleatorio, ref i, ref pontos, dificuldade);

                if (numChutado == numAleatorio) Console.WriteLine($"Você ganhou! :) Sua pontuação é {pontos} pontos");
                else Console.WriteLine("Você perdeu :(");

                if (DeveContinuar()) break;
            }
        }
        static void IniciaVariaveis(out int numAleatorio, out int i, out int pontos, out int dificuldade)
        {
            Console.Clear();
            Random objAleatorio = new Random();
            numAleatorio = objAleatorio.Next(20);
            i = 0;
            pontos = 1000;
            dificuldade = EscolheDificuldade();
        }
        static int RecebeTentativas(int numAleatorio, ref int i, ref int pontos, int dificuldade)
        {
            int numChutado;
            do
            {
                Console.Write($"Tentativa {i + 1}: ");
                numChutado = Convert.ToInt32(Console.ReadLine());
                pontos = pontos - Math.Abs((numChutado - numAleatorio) / 2);
                i++;

                MaiorOUmenor(numAleatorio, numChutado);
            }
            while (numChutado != numAleatorio && i < 20 - 5 * dificuldade);

            return numChutado;
        }
        static void MaiorOUmenor(int numAleatorio, int numChutado)
        {
            if (numChutado > numAleatorio) Console.WriteLine("Seu chute foi maior que o número secreto!\n");
            if (numChutado < numAleatorio) Console.WriteLine("Seu chute foi menor que o número secreto!\n");
        }
        static int EscolheDificuldade()
        {
            Console.WriteLine("JOGO DE ADIVINHAÇÃO\nEscolha o nível de dificuldade:\n\n 1. Fácil\t 2. Médio\t 3. Difícil\n");
            int dificuldade = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"\nÓtimo. Você tem {20 - 5 * dificuldade} tentativas\n");

            return dificuldade;
        }
        static bool DeveContinuar()
        {
            Console.WriteLine("\nDeseja repetir? [S,N]");
            string continuar = Console.ReadLine();

            return continuar == "n" || continuar == "N";
        }
    }
}
