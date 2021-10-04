using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using API_Anagrama.Entities;
using System.Text.Json;

/* 
    Universidad Tecnologica Metropolitana

    Aplicaciones Web Orientadas a Objetos
    Docente: Chuc Uc Joel Ivan
    Actividad: Actividad 2, Ejercicio 3

    Alumno: Daniel Francisco Puch Ceballos
    Cuatrimestre: 4
    Parcial: 1
    Grupo: A
*/

namespace API_Anagrama.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnagramaController : ControllerBase
    {
        [HttpPost]
        public string POST(Palabras dto)
        {
            string palabra1 = String.Concat(dto.Palabra_1.ToLower().OrderBy(c => c));
            string palabra2 = String.Concat(dto.Palabra_2.ToLower().OrderBy(c => c));
            string msg;
            string ejemplo;

            if (palabra1 == palabra2)
            {
                msg = "Estas palabras son Anagrama un de la otra";
                ejemplo = "Estas 2 Palabras Son Un Gran Ejemplo";
            }
            else
            {
                msg = "No Son Anagramas";
                ejemplo = Ejemplos();
            }

            Anagrama anagrama = new Anagrama()
            {
                Palabra_1 = dto.Palabra_1,
                Palabra_2 = dto.Palabra_2,
                Estatus = msg,
                Ejemplo_de_Anagrama = ejemplo
            };

            string json = JsonSerializer.Serialize(anagrama);

            return json;
        }

        private static readonly string[] Anagramas= new[]
        {
            "Alegan – Ángela","Riesgo – Sergio","Valora – Álvaro","Agonista – Santiago","Colinas – Nicolás","Calor – Carla","Quieren – Enrique","Prisa – París","Riesgo – Sergio","Poder – Pedro","Ramón – Norma","Necrófila – Florencia","Poder – Pedro","Armonía – Mariano","Mora – Roma","Salario – Rosalía","Saunas – Susana","Ovoide – Oviedo","Aretes – Teresa","Camelia – Micaela","Ventilan – Valentín","Enlodar – Leandro","Trama – Marta","Delira – lidera","Cardiografía – radiografía","Agranda – granada","Desamparador – desparramado","Licúa – Lucía","Conservadora – conversadora","Amor – Roma","Irónicamente – renacimiento","Nacionalista – altisonancia","Escandalizar – zascandilear","Frase – fresa","Enfriamiento – refinamiento","Integrarla – Inglaterra","Sórdidamente – desmentidora","Acuerdo – Ecuador","Materialismo – memorialista","Deudora – Eduardo","Energéticamente – genéricamente","Fotoligografía – litofotografía","Presuposición – superposición","Saco – cosa","Enamoramientos – armoniosamente","Caldearnos – encaradlos","Rectificable – certificable","Aceleradnos – acerándoles","Reconquistados – conquistadores","Acertándoles – altercándose","Escabullimiento – bulliciosamente","Caliente – Alicante","Electromagnético – magnetoeléctrico","Posaré – posera","Imponderablemente – imperdonablemente","Topera – trepaos","Raza – Zara","Presa – rapés","Pagar – Praga","Esta – ates","Cornisa – Narciso","Él – le","Amparo – Páramo","Resto – retos","Camino – Mónica","Reías – ríase","Matar – Marta","Terso – teros",
        };
        public string Ejemplos()
        {
            var rng = new Random();
            return Anagramas[rng.Next(Anagramas.Length)];
        }
    }
}