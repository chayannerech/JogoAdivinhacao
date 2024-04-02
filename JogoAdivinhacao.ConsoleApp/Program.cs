namespace JogoAdivinhacao.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] historico = new string[100];
            int j = 0;
            DateTime thisDay = DateTime.Now;
            
            while (true)
            {
                int numAleatorio, numChutado, i, pontos, dificuldade;
                IniciaVariaveis(out numAleatorio, out i, j, out pontos, out dificuldade, ref historico);
                
                numChutado = RecebeTentativas(numAleatorio, ref i, ref pontos, dificuldade);
                Resultado(numChutado, numAleatorio, ref historico, j, pontos, thisDay);

                if (!DeveContinuar("\nDeseja visualizar o histórico? [S,N]")) MostrarHistorico(historico, j);
                if (DeveContinuar("\nDeseja repetir? [S,N]")) break;
                j++;
            }
        }
        static void IniciaVariaveis(out int numAleatorio, out int i, int j, out int pontos, out int dificuldade, ref string[] historico)
        {
            Console.Clear();
            Random objAleatorio = new Random();
            numAleatorio = objAleatorio.Next(20);
            i = 0; pontos = 1000;

            Console.Write("            JOGO DE ADIVINHAÇÃO           \n---------------------------------------------\ntente adivinhar o número secreto entre 0 e 20\n---------------------------------------------\n\nInforme o seu nome: ");
            historico[j] = Console.ReadLine();
            dificuldade = EscolheDificuldade();
        }
        static int EscolheDificuldade()
        {
            Console.Clear();
            Console.WriteLine("            JOGO DE ADIVINHAÇÃO           \n---------------------------------------------\ntente adivinhar o número secreto entre 0 e 20\n---------------------------------------------\n       Escolha o nível de dificuldade:\n\n 1. Fácil\t 2. Médio\t 3. Difícil\n");
            int dificuldade = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"\nÓtimo. Você tem {20 - 5 * dificuldade} tentativas\n");

            return dificuldade;
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
        static void Resultado(int numChutado, int numAleatorio, ref string[] historico, int j, int pontos, DateTime thisDay)
        {
            if (numChutado == numAleatorio) Console.WriteLine($"\n---------------------------------------------\nVocê ganhou!! :) Sua pontuação é {pontos} pontos\n---------------------------------------------");
            else Console.WriteLine("Você perdeu :(");

            historico[j] = historico[j] + $" -> {pontos} ({thisDay.ToString("g")})";
        }
        static void MaiorOUmenor(int numAleatorio, int numChutado)
        {
            if (numChutado > numAleatorio) Console.WriteLine("Seu chute foi maior que o número secreto!\n");
            if (numChutado < numAleatorio) Console.WriteLine("Seu chute foi menor que o número secreto!\n");
        }
        static bool DeveContinuar(string texto)
        {
            Console.WriteLine(texto);
            string continuar = Console.ReadLine();

            return continuar == "n" || continuar == "N";
        }
        static void MostrarHistorico(string[] historico, int j)
        {
            Console.WriteLine($"\n\n---------------------------------------------\n                HISTÓRICO");

            for (int k = 0; k <= j; k++) Console.WriteLine(historico[k]);

            Console.WriteLine($"---------------------------------------------\n");
        }
    }
}
