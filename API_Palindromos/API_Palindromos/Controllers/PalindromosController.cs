using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using API_Palindromos.Entities;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace API_Palindromos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PalindromosController : ControllerBase
    {
        [HttpPost]
        public string POST(Frase dto)
        {
            string Frase = dto.frase.Replace(" ", String.Empty).ToLower();
            string caracter;
            string inverso = "";
            string msg;

            int i = Frase.Length;
            MatchCollection wordColl = Regex.Matches(dto.frase, @"[\W]+");

            for(int x = (i - 1); x >= 0; x--)
            {
                caracter = Frase.Substring(x, 1);
                inverso = inverso + caracter;
            }

            if (Frase == inverso)
            {
                msg = "es palindromio";
            }
            else
            {
                msg = "no es palindromo";
            }
            
            Palindromos palindromo = new Palindromos()
            {
                Frase = dto.frase,
                Estatus = msg,
                Numero_de_Palabras = (wordColl.Count + 1)
            };

            string json = JsonSerializer.Serialize(palindromo);

            return json;
        }
    }
}