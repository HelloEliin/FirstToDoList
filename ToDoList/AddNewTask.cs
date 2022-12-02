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
                int index = -1;

            Console.WriteLine("\n\nSELECT LIST TO ADD TO-DO'S TO");

                foreach (var title in json)
                {
                    index++;
                    Console.WriteLine(title.ListTitle + "\nPress: " + index + "\n");

                }

                string choosenList = Console.ReadLine();
                bool validOrNot = Validation.IsThereValidNumber(choosenList);

                if(validOrNot == false)
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
            int index = -1;

            Console.WriteLine("\n\nSELECT LIST TO DELETE TO-DO FROM ");

            foreach (var title in json)
            {
                index++;
                Console.WriteLine(title.ListTitle + "\npress: " + index + "\n");

            }

            int choosenList = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Select index of the task you want to remove: ");

            int order = -1;
            foreach (var task in json[choosenList].Task)
            {

                order++;
                Console.WriteLine(order + "  " + task.TaskTitle);
            }

            int toRemove = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Do you want to delete this to-do? y/n");
            string yesOrNo = Console.ReadLine();

            if (yesOrNo == "y")
            {

                json[choosenList].Task.RemoveAt(toRemove);
                CreateToDoListFile.UpDate(json);
            }

            return;

        }


        public static void ChangeTaskName()
        {
            var json = CreateToDoListFile.GetJson();
            int index = -1;

            Console.WriteLine("\nSELECT LIST TO EDIT TO-DO IN:\n");

            foreach (var title in json)
            {
                index++;
                Console.WriteLine("LISTNAME\n" + title.ListTitle + "\nPress: " + index + "\n");

            }

            int choosenList = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nSELECT TO-DO TO RENAME\n");
            int order = -1;
            foreach (var task in json[choosenList].Task)
            {

                order++;
                Console.WriteLine(order + "  " + task.TaskTitle);
            }

            int taskToChange = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("ENTER NEW TO-DO NAME:");
            string newTaskName = Console.ReadLine();

            json[choosenList].Task[taskToChange].TaskTitle = newTaskName;
            CreateToDoListFile.UpDate(json);
            return;



        }


        public static void isCompleted()
        {
            var json = CreateToDoListFile.GetJson();
            int index = -1;

            Console.WriteLine("\nChoose a list to mark tasks as completed in:\n");

            foreach (var title in json)
            {
                index++;
                Console.WriteLine("   LISTNAME   \n" + title.ListTitle + "\nPress: " + index + "\n");

            }

            int choosenList = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nWhich task do you want to mark as complete?\n");
            int order = -1;
            foreach (var task in json[choosenList].Task)
            {

                order++;
                Console.WriteLine(order + "  " + task.TaskTitle);
            }

            int taskToChange = Convert.ToInt32(Console.ReadLine());

            json[choosenList].Task[taskToChange].Completed = true;
            CreateToDoListFile.UpDate(json);
            return;



        }

    }

}