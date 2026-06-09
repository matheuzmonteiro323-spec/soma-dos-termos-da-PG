# Calculadora de Progressão Geométrica (PG) 🧮

Este projeto em C# foi desenvolvido como parte dos meus estudos de lógica de programação e backend no ecossistema .NET. O sistema calcula o termo geral de uma Progressão Geométrica (PG) e realiza o somatório de todos os termos até a posição desejada.

## 🧠 A Matemática por trás do Código

Para estruturar a lógica do software com rigor analítico, o programa aplica os fundamentos teóricos das sequências numéricas finitas.

### 1. Extrator do Termo Geral
Para encontrar qualquer termo de uma PG sem a necessidade de calcular exaustivamente todos os elementos anteriores, o programa utiliza a função matemática:

$$a_n = a_1 \cdot q^{n-1}$$

Onde:
* **a_n**: É o termo que queremos descobrir (termo geral).
* **a_1**: É o primeiro termo da sequência.
* **q**: É a razão (fator de multiplicação constante).
* **n**: É a posição do termo na sequência.

---

### 📜 Demonstração Matemática da Fórmula da Soma

A dedução matemática abaixo demonstra o fundamento lógico que valida o algoritmo de somatório utilizado no código backend. Queremos provar que a soma dos $n$ primeiros termos de uma PG finita é dada por:

$$S_n = \frac{a_1 \cdot (q^n - 1)}{q - 1}$$

#### Passo 1: Escrever a soma por extenso
Definimos a soma $S_n$ como a adição de cada termo da sequência até $n$:

$$S_n = a_1 + a_2 + a_3 + \dots + a_{n-1} + a_n$$

Substituindo cada termo pela sua respectiva definição baseada em $a_1$ e na razão $q$, temos a **Equação 1**:

$$S_n = a_1 + a_1 \cdot q + a_1 \cdot q^2 + \dots + a_1 \cdot q^{n-2} + a_1 \cdot q^{n-1} \quad \text{(Eq. 1)}$$

#### Passo 2: Multiplicar a equação pela razão $q$
Para isolarmos os termos semelhantes, multiplicamos ambos os lados da Equação 1 pela razão $q$, obtendo a **Equação 2**:

$$q \cdot S_n = q \cdot (a_1 + a_1 \cdot q + a_1 \cdot q^2 + \dots + a_1 \cdot q^{n-1})$$

$$q \cdot S_n = a_1 \cdot q + a_1 \cdot q^2 + a_1 \cdot q^3 + \dots + a_1 \cdot q^{n-1} + a_1 \cdot q^n \quad \text{(Eq. 2)}$$

#### Passo 3: Subtrair a Equação 1 da Equação 2
Agora, subtraímos membro a membro a primeira equação da segunda ($Eq. 2 - Eq. 1$):

$$q \cdot S_n - S_n = (a_1 \cdot q + a_1 \cdot q^2 + \dots + a_1 \cdot q^n) - (a_1 + a_1 \cdot q + \dots + a_1 \cdot q^{n-1})$$

Ao expandir essa subtração, ocorre um efeito telescópico onde quase todos os termos intermediários se cancelam mútua e simetricamente, reduzindo a expressão para:

$$q \cdot S_n - S_n = a_1 \cdot q^n - a_1$$

#### Passo 4: Fatoração algébrica e isolamento
Colocamos os termos em evidência (fator comum) em ambos os lados da igualdade:

$$S_n \cdot (q - 1) = a_1 \cdot (q^n - 1)$$

Por fim, isolamos o $S_n$ dividindo ambos os lados por $(q - 1)$, assumindo que $q \neq 1$:

$$S_n = \frac{a_1 \cdot (q^n - 1)}{q - 1}$$

---

## 💻 A Tradução para o C#

No arquivo `Program.cs`, a abstração dessas fórmulas foi implementada por meio de métodos estáticos puramente numéricos. Como o cálculo exige exponenciação (tanto para a potência de $n-1$ quanto para $n$), foi utilizada a classe nativa `System.Math` através do método `Math.Pow()`.

```csharp
static int CalcularTermoGeralPG(int a1, int q, int n)
{
    // an = a1 * q^(n-1)
    return a1 * (int)Math.Pow(q, n - 1);
}

static int CalcularSomaPG(int a1, int q, int n)
{
    // Tratamento de exceção matemática para evitar divisão por zero
    if (q == 1) return a1 * n; 
    
    // Sn = a1 * (q^n - 1) / (q - 1)
    return a1 * ((int)Math.Pow(q, n) - 1) / (q - 1);
}