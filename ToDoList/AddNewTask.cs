using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ToDoList
{
    public class AddNewTask
    {



        public static void AddTask()
        {
            bool isAdding = true;
            var json = CreateToDoListFile.GetJson();

            Console.WriteLine("\n\nSELECT LIST TO ADD TO-DO'S TO");
            CreateToDoList.EveryListTitleInJson();
            string choosenList = Console.ReadLine();
            bool validOrNot = Validation.IsThereValidNumber(choosenList);

            if (validOrNot == false)
            {
                return;
            }


            while (isAdding)
            {
                Console.WriteLine("To-do to add or press Q to quit: ");
                string taskToAdd = Console.ReadLine().ToLower();
                if (taskToAdd == "q")
                {
                    isAdding = false;
                    return;
                }

                var task = new Task()
                {
                    TaskTitle = taskToAdd,
                    Completed = false
                };

                int num = Convert.ToInt32(choosenList);
                json[num].Task.Add(task);
                CreateToDoListFile.UpDate(json);

            }



        }

        public static void DeleteTask()
        {
            var json = CreateToDoListFile.GetJson();
            Console.WriteLine("\n\nSELECT LIST TO DELETE TO-DO FROM ");
            CreateToDoList.EveryListTitleInJson();
            string choosenList = Console.ReadLine();

            bool isValid = Validation.IsThereValidNumber(choosenList);
            if (isValid == false)
            {
                return;
            }

            int whatList = Convert.ToInt32(choosenList);

            bool isTasks = Validation.IsThereAnyTasks(whatList);
            if (isTasks == false)
            {
                return;
            }

            Console.WriteLine("SELECT TO-DO TO DELETE ");
            EveryTaskInList(whatList);
            string index = Console.ReadLine();
            bool isValidOrNot = Validation.IsThereValidNumber(index);
            if (isValidOrNot == false)
            {
                return;
            }
            int indexToRemove = Convert.ToInt32(index);


            Console.WriteLine("Do you want to delete this to-do? y/n");
            string yesOrNo = Console.ReadLine();

            if (yesOrNo == "y")
            {

                json[whatList].Task.RemoveAt(indexToRemove);
                CreateToDoListFile.UpDate(json);
            }

            Console.WriteLine("Only 'y' or 'n'.");
            return;

        }


        public static void ChangeTaskName()
        {
            var json = CreateToDoListFile.GetJson();
            Console.WriteLine("\nSELECT LIST TO EDIT TO-DO IN:\n");
            CreateToDoList.EveryListTitleInJson();
            string choosenList = Console.ReadLine();

            bool isValid = Validation.IsThereValidNumber(choosenList);
            if (isValid == false)
            {
                return;
            }

            int whatList = Convert.ToInt32(choosenList);

            bool isTasks = Validation.IsThereAnyTasks(whatList);
            if (isTasks == false)
            {
                return;
            }


            Console.WriteLine("\nSELECT TO-DO TO RENAME\n");
            EveryTaskInList(whatList);
            string taskToChange = Console.ReadLine();
            bool isNumber = Validation.IsThereValidNumber(taskToChange);
            if (isNumber == false)
            {
                return;
            }
            int whatTask = Convert.ToInt32(taskToChange);

            Console.WriteLine("ENTER NEW TO-DO NAME:");
            string newTaskName = Console.ReadLine();

            json[whatList].Task[whatTask].TaskTitle = newTaskName;

            CreateToDoListFile.UpDate(json);
            return;



        }


        public static void isCompleted()
        {
            var json = CreateToDoListFile.GetJson();
            Console.WriteLine("\nSELECT LIST TO MARK COMPLETED TO-DO'S\n");
            CreateToDoList.EveryListTitleInJson();

            int choosenList = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nSelect to-do:\n");


            int taskToChange = Convert.ToInt32(Console.ReadLine());

            json[choosenList].Task[taskToChange].Completed = true;
            CreateToDoListFile.UpDate(json);
            return;



        }


        public static void EveryTaskInList(int list)
        {
            var json = CreateToDoListFile.GetJson();
            int index = -1;
            foreach (var task in json[list].Task)
            {

                index++;
                Console.WriteLine(index + "  " + task.TaskTitle);
            }
        }

    }

}