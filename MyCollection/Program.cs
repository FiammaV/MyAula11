using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula11 {
    class Program {
        static void Main(string[] args) {

            Guarda3<string> g3s = new Guarda3<string>();
            Guarda3<float> g3f = new Guarda3<float>();

            g3s.SetItem(1, "hello");
            g3s.SetItem(2, "bye");
            g3s.SetItem(3, "lala");

            g3f.SetItem(1, 2.3f);
            g3f.SetItem(2, 5.7f);
            g3f.SetItem(3, -4);

            Console.WriteLine(g3s.GetItem(1));
        }
    }
}
