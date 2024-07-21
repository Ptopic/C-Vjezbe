using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab5_6.Data;
using Lab5_6.Entities;
using System.ComponentModel.DataAnnotations;
using Lab5_6.Services;

namespace Lab5_6.Pages.Patients
{
    public class Discharge
    {
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Discharge Date")]
        public DateTime Date { get; set; }
    }

    public class DischargeModel : PageModel
    {
        private readonly Lab5_6.Data.PatientInfoContext _context;
        private readonly IPatientService _patientService;

        public DischargeModel(Lab5_6.Data.PatientInfoContext context, IPatientService patientService)
        {
            _context = context;
            _patientService = patientService;
        }

        public string ErrorMessage { get; set; }

        [BindProperty]
      public Patient Patient { get; set; } = default!;

        public Discharge? Discharge { get; set; }

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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (id == null) return NotFound();


            Patient = await _patientService.GetByIdAsync(id);

            if (Patient == null) return NotFound();

            Patient!.DateOfDischarge = Discharge!.Date;

            await _patientService.UpdateAsync(Patient);

            return RedirectToPage("/Patients");
        }
    }
}
