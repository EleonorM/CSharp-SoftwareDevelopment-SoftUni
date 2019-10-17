namespace P04_Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private Dictionary<string, List<string>> doctors;
        private Dictionary<string, List<List<string>>> departments;

        public Engine()
        {
            doctors = new Dictionary<string, List<string>>();
            departments = new Dictionary<string, List<List<string>>>();
        }

        public void Run()
        {
            string command = Console.ReadLine();
            while (command != "Output")
            {
                string[] tokens = command.Split();
                var departament = tokens[0];
                var firstName = tokens[1];
                var secondName = tokens[2];
                var patient = tokens[3];
                var fullName = firstName + secondName;

                AddDoctor(fullName);
                AddDepartment(departament);

                bool haveSpace = departments[departament].SelectMany(x => x).Count() < 60;
                if (haveSpace)
                {

                    doctors[fullName].Add(patient);
                    AddPatientToRoom(departament, patient);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split();

                if (args.Length == 1)
                {
                    string depatmentName = args[0];
                    PrintPatientsInDepartment(depatmentName);
                }
                else if (args.Length == 2)
                {
                    bool isRoom = int.TryParse(args[1], out int room);
                    if (isRoom)
                    {
                        string depatmentName = args[0];
                        PrintAllPatientsInRoom(args, room);
                    }
                    else
                    {
                        PrintPationestOfDoctor(args);
                    }
                }
                command = Console.ReadLine();
            }
        }

        private void PrintPationestOfDoctor(string[] args)
        {
            var allPationestOfDoctor = doctors[args[0] + args[1]]
                                        .OrderBy(x => x)
                                        .ToArray();
            Console.WriteLine(string.Join(Environment.NewLine, allPationestOfDoctor));
        }

        private void PrintAllPatientsInRoom(string[] args, int room)
        {
            var allPatientsInRoom = departments[args[0]][room - 1]
                .OrderBy(x => x)
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, allPatientsInRoom));
        }

        private void PrintPatientsInDepartment(string depatmentName)
        {
            var allPatientsInDepartment = departments[depatmentName]
                .Where(x => x.Count > 0)
                .SelectMany(x => x)
                .ToArray();
            Console.WriteLine(string.Join(Environment.NewLine, allPatientsInDepartment));
        }

        private void AddPatientToRoom(string departament, string patient)
        {
            int room = 0;
            for (int currentRoom = 0; currentRoom < departments[departament].Count; currentRoom++)
            {
                if (departments[departament][currentRoom].Count < 3)
                {
                    room = currentRoom;
                    break;
                }
            }
            departments[departament][room].Add(patient);
        }

        private void AddDepartment(string departament)
        {
            if (!departments.ContainsKey(departament))
            {
                departments[departament] = new List<List<string>>();
                for (int room = 0; room < 20; room++)
                {
                    departments[departament].Add(new List<string>());
                }
            }
        }

        private void AddDoctor(string fullName)
        {
            if (!doctors.ContainsKey(fullName))
            {
                doctors[fullName] = new List<string>();
            }
        }
    }
}
