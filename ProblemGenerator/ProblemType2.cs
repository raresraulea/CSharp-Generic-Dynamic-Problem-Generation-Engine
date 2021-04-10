using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemGenerator
{
    class ProblemType2
    {
        public static Random random = new Random();
        public CustomPropertyRangeAsList A { get; set; } = new CustomPropertyRangeAsList();

        public CustomProperty B { get; set; } = new CustomProperty(3, 9);
        public CustomProperty C { get; set; } = new CustomProperty(1, 4);
        public CustomProperty D { get; set; } = new CustomProperty(2, 6);
        public string ProblemText { get; set; } = "Subprogramul {0} este definit alaturat. Indicati apelul in urma caruia simbolul * se afiseaza de {3} ori. \n" +
                "void {0} (int x){{\n" +
                "  cout << \"*\"; \n" +
                "  if (x > {1}) {0} ((x +{2}) / 2); \n" +
                "}};";

        public ProblemType2()
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
