using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab5_6.Data;
using Lab5_6.Entities;
using static NuGet.Client.ManagedCodeConventions;
using Lab5_6.Services.Impl;
using Lab5_6.Services;

namespace Lab5_6.Pages.Patients
{
    public class IndexModel : PageModel
    {
        private readonly Lab5_6.Data.PatientInfoContext _context;
        private readonly IPatientService _patientService;

        public IndexModel(IPatientService patientService)
        { 
            _patientService = patientService;
        }

        public IEnumerable<Patient>? Patients { get; set; }

        public List<string> PropertyNames;

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            ViewData["CurrentSort"] = sortOrder;

            Patients = await _patientService.GetAllAsync();

            PropertyNames = _patientService.getFieldNames();

            Patients = _patientService.sortingSelection(Patients, sortOrder);

            Patients = _patientService.searchSelection(Patients, searchString);
        }
    }
}
