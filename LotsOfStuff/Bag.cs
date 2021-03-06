﻿using System;
using System.Collections.Generic;

namespace Aula11 {
    /// <summary>
    /// Classe que representa uma mochila ou saco que contem itens
    /// </summary>
    public class Bag : List<IStuff>, IStuff, IHasKarma {

        /// <summary> 
        /// Propriedade Weight respeita o contrato com IHasWeight. No caso do
        /// Bag o peso vai corresponder ao peso total dos itens.
        /// </summary>
        public float Weight {
            get {
                float totalWeight = 0;
                foreach (IStuff aThing in this) {
                    totalWeight += aThing.Weight;
                }
                return totalWeight;
            }
        }

        /// <summary> 
        /// Propriedade Value respeita o contrato com IValuable. No caso do
        /// Bag o valor vai corresponder ao valor total dos itens.
        /// </summary>
        public float Value {
            get {
                float totalValue = 0;
                foreach (IStuff aThing in this) {
                    totalValue += aThing.Value;
                }
                return totalValue;
            }
        }

        public float Karma {
            get {
                int numeroCenasComKarma = 0;
                float total = 0;
                foreach (IStuff cena in this) {
                    if (cena is IHasKarma) {
                        total += (cena as IHasKarma).Karma;
                        numeroCenasComKarma++;
                    }
                }
                return total / numeroCenasComKarma;
            }
        }

        public bool ContainsItemsOfType<T>() where T : IStuff {
            foreach (IStuff cena in this) {
                if (cena is T) {
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<T> GetItemsOfType<T>() where T : class, IStuff {
            List<T> lst = new List<T>();

            foreach (IStuff cena in this) {
                if (cena is T) {
                    lst.Add(cena as T);
                }
            }
            return lst;
        }

        public IEnumerable<T> BetterGetItemsOfType<T>() where T : IStuff {
            foreach (IStuff cena in this) {
                if (cena is T) {
                    yield return (T)cena;
                }
            }
        }

        public void GetHeavier1(out Food food, out Gun gun) {
            food = null;
            gun = null;

            foreach (IStuff s in this) {
                if (s is Food) {
                    if ((food == null) || (s.Weight > food.Weight)) {
                        food = s as Food;
                    }
                } else if(s is Gun) {
                    if ((gun == null) || (s.Weight > gun.Weight)) {
                        gun = s as Gun;
                    }
                }
            }
        }

        public Tuple<Food, Gun> GetHeavier2() {
            Food food = null;
            Gun gun = null;

            foreach (IStuff s in this) {
                if (s is Food) {
                    if ((food == null) || (s.Weight > food.Weight)) {
                        food = s as Food;
                    }
                }
                else if (s is Gun) {
                    if ((gun == null) || (s.Weight > gun.Weight)) {
                        gun = s as Gun;
                    }
                }
            }
            return new Tuple<Food, Gun>(food, gun);
        }

        public IEnumerable<string> GetStrings() {
            foreach (IStuff s in this) {
                yield return s.ToString();
            }
        }

        /// <summary>
        /// Construtor que cria uma nova instância de mochila
        /// </summary>
        /// <param name="bagSize">
        /// Número máximo de itens que é possível colocar na mochila
        /// </param>
        public Bag(int bagSize) : base(bagSize) {

        }

        /// <summary>
        /// Sobreposição do método ToString() para a classe Bag.
        /// </summary>
        /// <returns>
        /// Uma string contendo informação sobre a mochila e os seus conteúdos.
        /// </returns>
        public override string ToString() {
            return $"Mochila com {Count} itens e um peso e valor " +
                $"totais de {Weight:f2} Kg e {Value:c}, respetivamente";
        }
    }
}
