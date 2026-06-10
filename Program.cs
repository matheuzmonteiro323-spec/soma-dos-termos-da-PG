using System;

class Program
{
    static void Main()
    {
        int a1 = 2;
        int q = 3;
        int n = 6;

        int resultadoAn = CalcularTermoGeralPG(a1, q, n);
        Console.WriteLine("O 6° termo da PG é: " + resultadoAn);

        int somaDosTermos = CalcularSomaPG(a1, q, n);
        Console.WriteLine("A soma dos termos é: " + somaDosTermos);
    }
    static int CalcularTermoGeralPG(int a1, int q, int n)
    {
        int expoente = n - 1;

        int potencia = (int)Math.Pow(q, expoente);

        int termoGeral = a1 * potencia;

        return termoGeral;
    }
    static int CalcularSomaPG(int a1, int q, int n)
    {
        int expoente = n;
        int potencia = (int)Math.Pow(q, expoente);
        int denominador = q - 1;

        int somaDosTermos = a1 * (potencia - 1) / denominador;

        if (q == 1) return a1 * n;

        return a1 * ((int)Math.Pow(q, n) - 1) / (q - 1);
    }
}