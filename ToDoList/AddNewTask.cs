﻿using System;
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

            Console.WriteLine("\n\n\nSELECT LIST TO ADD TO-DO'S TO\n");
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
                Console.WriteLine("\n\nTo-do to add or press Q to quit: ");
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
            Console.WriteLine("\n\n\nSELECT LIST TO DELETE TO-DO FROM ");
            CreateToDoList.EveryListTitleInJson();
            var choosenList = Console.ReadLine();
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
                Console.WriteLine("\n\n\nSELECT TO-DO TO DELETE OR PRESS 'q' TO QUIT. ");
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

                Validation.IsThereAnyTasks(num);


            }
            

        }


        public static void ChangeTaskName()
        {
            var json = CreateToDoListFile.GetJson();
            Console.WriteLine("\n\n\nSELECT LIST TO EDIT TO-DO IN:\n");
            CreateToDoList.EveryListTitleInJson();
            var choosenList = Console.ReadLine();

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


            Console.WriteLine("\n\n\nSELECT TO-DO TO RENAME\n");
            EveryTaskInList(num);
            var taskToChange = Console.ReadLine();
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


            Console.WriteLine("\n\n\nENTER NEW TO-DO NAME:");
            string newTaskName = Console.ReadLine();
            if (String.IsNullOrEmpty(newTaskName))
            {
                Console.WriteLine("You have to enter a new name.");
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
            Console.WriteLine("\n\n\nSELECT LIST TO MARK COMPLETED TO-DO'S\n");
            CreateToDoList.EveryListTitleInJson();
            var listChoice = Console.ReadLine();
            
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
            bool isCompleted = true;
            Console.WriteLine("\n\n\nSELECT TO-DO TO MARK AS COMPLETE:\n");
          
                EveryTaskInList(num);
            while (isCompleted)
            {
                var whatToDo = Console.ReadLine();
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

                Console.WriteLine("\n\nSelect another to-do to mark as complete or press 'Q' to quit.");
                json[num].Task[taskToChange].Completed = true;
                CreateToDoListFile.UpDate(json);
            }

            isCompleted= false;
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