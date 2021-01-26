using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineClassLib;

namespace VaccineApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VaccinesController : ControllerBase
    {
        private static int nextId = 4;

        private static List<Vaccine> vaccines = new List<Vaccine>()
        {
            new Vaccine() { Id = 1, Producer = "AstraZeneca", Efficiency = 75, Price = 25 },
            new Vaccine() { Id = 2, Price = 165, Efficiency = 95, Producer = "Moderna" },
            new Vaccine() { Id = 3, Price = 165, Efficiency = 95, Producer = "Pfizer"}
        };

        [HttpGet]
        [Route("")]
        public IEnumerable<Vaccine> GetAll()
        {
            return vaccines;
        }

        [HttpGet]
        [Route("{id}")]
        public Vaccine GetById(int id)
        {
            Vaccine v = vaccines.Find(e => e.Id == id);

            if (v == null)
            {
                //hvis v lamda udtrykket ikke giver en vaccine så giver status 404 som er status for ikke fundet (not found)
                Response.StatusCode = 404;
            }

            return v;
        }

        [HttpPost]
        [Route("")]
        public int Add(Vaccine vacc)
        {
            //giver den et nyt id da vi skal styrrer det
            vacc.Id = nextId++;

            //tilføjer vaccinen til listen
            vaccines.Add(vacc);

            //sender vaccine id tilbage
            return vacc.Id;
        }

        [HttpDelete]
        [Route("{id}")]
        public bool Delete(int id)
        {

            //finde vi den vaccine der skal slettes
            Vaccine v = vaccines.Find(vac => vac.Id == id);


            //sender slette resultatet tilbage fordi den returnere true hvis den sletter ellers false hvis den ikke er der eller ikke kunne slette
            return vaccines.Remove(v);
        }

        [HttpGet]
        [Route("best")]
        public List<Vaccine> GetBest()
        {

            //der blíver sorteret på vaccines efficienci DESCENDING(nedadgående/højeste først) derefter på id hvis der er nogen der har samme efficieny, som så bliver til en liste
            List<Vaccine> orderdList = vaccines.OrderByDescending(v => v.Efficiency).ThenByDescending(v => v.Id).ToList();

            //tager fat i alle vacciner og beder den liste om at finde alle dem der har samme efficiency som det første element i vores sorterede liste (den højeste)
            List<Vaccine> bestVaccines = vaccines.FindAll(v => v.Efficiency == orderdList[0].Efficiency);

            return bestVaccines;
        }

    }
}
