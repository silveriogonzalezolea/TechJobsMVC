using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results

        public IActionResult Results(string searchType, string searchTerm )
        {
            // first build job dic  
            // call find by value 

            List<Dictionary<string, string>> jobs = new List<Dictionary<string, string>>();

         

            if (searchType.Equals( "all"))
            {
                jobs = JobData.FindByValue(searchTerm);
            }
            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }

            ViewBag.columns = ListController.columnChoices;
            //ViewBag.columChoices = searchType;
            ViewBag.title = "Jobs with " + searchTerm;
            ViewBag.jobs = jobs;

            return View("Index");


        }

    }
}
