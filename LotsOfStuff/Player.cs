namespace Aula11 {
    /// <summary>Esta classe representa um jogador num jogo</summary>
    public class Player : IHasWeight {

        /// <summary>
        /// Máximo de items na mochila (variável de classe, constante,
        /// Máximo de items na mochila (variável de classe, constante,
        /// implicitamente static)
        /// </summary>
        private const int maxBagItems = 10;

        /// <summary>
        /// Peso base do jogador (variável de instância, read-only)
        /// </summary>
        private readonly float baseWeight;

        /// <summary>
        /// Mochila de itens do jogador (variável de instância)
        /// </summary>
        public Bag BagOfStuff { get; }

        /// <summary>
        /// Propriedade Weight respeita o contrato com IHasWeight
        /// </summary>
        public float Weight {
            get {
                // peso base + peso do saco
                return baseWeight + BagOfStuff.Weight;
            }
        }

        /// <summary>Construtor, cria nova instância de jogador</summary>
        /// <param name="baseWeight">Peso base do jogador</param>
        public Player(float baseWeight) {
            this.baseWeight = baseWeight;
            BagOfStuff = new Bag(maxBagItems);
        }
        public override string ToString() {
            return $"O peso total é {BagOfStuff.Weight}, tem {BagOfStuff.Count} itens" + " " +
                $"e a percentagem do peso total é {BagOfStuff.Weight / Weight}";
        }
    }
}
