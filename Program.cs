using ClassroomStart.Models;

using (DatabaseContext context = new DatabaseContext())
{
    foreach(Account account in context.Accounts) Console.WriteLine(account.AccBalance + " current balance"+ account.AccAppliedinterest);
}