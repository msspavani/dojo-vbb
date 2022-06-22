using Dojo_21062022;
using FluentAssertions;

namespace Dojo_Test
{
    public class UnitTest1
    {

        private readonly DojoExe01 dojo;

        
        public UnitTest1()
        {
            dojo = DojoExe01.CriarNovoDojo();
        }


        [Theory]
        [InlineData(new int[] { 1, 3, 8, 5, 6 }, 14)]
        [InlineData(new int[] { 1, 3, 8, 5, 6 }, 7)]
        [InlineData(new int[] { 1, 2, 8, 5, 6 }, 11)]
        [InlineData(new int[] { 1, 3, 8, 5, 6 }, 4)]
        [InlineData(new int[] { 2, 3, 8, 5, 6 }, 9)]
        [InlineData(new int[] { 1, 3, 8, 5, 6 }, 13)]

        public void AoCalcularResultado_DeveRetornarUmaPosicao(int[] colecao, int numeroAlvo )
        {
            List<(int, int)> resultado; 

            resultado = dojo.CalcularResultado(numeroAlvo, colecao);

            resultado.Should().NotBeEmpty()
                     .And.HaveCount(1);

            resultado.Should().ContainSingle();
        }


        [Theory]
        [InlineData(new int[] { 1, 3, 8, 5, 6, 9 }, 14)]
        [InlineData(new int[] { 2, 1, 8, 5, 6 }, 7)]
        [InlineData(new int[] { 1, 3, 8, 5, 6 }, 11)]
        [InlineData(new int[] { 1, 3, 8, 5, 6, 0, 4 }, 4)]
        [InlineData(new int[] { 1, 3, 8, 5, 6 }, 9)]
        [InlineData(new int[] { 1, 3, 8, 5, 6, 7 }, 13)]

        public void AoCalcularResultado_DeveRetornarDuasPosicao(int[] colecao, int numeroAlvo)
        {
            List<(int, int)> resultado;

            resultado = dojo.CalcularResultado(numeroAlvo, colecao);

            resultado.Should().NotBeEmpty()
                     .And.HaveCount(2);

            resultado.Should().OnlyContain(x => x.Item1 != x.Item2);
            
        }


        [Theory]
        [InlineData(new int[] { 1, 3, 1, 3 }, 4)]
        [InlineData(new int[] { 2, 1, 1, 2 }, 3)]
        [InlineData(new int[] { 1, 5, 5, 1 }, 6)]
        [InlineData(new int[] { 1, 8, 8, 1 }, 9)]
        [InlineData(new int[] { 5, 6, 6, 5 }, 11)]
        [InlineData(new int[] { 1, 7, 1, 7 }, 8)]

        public void AoCalcularResultado_NaoDeveRepetirPosicoesInversas(int[] colecao, int numeroAlvo)
        {
            List<(int, int)> resultado;

            resultado = dojo.CalcularResultado(numeroAlvo, colecao);

            resultado.Should().NotBeEmpty()
                     .And.HaveCount(4); 

            resultado.Should().NotContain(x => x.Item1 == x.Item2);

        }

    }
}