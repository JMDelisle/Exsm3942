Console.WriteLine("Test"); 

// Use our models namespace so we have access to the models and the dbcontext.



// SELECT Example
// Any time we want to access the database, if we wrap it in a using statement it ensures that when we are done, the connection isn't hanging open.
/*
  using (DatabaseContext context = new DatabaseContext())
{
    foreach (Product product in context.Products.ToList())
    {
        context.Entry(product).Reference(x => x.ProductCategory).Load();
        Console.WriteLine(product.ProductCategory.Name + ": " + product.Name + " costs " + product.SalePrice);
    }


    foreach (Product product in context.Products.Include(product => product.ProductCategory))
    {
        Console.WriteLine(product.ProductCategory.Name + ": " + product.Name + " costs " + product.SalePrice);
    }
}

using (DatabaseContext context = new DatabaseContext())
{
    foreach (Product product in context.Products.ToList().Where(product => product.ReorderNecessary).ToList()) Console.WriteLine("Please Reorder " + product.Name);
}

string category, name;
decimal price;
int qoh;

Console.Write("Please enter the new product name: ");
name = Console.ReadLine().Trim();
Console.Write("Please enter the new product category: ");
category = Console.ReadLine().Trim();
Console.Write("Please enter the new product sale price: ");
price = decimal.Parse(Console.ReadLine());
Console.Write("Please enter the new product quantity on hand: ");
qoh = int.Parse(Console.ReadLine());
using (DatabaseContext context = new DatabaseContext())
{
    try
    {
        context.Products.Add(new Product()
        {
            Name = name,
            SalePrice = price,
            QuantityOnHand = qoh,
            ProductCategory = context.ProductCategories.Where(x => x.Name == category).Single()
        });
    }
    catch (Exception ex)
    {
        Console.WriteLine("ERROR: " + ex.Message);
    }
    context.SaveChanges();
}

string oldname, newname;
Console.Write("Please enter the product name to update: ");
oldname = Console.ReadLine().Trim();
Console.Write("Please enter the new product name: ");
newname = Console.ReadLine().Trim();

using (DatabaseContext context = new DatabaseContext())
{
    context.Products.Where(x => x.Name == oldname).Single().Name = newname;

    context.SaveChanges();
}
*/