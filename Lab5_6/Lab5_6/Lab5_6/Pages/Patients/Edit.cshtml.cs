using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab5_6.Data;
using Lab5_6.Entities;
using Lab5_6.Services;

namespace Lab5_6.Pages.Patients
{
    public class EditModel : PageModel
    {
        private readonly Lab5_6.Data.PatientInfoContext _context;
        private readonly IPatientService _patientService;

        public EditModel(Lab5_6.Data.PatientInfoContext context, IPatientService patientService)
        {
            _context = context;
            _patientService = patientService;
        }

        [BindProperty]
        public Patient Patient { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            ViewData["DiagnosisId"] = new SelectList(_context.Diagnoses, "Id", "Title");

            if (id == null)
            {
                return NotFound();
            }

            Patient = await _patientService.GetByIdAsync(id);

            if (Patient == null)
            {
                return NotFound();
            }

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Patient != null)
            {
                await _patientService.UpdateAsync(Patient);
            }

            return RedirectToPage("/Patients/Index");
        }
    }
}
