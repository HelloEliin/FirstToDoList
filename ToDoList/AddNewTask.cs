using System.Threading.Tasks;

namespace ToDoList
{
    public class AddNewTask
    {


        
        public static void AddTask()
        {
            var aNewTasks = new List<Task>();
            var json = CreateToDoListFile.GetJson();
            int index = -1;

            Console.WriteLine("Choose list: ");

            foreach (var title in json)
            {
                index++;
                Console.WriteLine(title.ListTitle + "\nPress: " + index + "\n");

            }

            int choosenList = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Task to add: ");
            string taskToAdd = Console.ReadLine();

            aNewTasks.Add(new Task { TaskTitle = taskToAdd, Completed = false });
            //var newTask = new Task() { TaskTitle = taskToAdd, Completed = false };
            json[choosenList].Task = aNewTasks;
            //json.Add(newTask);
            CreateToDoListFile.UpDate(json);

        }

    }

}