using System;

namespace gerAcademic.Cons
{
    class Program
    {
        static void Main(string[] args)
        {
            double nota1, nota2, nota3, nota4, nota5;
            double mPnd, tRec, provaEspecial;

            nota1 = 10;
            nota2 = 10;
            nota3 = 10;
            nota4 = 10;
            nota5 = 10;

            mPnd = mediaPonderada(nota1, nota2, nota3);
            Console.WriteLine(mPnd + " media ponderada testada\n");

            tRec = testeRecuperacao(mediaPonderada(nota1, nota2, nota3), nota4);
            Console.WriteLine(tRec + " teste de recuperacao testado\n");

            provaEspecial = mediaPonderadaFinal(nota1, nota2, nota3, nota4, nota5);
            Console.WriteLine(provaEspecial + " prova especial testada\n");

            System.Console.WriteLine(verificaAprovacao(5) + " status aluno testado\n");

            System.Console.WriteLine(verificaAprovacao2(5) + " status recuperacao testado\n");

            System.Console.WriteLine("Gerando Notas");
            System.Console.WriteLine(fazerProva());
            System.Console.WriteLine(fazerProva());
            System.Console.WriteLine(fazerProva());
            System.Console.WriteLine(fazerProva());


        }

        static double mediaPonderada(double nota1, double nota2, double nota3)
        {
            double peso1, peso2, peso3;
            peso1 = 100; peso2 = 120; peso3 = 140;

            return Math.Round(((nota1 * peso1) + (nota2 * peso2) + (nota3 * peso3))
                / (peso1 + peso2 + peso3), 1);
        }

        static string verificaAprovacao(double mPnd) // verifica status do aluno 
        {
            if (mPnd < 6)
            {
                if (mPnd > 4)
                {
                    return "Recuperacao";
                }
                return "Reprovado";
            }

            return "Aprovado";
        }

        static double testeRecuperacao(double mPnd, double nota4) // com nota da prova final (nota4)
        {

            return Math.Round((mPnd + nota4) / 2, 1);
        }

        static string verificaAprovacao2(double tRec)
        {
            if (tRec < 5)
            {
                return "Reprovado";
            }

            return "Aprovado";
        }

        static double mediaPonderadaFinal(double nota1, double nota2, double nota3,
            double nota4, double nota5) // com nota da prova especial (nota5)
        {
            double peso1, peso2, mtNotas;
            peso1 = 140; peso2 = 160;
            if (nota4 == 0) { nota4 = 10; }
            mtNotas = (nota1 + nota2 + nota3 + nota4) / 4;

            return Math.Round(((mtNotas * peso1) + (nota5 * peso2)) / (peso1 + peso2), 1);
        }

        static double fazerProva()
        {
            // simulando notas
            Random resultado = new Random();
            double nota;
            nota = resultado.Next(0, 11) + Math.Round(resultado.NextDouble(), 1);
            if (nota < 10) { return nota; }

            return 10;
        }

    }
}
