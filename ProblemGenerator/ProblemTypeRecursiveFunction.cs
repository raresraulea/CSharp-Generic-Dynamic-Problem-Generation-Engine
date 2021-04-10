using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemGenerator
{
    class ProblemTypeRecursiveFunction
    {
        public static Random random = new Random();
        public string A { get; set; }
        public List<string> aValues { get; set; } = new List<string>(){ "f", "g", "h" };
        public string ProblemText { get; set; }

        public CustomProperty B { get; set; } = new CustomProperty(3, 8);
        public CustomProperty C { get; set; } = new CustomProperty(1, 3);
        public CustomProperty D { get; set; } = new CustomProperty(2, 5);

        public ProblemTypeRecursiveFunction()
        {
            this.ProblemText =
                "Subprogramul {0} este definit alaturat. Indicati apelul in urma caruia simbolul * se afiseaza de {3} ori. \n" +
                "void {0} (int x){{\n" +
                "  cout << \"*\"; \n" +
                "  if (x > {1}) {0} ((x +{2}) / 2); \n" +
                "}};";
        }

    }
}
