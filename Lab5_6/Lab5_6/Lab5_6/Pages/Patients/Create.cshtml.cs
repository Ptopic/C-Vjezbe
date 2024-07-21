using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lab5_6.Data;
using Lab5_6.Entities;
using Lab5_6.Services.Impl;
using Lab5_6.Services;

namespace Lab5_6.Pages.Patients
{
    public class CreateModel : PageModel
    {
        private readonly Lab5_6.Data.PatientInfoContext _context;
        private readonly IPatientService _patientService;

        public CreateModel(Lab5_6.Data.PatientInfoContext context, IPatientService patientService)
        {
            _context = context;
            _patientService = patientService;
        }

        public IActionResult OnGet()
        {
        ViewData["DiagnosisId"] = new SelectList(_context.Diagnoses, "Id", "Title");
            return Page();
        }

        [BindProperty]
        public Patient Patient { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Patients == null || Patient == null)
            {
                return Page();
            }

            await _patientService.AddAsync(Patient);
            return Page();
        }
    }
}
