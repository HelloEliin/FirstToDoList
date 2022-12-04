using System;
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
            int num = 0;

            Console.WriteLine("\n\nSELECT LIST TO ADD TO-DO'S TO");
            CreateToDoList.EveryListTitleInJson();
            var choosenList = Console.ReadLine();
            bool valid = int.TryParse(choosenList, out num);
            if (!valid)
            {
                Console.WriteLine("You have to choose a number.");
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

               
                json[num].Task.Add(task);
                CreateToDoListFile.UpDate(json);

            }



        }

        public static void DeleteTask()
        {
            var json = CreateToDoListFile.GetJson();
            Console.WriteLine("\n\nSELECT LIST TO DELETE TO-DO FROM ");
            CreateToDoList.EveryListTitleInJson();
            var choosenList = Console.ReadLine();
            int num = 0;
            bool valid = int.TryParse(choosenList, out num);
            if (!valid)
            {
                Console.WriteLine("You have to choose a number.");
                return;
            }


            bool isTasks = Validation.IsThereAnyTasks(num);
            if (isTasks == false)
            {
                return;
            }

            Console.WriteLine("SELECT TO-DO TO DELETE ");
            EveryTaskInList(num);
            var index = Console.ReadLine();
            int taskToRemove = 0;
            bool validOrNot = int.TryParse(index, out taskToRemove);
            if (!validOrNot)
            {
                Console.WriteLine("You have to choose a number.");
                return;
            }



            Console.WriteLine("Do you want to delete this to-do? y/n");
            string yesOrNo = Console.ReadLine().ToLower();
            if (String.IsNullOrEmpty(yesOrNo))
            {
                Console.WriteLine("Only 'y' or 'n'");
            }

            if (yesOrNo == "y")
            {

                json[num].Task.RemoveAt(taskToRemove);
                Console.WriteLine("TO-DO REMOVED.");
                CreateToDoListFile.UpDate(json);
            }

            if(yesOrNo == "n")
            {
                return;
            } 

            
            return;

        }


        public static void ChangeTaskName()
        {
            var json = CreateToDoListFile.GetJson();
            Console.WriteLine("\nSELECT LIST TO EDIT TO-DO IN:\n");
            CreateToDoList.EveryListTitleInJson();
            var choosenList = Console.ReadLine();

            int num = 0;

            bool valid = int.TryParse(choosenList, out num);
            if (!valid)
            {
                Console.WriteLine("You have to choose a number.");
                return;
            }

            bool isTasks = Validation.IsThereAnyTasks(num);
            if (isTasks == false)
            {
                return;
            }


            Console.WriteLine("\nSELECT TO-DO TO RENAME\n");
            EveryTaskInList(num);
            var taskToChange = Console.ReadLine();

            bool validOrNot = int.TryParse(taskToChange, out num);
            if (!valid)
            {
                Console.WriteLine("You have to choose a number.");
                return;
            }


            Console.WriteLine("ENTER NEW TO-DO NAME:");
            string newTaskName = Console.ReadLine();
            if (String.IsNullOrEmpty(newTaskName))
            {
                Console.WriteLine("You have to enter a new name.");
                return;
            }

            json[num].Task[num].TaskTitle = newTaskName;

            CreateToDoListFile.UpDate(json);
            return;



        }


        public static void isCompleted()
        {
            var json = CreateToDoListFile.GetJson();
            Console.WriteLine("\nSELECT LIST TO MARK COMPLETED TO-DO'S\n");
            CreateToDoList.EveryListTitleInJson();
            var listChoice = Console.ReadLine();
       
            int num = 0;

            bool valid = int.TryParse(listChoice, out num);
            if (!valid)
            {
                Console.WriteLine("You have to choose a number.");
                return;
            }

            bool isThereTasks = Validation.IsThereAnyTasks(num);
            if (!isThereTasks)
            {
                return;
            }
            //Här

            Console.WriteLine("\nSELECT TO-DO TO MARK AS COMPLETE:\n");
            EveryTaskInList(num);
            var whatToDo = Console.ReadLine();
            int taskToChange = 0;
            bool validOrNot = int.TryParse(whatToDo, out taskToChange);
            if (!validOrNot)
            {
                Console.WriteLine("You have to choose a number.");
                return;
            }

            Console.WriteLine("TO DO IS NOW MARKED AS COMPLETE.");
            json[num].Task[taskToChange].Completed = true;
            CreateToDoListFile.UpDate(json);
            return;



        }


        public static void EveryTaskInList(int list)
        {
            var json = CreateToDoListFile.GetJson();
            int index = -1;

            foreach (var task in json[list].Task)
            {
                
                if (task.Completed == true)
                {

                    Console.ForegroundColor = ConsoleColor.Green;
                }

                if (task.Completed == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                index++;
                Console.WriteLine("[" + index + "] " + task.TaskTitle);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

    }

}