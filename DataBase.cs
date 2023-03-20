using System.Collections.Generic;
using System.Net.WebSockets;

class DataBase
{
    List<Department> dep_table;
    List<Worker> worker_table;

    public DataBase()
    {
        this.dep_table = new();
        this.worker_table = new List<Worker>();
    }

    public void append_worker(Worker worker)
    {
        worker_table.Add(worker);
    }

    public void append_dep(Department department)
    {
        dep_table.Add(department);
    }

    public string select_all_dep()
    {
        string output = String.Empty;

        foreach (var item in dep_table)
        {
            output += $"{item.title}\n";
        }

        return output;
    }

    public string select_all_worker()
    {
        string output = String.Empty;

        foreach (var item in worker_table)
        {
            output += $"{item.fullName} {item.age}\n";
        }
        return output;
    }


    public  void Report()
    {
        //string output = String.Empty;
        var output = from w in worker_table
                     join d in dep_table on w.depId equals d.id
                     orderby w.depId
                     select new { id = w.id, fio = w.fullName, dep = d.title, zar = w.salary};

        int n = 0;
        foreach (var item in output)
            
            {
            n += item.zar;
            //output += $"{item.fullName} {item.age} {item.id}\n";
            Console.WriteLine(item);
        }
        Console.WriteLine($"Сумма зарnлат: -- {n}");
    }
}
