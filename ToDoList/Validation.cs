﻿using System;
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


        public static bool IsThereValidNumber(string numberOrNot)
        {
            var json = CreateToDoListFile.GetJson();
            int num = 0;

            if (!int.TryParse(numberOrNot, out num))
            {
                Console.WriteLine("Select a number.");
                return false;
            }

            if (num > json.Count || num < 0)
            {
                Console.WriteLine("That list dont exist.");
                return false;

            }


            return true;
        }


        public static bool IsThereAnyTasks(int choosenList)
        {
            var json = CreateToDoListFile.GetJson();
            if (json[choosenList].Task.Count == 0)
            {
                Console.WriteLine("You have no to-do's in this list.");
                return false;
            }

            return true;
        }

    }
}