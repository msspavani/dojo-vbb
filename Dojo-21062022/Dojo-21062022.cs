namespace Dojo_21062022
{
    public  class DojoExe01
    {
        public static DojoExe01 CriarNovoDojo()
        {
            return new DojoExe01();
        }
        private DojoExe01()
        {

        }

        internal void SolucaoVersao01()
        {

            (int[], int) numerosDesafio = BuscarNumerosDoDesafioNoPrompt();


            List<(int, int)> resultado = CalcularResultado(numerosDesafio.Item2, numerosDesafio.Item1);

            if (resultado.Any())
            {
                Console.WriteLine("Numeros Encontrados : ");
                resultado.ForEach(x => Console.WriteLine(x));

            }
            else
                Console.Write("Nao houve resultado para o valor procurado");
        }

        private int[] ExtrairArrayDaColecaoDoUsuario(List<int> numerosDaColecao)
        {
            int[] numerosNoArray = new int[numerosDaColecao.Count];
            numerosDaColecao.CopyTo(numerosNoArray);
            return numerosNoArray;
            
        }

        private int BuscarNumeroAlvo()
        {
            bool ehNumero;
            int numeroAlvo;

            do
            {

                Console.WriteLine("Digite o numero para buscar a soma : (0 para Sair)");
                ehNumero = int.TryParse(Console.ReadLine(), out numeroAlvo);


                if (!ehNumero)
                    Console.WriteLine("Numero Invalido - tente novamente");

            } while (!ehNumero && numeroAlvo > 0);

            return numeroAlvo;
        }

        public List<(int, int)> CalcularResultado(int numeroAlvo, int[] numerosNoArray)
        {
            // busca sequencial ?

            List<(int, int)> resultado = new List<(int, int)>();

            for (int i = 0; i < numerosNoArray.Length - 1; i++)
            {
                for (int j = i+1; j < numerosNoArray.Length; j++)
                {
                    if (numerosNoArray[i] + numerosNoArray[j] == numeroAlvo)
                        resultado.Add((i, j));
                }
            }

            return resultado;

        }

        private  List<int> LerNumerosDoArrayNoPrompt()
        {


            List<int> listaDeNumerosDigitados = new List<int>();
            bool ehNumero;
            int novoNumeroNoArray;
           
            Console.WriteLine("Digite os numeros para a coleção : (-1 Sair)");

            do
            {
                ehNumero = int.TryParse(Console.ReadLine(), out novoNumeroNoArray);

                if (ehNumero)
                {
                    listaDeNumerosDigitados.Add(novoNumeroNoArray);
                }
                else
                {
                    Console.WriteLine("Numero Invalido - tente novamente");
                    Console.ReadKey();

                }



            } while (novoNumeroNoArray > 0);


            return listaDeNumerosDigitados;
        }

        private (int[], int) BuscarNumerosDoDesafioNoPrompt()
        {
            List<int> numerosDaColecao = LerNumerosDoArrayNoPrompt();
            int numeroAlvo = BuscarNumeroAlvo();
            int[] numerosNoArray = ExtrairArrayDaColecaoDoUsuario(numerosDaColecao);

            return (numerosNoArray, numeroAlvo);

        }

    }
}
