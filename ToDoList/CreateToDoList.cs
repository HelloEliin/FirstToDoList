using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading.Tasks;

namespace ToDoList
{
    public class CreateToDoList
    {


        public string ListTitle { get; set; }
        public List<Task> Task { get; set; }
        public string Date { get; set; }
        public bool ThisWeek { get; set; } 
        public bool Expired { get; set; }   

        public static void CreateNewToDoList()
        {
            var json = CreateToDoListFile.GetJson();
            Console.WriteLine("\n\nENTER NAME OF LIS OR PRESS 'Q' TO QUIT.\n");
            var listName = Console.ReadLine().ToUpper();
            if(listName == "Q")
            {
                return;
            }
            if (String.IsNullOrEmpty(listName))
            {
                Console.WriteLine("You have to put a name on your list.");
                return;
            }


            var newList = new CreateToDoList()
            {
                ListTitle = listName,
                Task = new List<Task>(),
                Date = DateTime.Now.ToString("G"),
                ThisWeek = false,
                Expired = false,

            };

            json.Add(newList);
            CreateToDoListFile.UpDate(json);

            return;
        }


        public static void ViewAllList()
        {
            var json = CreateToDoListFile.GetJson();
            Validation.IsThereAnyLists();
            int index = -1;
            Console.WriteLine("\n\n\nALL OF YOUR LISTS\n");

            foreach (var title in json)
            {
                index++;
                Console.WriteLine("[" + index +"] " + title.ListTitle + "\n");
            }
            return;

        }


        public static void DeleteList()
        {

            var json = CreateToDoListFile.GetJson();
            int num = 0;

            Console.WriteLine("\n\n\nSELECT LIST TO DELETE OR PRESS 'Q' TO QUIT. \n");
            EveryListTitleInJson();
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

            bool listExists = Validation.IsThereValidList(num);
            if (!listExists)
            {
                return;
            }

            Console.WriteLine("\nDo you want to delete this list? y/n");
            string yesOrNo = Console.ReadLine().ToLower();
            if (yesOrNo == "y")
            {
                Console.WriteLine("LIST DELETED.");
                json.RemoveAt(num);
                CreateToDoListFile.UpDate(json);
            }
            else if (yesOrNo == "n")
            {
                return;
            }
            else
            {
                Console.WriteLine("Only 'y' or 'n'.");
            }

            return;

        }


        public static void ChangeListName()
        {
            var json = CreateToDoListFile.GetJson();
            int num = 0;

            Console.WriteLine("\n\n\nSELECT LIST TO RENAME OR PRESS 'Q' TO QUIT. \n");
            EveryListTitleInJson();

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
            bool validOrNot = Validation.IsThereValidList(num);

            if (!validOrNot)
            {
                return;
            }

            Console.WriteLine("ENTER NEW LISTNAME OR PRESS 'Q' TO QUIT.");
            string newListName = Console.ReadLine().ToUpper();
   
            if (String.IsNullOrEmpty(newListName))
            {
                Console.WriteLine("You have to put a name on your list.");
                return;
            }
            if(newListName == "Q")
            {
                return;
            }

            json[num].ListTitle = newListName;
            CreateToDoListFile.UpDate(json);
            return;
        }



        public static void ViewOneList()
        {
            var json = CreateToDoListFile.GetJson();
            Console.WriteLine("\n\n\nSELECT LIST TO VIEW PRESS 'Q' TO QUIT.\n");
            EveryListTitleInJson();
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
            bool validOrNot = Validation.IsThereValidList(num);
            if (!validOrNot)
            {
                return;
            
            }
            Console.WriteLine(json[num].ListTitle);
            Validation.IsThereAnyTasks(num);
            AddNewTask.EveryTaskInList(num);


        }


        public static void RecentList()
        {
            var json = CreateToDoListFile.GetJson();

            Validation.IsThereAnyLists();
            json.Reverse();

            Console.WriteLine("\n\n\n" + json[0].ListTitle);

            if (json[0].Task.Count == 0)
            {
                Console.WriteLine("Ooops.. empty! No to-do's here!");
            }

            foreach (var task in json[0].Task)
            {
               
                if (task.Completed == true)
                {

                    Console.ForegroundColor = ConsoleColor.Green;
                }

                if (task.Completed == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                Console.WriteLine(task.TaskTitle);
                Console.ForegroundColor = ConsoleColor.White;
            }

            return;

        }


        public static void EveryListTitleInJson()
        {
            var json = CreateToDoListFile.GetJson();
            int index = -1;
 
            foreach (var title in json)
            {
                index++;
                Console.WriteLine(title.ListTitle + "\nPress: " + "[" + index + "]" + "\n");
            }
        }


        public static void SortLists()
        {
            Console.WriteLine("HOW DO YOU WANT TO SORT?\n" +
                "[N]ewest list\n" +
                "[O]ldest list\n" +
                "[B]y name\n" );
            var howToSort = Console.ReadLine().ToLower();
            if (string.IsNullOrEmpty(howToSort))
            {
                Console.WriteLine("Try again.");
                return;
            }

            var json = CreateToDoListFile.GetJson();

            
            switch (howToSort)
            {
                case "n": SortByNewest();
                    break;
                case "o": SortByOldest();
                    break;
                case "b": SortByName();
                    break;
                case "h":
                    break;
                default:
                    break;

            }
        }

        public static void SortByNewest()
        {
            var json = CreateToDoListFile.GetJson();
            json = json.OrderBy(x => x.Date).ToList();
            CreateToDoListFile.UpDate(json);
            Console.WriteLine("NEW ORDER SAVED.");
        }


        public static void SortByOldest()
        {

            var json = CreateToDoListFile.GetJson();
            json = json.OrderByDescending(x => x.Date).ToList();
            CreateToDoListFile.UpDate(json);
            Console.WriteLine("NEW ORDER SAVED.");

        }


        public static void SortByName()
        {
            var json = CreateToDoListFile.GetJson();
            json = json.OrderBy(x => x.ListTitle).ToList();
            CreateToDoListFile.UpDate(json);
            Console.WriteLine("NEW ORDER SAVED.");
        }


        public static void AddListsForThisWeek()
        {
            var json = CreateToDoListFile.GetJson();
            Console.WriteLine("\n\n\n\nWHAT LIST TO ADD FOR THIS WEEKS TO-DO? PRESS 'Q' TO QUIT.\n\n");


            for (int i = 0; i < json.Count; i++)
            {
            

                if (json[i].ThisWeek == false)
                {
                    Console.WriteLine("[" + i + "] " + json[i].ListTitle);


                }
                //bool noListToMove = json[i].ThisWeek.Equals(true);

                //if (noListToMove)
                //{
                //    Console.WriteLine("No lists to move :-)");
                //    return;
                //}


            }



            var whichList = Console.ReadLine().ToLower();
            int listToMove = 0;
            if (whichList == "q")
            {
                return;
            }
            bool validOrNot = int.TryParse(whichList, out listToMove);
            if (!validOrNot)
            {
                Console.WriteLine("You have to choose a number.");
                return;
            }
     
           
            json[listToMove].ThisWeek = true;
            CreateToDoListFile.UpDate(json);
        }



        public static void ShowThisWeeksLists()
        {
            var json = CreateToDoListFile.GetJson();
            Console.WriteLine("\n\n\nYOUR LISTS FOR THIS WEEK :-)\n\n");
            for(int i = 0; i < json.Count; i++)
            { 
                if (json[i].ThisWeek == true && json[i].Expired == false)
                {
                    Console.WriteLine(json[i].ListTitle);
                    
                }
                else
                {
                    Console.WriteLine("No lists added yet :-)");
                    return;
                }


            }
        }


        public static void UnFinishedLists()
        {
            var json = CreateToDoListFile.GetJson();
            Console.WriteLine("\n\n\n- UNFINISHED LISTS - \n\n");
            
            for (int i = 0; i < json.Count; i++)
            {
                DateTime start = DateTime.Parse(json[i].Date);
                DateTime expiry = start.AddMinutes(1);
                bool allCompleted = json[i].Task.All(x => x.Completed == true);

                if (json[i].ThisWeek == true)
                {
                    
                    if (DateTime.Now > expiry)
                    {
                        json[i].Expired= true;
                        CreateToDoListFile.UpDate(json);

                        if (!allCompleted || json[i].Task.Count == 0)
                        {
                            Console.WriteLine(json[i].ListTitle);
                        }
               
                    }

                    //if (start < expiry) // Funkar ej
                    //{
                    //    Console.WriteLine("No expired lists.");
                    //    return;
                    //}
                }

            }

        }














    }
}