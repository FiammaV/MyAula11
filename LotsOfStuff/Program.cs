using System;

namespace Aula11 {
    /// <summary>Programa para testar o projeto</summary>
    public class Program {
        /// <summary>O programa começa aqui no Main</summary>
        /// <param name="args">
        /// Argumentos de linha de comandos (são ignorados neste programa)
        /// </param>
        public static void Main(string[] args) {
            // Criar uma nova instância de Program e
            // invocar o método TestProjet na instância criada
            Program prog = new Program();
            prog.TestProject();

            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }

        /// <summary>Método que testa este projeto</summary>
        private void TestProject() {
            // Instanciar um jogador com 70 quilos
            Player p = new Player(70.0f);

            Console.WriteLine("Antes" + " " + p.ToString());

            Bag otherBag = new Bag(5);

            otherBag.Add(new Food(FoodType.Meat, 1, 1.0f));
            otherBag.Add(new Food(FoodType.Vegetables, 2, 1.5f));
            p.BagOfStuff.Add(otherBag);

            //
            // Adicionar vários itens à mochila do jogador:
            //

            // Pão com 2 dias, 500 gramas
            p.BagOfStuff.Add(new Food(FoodType.Bread, 2, 0.500f));
            // 300 gramas de vegetais com 5 dias
            p.BagOfStuff.Add(new Food(FoodType.Vegetables, 5, 0.300f));
            // Pistola com 1.5kg + 50 gramas por bala, carregada com 10 balas,
            // com um custo de 250€
            p.BagOfStuff.Add(new Gun(1.5f, 0.050f, 10, 250f));
            // 200 gramas de fruta fresca
            p.BagOfStuff.Add(new Food(FoodType.Fruit, 0, 0.200f));
            // Mais uma arma
            p.BagOfStuff.Add(new Gun(2f, 0.09f, 25, 325f));

            // Mostrar informação acerca dos conteúdos da mochila
            Console.WriteLine(p.BagOfStuff);

            // Percorrer itens na mochila e tentar "imprimir" cada um
            foreach (IStuff aThing in p.BagOfStuff) {
                Console.WriteLine($"\t=> {aThing}");

                // Se item atual for uma arma, disparar a mesma
                if (aThing is Gun) {
                    (aThing as Gun).Shoot();
                }
            }

            // Mostrar de novo informação sobre a mochila
            Console.WriteLine();
            Console.WriteLine(p.BagOfStuff);
            Console.WriteLine(otherBag);

            Console.WriteLine("Depois" + " " + p.ToString());

            Console.WriteLine();
            Console.WriteLine("Mochila player contem guns?" + " "
                + p.BagOfStuff.ContainsItemsOfType<Gun>());
            Console.WriteLine("Mochila player contem food?" + " "
                + p.BagOfStuff.ContainsItemsOfType<Food>());
            Console.WriteLine("Mochila player contem bags?" + " "
                + p.BagOfStuff.ContainsItemsOfType<Bag>());

            Console.WriteLine();

            Console.WriteLine("Mochila extra contem guns?" + " "
               + otherBag.ContainsItemsOfType<Gun>());
            Console.WriteLine("Mochila extra contem food?" + " "
                + otherBag.ContainsItemsOfType<Food>());
            Console.WriteLine("Mochila extra contem bags?" + " "
                + otherBag.ContainsItemsOfType<Bag>());
            Console.WriteLine();

            foreach(Food f in p.BagOfStuff.GetItemsOfType<Food>()) { //IEnumerable<Food>
                Console.WriteLine(f);
            }

            foreach(Gun f in p.BagOfStuff.BetterGetItemsOfType<Gun>()) { //IEnumerable<Gun>
                Console.WriteLine(f);
            }
        }
    }
}
