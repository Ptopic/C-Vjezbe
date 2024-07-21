namespace Lab_2;

class Program
{
    static void Main(string[] args)
    {
        const int PATIENTS_COUNT = 5;
        var patients = Patient.SeedPatients(PATIENTS_COUNT);

        var reception = new List<Patient>();

        var exit = false;

        while(!exit)
        {
            Console.Clear();
            Console.WriteLine("Main menu\n");

            Console.WriteLine(@"
---------------------
1 - Manage patients
2 - Reception actions
0 - Quit
---------------------");

            var userInput = InputHelpers.InputNumberChoice(0, 2);

            Console.Clear();

            switch (userInput)
            {
                case 0:
                    exit = true;
                    break;
                case 1:
                    ManagePatients(patients);
                    break;
                case 2:
                    ReceptionActions(patients, reception);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }

    private static void ManagePatients(List<Patient> patients)
    {
        var back = false;

        while (!back)
        {
            Console.WriteLine(@"
---------------------
1 - Display patients
2 - Add patient
3 - Edit patient
4 - Delete patient
0 - Back
---------------------");

            var userInput = InputHelpers.InputNumberChoice(0, 4);

            Console.Clear();

            switch (userInput)
            {
                case 0:
                    back = true;
                    break;
                case 1:
                    DisplayPatients(patients);
                    break;
                case 2:
                    AddPatient(patients);
                    break;
                case 3:
                    EditPatient(patients);
                    break;
                case 4:
                    DeletePatient(patients);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }

    private static void DisplayPatients(List<Patient> patients, string displayFilter = "all")
    {
        Console.WriteLine(displayFilter == "reception"
            ? "----- Display Currently Admitted Patients: -----"
            : "----- Display All Patients: -----");

        Console.WriteLine($"\nThere is currently {patients.Count} patients{(displayFilter == "reception" ? " admitted" : "")}.");

        foreach (var patient in patients)
        {
            Console.WriteLine(patient);
        }
    }

    private static void AddPatient(List<Patient> patients)
    {
        Console.WriteLine("----- Add Patient: -----");

        Console.WriteLine("\nEnter patient details:");

        var oib = InputHelpers.InputUniqueOib(patients);
        var mbo = InputHelpers.InputUniqueMbo(patients);
        var firstName = InputHelpers.InputValue("First name");
        var lastName = InputHelpers.InputValue("Last name");
        var dateOfBirth = InputHelpers.InputDateOfBirth();
        var gender = InputHelpers.InputValue("Gender");
        var diagnosis = InputHelpers.InputValue("Diagnosis");

        patients.Add(new Patient(oib, mbo, firstName, lastName, dateOfBirth, gender, diagnosis));

        Console.WriteLine($"\nPatient {patients.Last()}\nwas successfully added!");
    }

    private static void EditPatient(List<Patient> patients)
    {
        Console.WriteLine("----- Edit Patient: -----");

        Console.WriteLine("\nEnter the MBO of the patient you want to edit:");

        var mbo = Console.ReadLine().Trim();

        var updatedPatient = patients.Find(p => p.MBO == mbo);

        if (updatedPatient == null)
        {
            Console.WriteLine($"\nPatient with MBO {mbo} doesn't exist.");
        }
        else
        {
            Console.WriteLine($"\nUpdating patient: {updatedPatient}");

            Console.WriteLine("\nChange OIB?");
            var changeOib = InputHelpers.ConfirmAction();

            switch (changeOib)
            {
                case ActionOptions.Confirm:
                    updatedPatient.OIB = InputHelpers.InputUniqueOib(patients);
                    break;
                case ActionOptions.Cancel: break;
                default: throw new NotImplementedException();
            }

            Console.WriteLine("\nChange MBO?");
            var changeMbo = InputHelpers.ConfirmAction();

            switch (changeMbo)
            {
                case ActionOptions.Confirm:
                    updatedPatient.MBO = InputHelpers.InputUniqueMbo(patients);
                    break;
                case ActionOptions.Cancel: break;
                default: throw new NotImplementedException();
            }

            Console.WriteLine("\nChange first name?");
            var changeFirstName = InputHelpers.ConfirmAction();

            switch (changeFirstName)
            {
                case ActionOptions.Confirm:
                    updatedPatient.Firstname = InputHelpers.InputValue("First name");
                    break;
                case ActionOptions.Cancel: break;
                default: throw new NotImplementedException();
            }

            Console.WriteLine("\nChange last name?");
            var changeLastName = InputHelpers.ConfirmAction();



            switch (changeLastName)
            {
                case ActionOptions.Confirm:
                    updatedPatient.Lastname = InputHelpers.InputValue("Last name");
                    break;
                case ActionOptions.Cancel: break;
                default: throw new NotImplementedException();
            }

            Console.WriteLine("\nChange date of birth?");
            var changeDateOfBirth = InputHelpers.ConfirmAction();

            switch (changeDateOfBirth)
            {
                case ActionOptions.Confirm:
                    updatedPatient.DateOfBirth = InputHelpers.InputDateOfBirth();
                    break;
                case ActionOptions.Cancel: break;
                default: throw new NotImplementedException();
            }

            Console.WriteLine("\nChange gender?");
            var changeGender = InputHelpers.ConfirmAction();

            switch (changeGender)
            {
                case ActionOptions.Confirm:
                    updatedPatient.Gender = InputHelpers.InputValue("Gender");
                    break;
                case ActionOptions.Cancel: break;
                default: throw new NotImplementedException();
            }

            Console.WriteLine("\nChange diagnosis?");
            var changeDiagnosis = InputHelpers.ConfirmAction();

            switch (changeDiagnosis)
            {
                case ActionOptions.Confirm:
                    updatedPatient.Diagnosis = InputHelpers.InputValue("Diagnosis");
                    break;
                case ActionOptions.Cancel: break;
                default: throw new NotImplementedException();
            }

            Console.WriteLine($"\nPatient details successfully updated to: {updatedPatient}");
        }
    }

    private static void DeletePatient(List<Patient> patients)
    {
        Console.WriteLine("----- Delete Patient: -----");

        Console.WriteLine("\nEnter the MBO of the patient you want to delete:");

        var mbo = Console.ReadLine().Trim();

        var deletedPatient = patients.Find(p => p.MBO == mbo);

        if (deletedPatient == null)
        {
            Console.WriteLine($"\nPatient with MBO {mbo} doesn't exist.");
        }
        else
        {
            Console.WriteLine($"\nAre you sure you want to delete patient: {deletedPatient}\n");
            var userInput = InputHelpers.ConfirmAction();

            switch (userInput)
            {
                case ActionOptions.Confirm:
                    patients.Remove(deletedPatient);
                    Console.WriteLine("\nPatient successfully deleted!");
                    break;
                case ActionOptions.Cancel:
                    Console.WriteLine("\nAction canceled.");
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }

    private static void ReceptionActions(List<Patient> patients, List<Patient> reception)
    {
        var back = false;

        while (!back)
        {
            Console.WriteLine(@"
---------------------
1 - Display addmited patients
2 - Patient admittance
3 - Patient discharge
0 - Back
---------------------");

            var userInput = InputHelpers.InputNumberChoice(0,3);

            Console.Clear();

            switch (userInput)
            {
                case 0:
                    back = true;
                    break;
                case 1:
                    DisplayPatients(reception, "reception");
                    break;
                case 2:
                    PatientAdmittance(patients, reception);
                    break;
                case 3:
                    PatientDischarge(patients, reception);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }

    private static void PatientAdmittance(List<Patient> patients, List<Patient> reception)
    {
        Console.WriteLine("----- Patient Admittance: -----");

        Console.WriteLine("\nEnter the MBO of the patient to be admitted to the hospital:");

        var mbo = Console.ReadLine().Trim();

        var admittedPatient = patients.Find(p => p.MBO == mbo);

        if (admittedPatient == null)
        {
            Console.WriteLine($"\nPatient with MBO {mbo} doesn't exist.");
        }
        else if (reception.Contains(admittedPatient))
        {
            Console.WriteLine($"\nPatient {admittedPatient}\nis already admitted to the hospital!");
        }
        else
        {
            Console.WriteLine($"\nPatient {admittedPatient}\nadmitted to the hospital at {DateTime.Now}.");
            reception.Add(admittedPatient);
        }
    }

    private static void PatientDischarge(List<Patient> patients, List<Patient> reception)
    {
        Console.WriteLine("----- Patient Discharge: -----");

        Console.WriteLine("\nEnter the MBO of the patient to be discharged from the hospital:");

        var mbo = Console.ReadLine().Trim();

        var dischargedPatient = patients.Find(p => p.MBO == mbo);

        if (dischargedPatient == null)
        {
            Console.WriteLine($"\nPatient with MBO {mbo} doesn't exist.");
        }
        else if (!reception.Contains(dischargedPatient))
        {
            Console.WriteLine($"\nPatient {dischargedPatient}\nis not currently admitted to the hospital!");
        }
        else
        {
            Console.WriteLine($"\nPatient {dischargedPatient}\ndischarged from the hospital at {DateTime.Now}.");
            reception.Remove(dischargedPatient);
        }
    }
}

