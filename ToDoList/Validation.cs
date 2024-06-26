﻿using System;
using System.Linq;
using System.Text;

namespace ToDoList
{
    public class Validation
    {
           
        
        public static bool IsThereAnyLists()
        {
            var json = CreateToDoListFile.GetJson();
            if (json?.Any() != true)
            {
                Console.WriteLine("You have no lists.");
                return false;
            }
            return true;
        }


        public static bool IsThereValidList(int choosenList)
        {
            var json = CreateToDoListFile.GetJson();
            if (choosenList > json.Count - 1 || choosenList < 0)
            {
                Console.WriteLine("\n\nThat list dont exist.");
                return false;
            }
            return true;
        }


        public static bool IsThereAnyTasks(int choosenList)
        {
            var json = CreateToDoListFile.GetJson();
            if (json[choosenList].Task.Count == 0)
            {
                Console.WriteLine("\n\nYou have no to-do's in this list.");
                return false;
            }
            return true;
        }


        public static bool IsThereValidTask(int task, int choosenList)
        {
            var json = CreateToDoListFile.GetJson();
            if (json[choosenList].Task.Count - 1 < task || json[choosenList].Task.Count < 0)
            {
                Console.WriteLine("\n\nThat to-do dont exist.");
                return false;
            }
            return true;
        }


        public static bool IsAllComplete(int num)
        {
            var json = CreateToDoListFile.GetJson();

            bool allCompleted = json[num].Task.All(x => x.Completed == true);
            if (allCompleted)
            {
                Console.WriteLine("\n\n\n\nYou're a star baby!\nAll to-do's are completed in this list!\n");
                Console.WriteLine(json[num].ListTitle);
                AddNewTask.EveryTaskInList(num);
                return true;
            }
            return false;
        }



    }
}