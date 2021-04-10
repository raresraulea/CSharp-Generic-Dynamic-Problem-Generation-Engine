using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ProblemGenerator
{
    public static class GeneratorEngine
    {
        static Random random = new Random();
        public static T GenerateProblem<T>() where T : class, new()
        {
            T ProblemObj = new T();
            List<string> GeneratedValues = new List<string>();

            foreach (var prop in typeof(T).GetProperties())
            {
                if (prop.PropertyType.Name == "CustomProperty")
                {
                    // => Am gasit un CustomProperty cu cei 3 membri: MinValue, MaxValue, Value (in aceasta ordine)
                    HandleCustomProperty(ProblemObj, GeneratedValues, prop);
                }
                else if (prop.PropertyType.Name == "CustomPropertyRangeAsList")
                {
                    HandleCustomPropertyRangeAsList(ProblemObj, GeneratedValues, prop);
                }
            }

            Type ProblemType = ProblemObj.GetType();
            PropertyInfo ProblemTextProperty = ProblemType.GetProperty("ProblemText");
            string ProblemText = (string)ProblemTextProperty.GetValue(ProblemObj);
            string FormattedString = String.Format(ProblemText, GeneratedValues.ToArray());
            ProblemTextProperty.SetValue(ProblemObj, FormattedString);

            return ProblemObj;
        }
        private static void HandleCustomProperty<T>(T ProblemObj, List<string> GeneratedValues, PropertyInfo prop) where T : class, new()
        {
            //Aduc din PropertyInfo obiectul CustomProperty curent
            CustomProperty CustomPropertyObj = (CustomProperty)prop.GetValue(ProblemObj);

            //Extrag tipul obiectului pentru care vrea sa extrag valorile proprietatilor
            Type type = CustomPropertyObj.GetType();

            //Obtin cele 3 proprietati pe care le au obiectele de tip CustomProperty
            PropertyInfo CurrentMinValue = type.GetProperty("MinValue");
            PropertyInfo CurrentMaxValue = type.GetProperty("MaxValue");
            PropertyInfo CurrentValue = type.GetProperty("Value");

            //Extrag valorile proprietatilor MinValue si MaxValue ale obicetului CustomPropertyObj
            int MinValue = (int)CurrentMinValue.GetValue(CustomPropertyObj);
            int MaxValue = (int)CurrentMaxValue.GetValue(CustomPropertyObj);

            //Generez valoarea in range-ul obtinut [MinValue, MaxValue]
            int WantedRandomValue = random.Next(MinValue, MaxValue);
            GeneratedValues.Add(WantedRandomValue.ToString());

            //Setez valoarea proprietatii curente
            CurrentValue.SetValue(CustomPropertyObj, WantedRandomValue.ToString());
        }

        private static void HandleCustomPropertyRangeAsList<T>(T ProblemObj, List<string> GeneratedValues, PropertyInfo prop) where T : class, new()
        {
            CustomPropertyRangeAsList CustomPropertyObj = (CustomPropertyRangeAsList)prop.GetValue(ProblemObj);
            Type type = CustomPropertyObj.GetType();
            PropertyInfo CurrentValue = type.GetProperty("ChosenValue");
            PropertyInfo ValuesListProperty = type.GetProperty("Values");
            List<string> ValuesList = (List<string>)ValuesListProperty.GetValue(CustomPropertyObj);
            int MaxValue = ValuesList.Count();
            int GeneratedRandomValue = random.Next(MaxValue);
            GeneratedValues.Add(ValuesList[GeneratedRandomValue].ToString());
            CurrentValue.SetValue(CustomPropertyObj, ValuesList[GeneratedRandomValue].ToString());
        }

        public static List<T> GenerateNProblems<T>(int N) where T:class, new()
        {
            List<T> problems = new List<T>();
            for (int i = 0; i < N; i++)
            {
                problems.Add(GenerateProblem<T>());
            }
            return problems;
        }
    }
}
