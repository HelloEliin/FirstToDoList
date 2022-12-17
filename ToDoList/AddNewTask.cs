using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
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

            Console.WriteLine("\n\n\nSELECT LIST TO ADD TO-DO'S TO OR PRESS 'Q' TO QUIT.\n");
            CreateToDoList.EveryListTitleInJson();
            var choosenList = Console.ReadLine().ToLower();
            if(choosenList == "q")
            {
                return;
            }
            bool valid = int.TryParse(choosenList, out num);
            if (!valid)
            {
                Console.WriteLine("You have to choose a number.");
                return;
            }

            bool isValidList = Validation.IsThereValidList(num);
            if (!isValidList)
            {
                return;
            }

            while (isAdding)
            {
                Console.WriteLine("\n\nTO-DO TO ADD OR PRESS 'Q' TO QUIT. ");
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
            Console.WriteLine("\n\n\nSELECT LIST TO DELETE TO-DO FROM OR PRESS 'Q' TO QUIT.");
            CreateToDoList.EveryListTitleInJson();
            var choosenList = Console.ReadLine().ToLower();
            if(choosenList == "q")
            { 
                return;
            }
            int num = 0;
            bool valid = int.TryParse(choosenList, out num);
            if (!valid)
            {
                Console.WriteLine("You have to choose a number.");
                return;
            }

            bool isExisting = Validation.IsThereValidList(num);
            if (!isExisting)
            {
                return;
            }


            bool isTasks = Validation.IsThereAnyTasks(num);
            if (isTasks == false)
            {
                return;
            }


            
            bool isDeleting = true;
            while (isDeleting)
            {
                Console.WriteLine("\n\n\nSELECT TO-DO TO DELETE OR PRESS 'Q' TO QUIT. ");
                EveryTaskInList(num);
                
                var index = Console.ReadLine().ToLower();
                int taskToRemove = 0;
                if(index == "q")
                {
                    isDeleting= false;
                    return;
                }
                bool validOrNot = int.TryParse(index, out taskToRemove);
                if (!validOrNot)
                {
                    Console.WriteLine("You have to choose a number.");
                    return;

                }

                bool isTaskExisting = Validation.IsThereValidTask(taskToRemove, num);
                if (!isTaskExisting)
                {
                    return;
                }

                Console.WriteLine("Do you want to delete this to-do? y/n");
                string yesOrNo = Console.ReadLine().ToLower();

                if (yesOrNo == "y")
                {
                    Console.WriteLine("TO-DO REMOVED.");
                    json[num].Task.RemoveAt(taskToRemove);
                    CreateToDoListFile.UpDate(json);
                    

                }
                else if (yesOrNo == "n")
                {
                    Console.WriteLine("TO-DO IS NOT REMOVED.");

                }
                else
                {
                    Console.WriteLine("Only 'y' or 'n'");
                    isDeleting = false;
                    return;
                    
                }

                bool anyLeft = Validation.IsThereAnyTasks(num);
                if (!anyLeft)
                {
                    return;
                }
               

            }
            
            

        }


        public static void ChangeTaskName()
        {
            var json = CreateToDoListFile.GetJson();
            Console.WriteLine("\n\n\nSELECT LIST TO EDIT TO-DO IN OR PRESS 'Q' TO QUIT.\n");
            CreateToDoList.EveryListTitleInJson();
            var choosenList = Console.ReadLine().ToLower();
            if(choosenList == "q")
            {
                return;
            }

            int num = 0;

            bool valid = int.TryParse(choosenList, out num);
            if (!valid)
            {
                Console.WriteLine("You have to choose a number.");
                return;
            }

            bool isExisting = Validation.IsThereValidList(num);
            if (!isExisting)
            {
                return;
            }

            bool isThereTasks = Validation.IsThereAnyTasks(num);
            if (!isThereTasks)
            {
                return;
            }




            Console.WriteLine("\n\n\nSELECT TO-DO TO RENAME OR PRESS 'Q' TO QUIT");
            EveryTaskInList(num);
            var taskToChange = Console.ReadLine().ToLower();
            if(taskToChange == "q")
            {
                return;
            }
            if (string.IsNullOrEmpty(taskToChange))
            {
                Console.WriteLine("You have to choose a to-do.");
                return;
            }

            int task = 0;

            bool validOrNot = int.TryParse(taskToChange, out task);
            if (!valid)
            {
                Console.WriteLine("You have to choose a number.");
                return;
            }

            bool isTaskExisting = Validation.IsThereValidTask(task, num);
            if (!isTaskExisting)
            {
                return;
            }


            Console.WriteLine("\n\n\nENTER NEW TO-DO NAME OR PRESS 'Q' TO QUIT.");
            string newTaskName = Console.ReadLine().ToLower();
            if (String.IsNullOrWhiteSpace(newTaskName))
            {
                Console.WriteLine("You have to enter a new name.");
                return;
            }
            if(newTaskName == "q")
            {
                return;
            }

            Console.WriteLine("TO-DO CHANGED.");
            json[num].Task[task].TaskTitle = newTaskName;

            CreateToDoListFile.UpDate(json);
            return;



        }


        public static void isCompleted()
        {
            var json = CreateToDoListFile.GetJson();
            Console.WriteLine("\n\n\nSELECT LIST TO MARK COMPLETED TO-DO'S OR PRESS 'Q' TO QUIT.\n");
            CreateToDoList.EveryListTitleInJson();
            var listChoice = Console.ReadLine().ToLower();
            if(listChoice == "q")
            {
                return;
            }
            
            int num = 0;

            bool valid = int.TryParse(listChoice, out num);
            if (!valid)
            {
                Console.WriteLine("You have to choose a number.");
                return;
            }

            bool isThereList = Validation.IsThereValidList(num);
            if (!isThereList)
            {
                return;
            }

            bool isThereTasks = Validation.IsThereAnyTasks(num);
            if (!isThereTasks)
            {
                return;
            }


            bool isAllCompleted = Validation.IsAllComplete(num);
            if(isAllCompleted)
            { 
                return;
            }
 
            bool isToComplete = true;
            while (isToComplete)
            {
                Console.WriteLine("\n\n\nSELECT TO-DO TO MARK AS COMPLETE OR PRESS 'Q' TO QUIT.\n");
          
                EveryTaskInList(num);

                var whatToDo = Console.ReadLine().ToLower();
                int taskToChange = 0;
                if(whatToDo == "q")
                { 
                    return;
                }
                bool validOrNot = int.TryParse(whatToDo, out taskToChange);
                if (!validOrNot)
                {
                    Console.WriteLine("You have to choose a number.");
                    return;
                }
                bool isThereTask = Validation.IsThereValidTask(taskToChange, num);
                if (!isThereTask)
                { 
                   return;
                }

                json[num].Task[taskToChange].Completed = true;
                CreateToDoListFile.UpDate(json);

                Console.WriteLine("\n\n\nHurray!");


                bool isItComplete = Validation.IsAllComplete(num);
                if (isItComplete)
                { 
                    return;
                }

            }

            isToComplete= false;
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