using System;
using Blog.Models;
using Blog.Repositories;
namespace Blog.Screens.TagScreens{

public static class DeleteTagScreen{

    public static void Load(){

        Console.Clear();
        Console.WriteLine("Delete Tag");
        Console.WriteLine("--------");
        Console.WriteLine("Id: ");
        var id = int.Parse(Console.ReadLine());
        Console.WriteLine("Name: ");

        Delete(id);

        Console.ReadKey();
        MenuTagScreen.Load();

    }

    public static void Delete(int id){
        try{
            var repository = new Repository<Tag>(Database.DbConnection);
            repository.Delete(id);
            
            Console.WriteLine("-----------");
            Console.WriteLine("Tag deleted!");
        }
        catch(Exception ex){
            Console.WriteLine("Was not possible to delete the tag");
            Console.WriteLine(ex.Message);

        }
    }
}
}