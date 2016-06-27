using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinamentoBenner.Core.Helpers
{
    public static class StringHelper
    {
        public static string ToPlural(this string palavra)
        {
            palavra = palavra.ToLower();

            var numeros = new ArrayList { "dois", "tres", "seis", "dez" };

            if (numeros.Contains(palavra))
                return palavra;

            var excecoes = new Dictionary<string, string>
            {
                {"mal", "males"},
                {"cônsul", "cônsules"},
                {"fel", "féis"},
                {"cal", "cais"},
                {"aval", "avais"},
                {"mol", "móis"},
                {"existe", "existem"},
                {"anão", "anões"}
            };

            if (excecoes.ContainsKey(palavra))
                return excecoes[palavra];

            if (palavra.EndsWith("al") || palavra.EndsWith("ul"))
                return palavra.Remove(palavra.Length - 1) + "is";

            if (palavra.EndsWith("z") || palavra.EndsWith("r"))
                return palavra + "es";

            if (palavra.EndsWith("m"))
                return palavra.Remove(palavra.Length - 1) + "ns";

            if (palavra.EndsWith("ção") || palavra.EndsWith("ião"))
                return palavra.Remove(palavra.Length - 2) + "ões";

            if (palavra.EndsWith("el"))
                return palavra.Remove(palavra.Length - 2) + "éis";

            return palavra + "s";
        }
    }
}
