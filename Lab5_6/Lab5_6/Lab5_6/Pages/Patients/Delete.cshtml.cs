using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab5_6.Data;
using Lab5_6.Entities;
using Lab5_6.Services;

namespace Lab5_6.Pages.Patients
{
    public class DeleteModel : PageModel
    {
        private readonly Lab5_6.Data.PatientInfoContext _context;
        private readonly IPatientService _patientService;

        public DeleteModel(Lab5_6.Data.PatientInfoContext context, IPatientService patientService)
        {
            _context = context;
            _patientService = patientService;
        }

        [BindProperty]
      public Patient Patient { get; set; } = default!;

        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient = await _patientService.GetByIdAsync(id);

            if (Patient == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = string.Format("Delete {ID} failed. Try again", id);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                await _patientService.DeleteAsync(id ?? Guid.Empty);
                return RedirectToPage("/Patients");
            }
            catch (DbUpdateException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);

                return RedirectToAction("./Error", new { id, saveChangesError = true });
            }
        }
    }
}
