using ClassroomStart.Data;
using ClassroomStart.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using (DatabaseContext context = new DatabaseContext())

    foreach (Client clients in context.Clients.ToList())

    {
        context.Entry(clients).Collection(x => x.Accounts).Load();
        Console.WriteLine(clients.CId + " : " + clients.VIPClient);
    }








Console.WriteLine("Testing");