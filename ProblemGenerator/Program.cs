using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemGenerator
{
    class Program
    {
        static void Main(string[] args)
        {

            List<ProblemType2> PType2 = GeneratorEngine.GenerateNProblems<ProblemType2>(5);
            List<ProblemType3> PType3 = GeneratorEngine.GenerateNProblems<ProblemType3>(5);
            PType2.ForEach(p => Console.WriteLine(p.ProblemText));
            PType3.ForEach(p => Console.WriteLine(p.ProblemText));
            Console.ReadLine();
        }
    }
}
