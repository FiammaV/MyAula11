using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula11 {
    class Program {
        static void Main(string[] args) {

            Guarda3<float> g3f = new Guarda3<float>() { 3.5f, 28, -1.5f };
            Guarda3<string> g3s = new Guarda3<string>() { "hello", "bye", "lala" };

            foreach (string s in g3s) {
                Console.WriteLine(s);
            }

            foreach (float f in g3f) {
                Console.WriteLine(f);
            }

            Console.WriteLine(g3s.GetItem(1));
        }
    }
}
