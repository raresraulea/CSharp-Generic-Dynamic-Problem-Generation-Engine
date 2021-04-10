using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemGenerator
{
    class ProblemType3
    {
        public static Random random = new Random();
        public CustomPropertyRangeAsList A { get; set; } = new CustomPropertyRangeAsList();

        public CustomProperty B { get; set; } = new CustomProperty(30, 90);
        public CustomProperty C { get; set; } = new CustomProperty(10, 40);
        public CustomProperty D { get; set; } = new CustomProperty(20, 60);
        public CustomProperty E { get; set; } = new CustomProperty(100,210);
        public string ProblemText { get; set; } = "Ce afiseaza frunctia {0} definita mai jos, daca se apeleaza cu x = {3}? \n" +
                "void {0} (int x){{\n" +
                "  cout << \"*\"; \n" +
                "  if (x > {1} && x < {2}) {0} ((x +{4}) / 2); \n" +
                "}};";

        public ProblemType3()
        {
        }
    }
}
