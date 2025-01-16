using System;
using Blog.Repositories;
using Blog.Models;

namespace Blog.Screens.TagScreens{

public static class UpdateTagScreen{

    public static void Load(){

        Console.Clear();
        Console.WriteLine("Update Tag");
        Console.WriteLine("--------");
        Console.WriteLine("Id: ");
        var id = int.Parse(Console.ReadLine());
        Console.WriteLine("Name: ");
        var name = Console.ReadLine();
        Console.WriteLine("Slug: ");
        var slug = Console.ReadLine();

        Update(new Tag{
            Id = id,
            Name = name,
            Slug = slug
        });

        Console.ReadKey();
        MenuTagScreen.Load();

    }

    public static void Update(Tag tag){
        try{
            var repository = new Repository<Tag>(Database.DbConnection);
            repository.Update(tag);
            
            Console.WriteLine("-----------");
            Console.WriteLine("Tag updated!");
        }
        catch(Exception ex){
            Console.WriteLine("Was not possible to update the tag");
            Console.WriteLine(ex.Message);

        }
    }
}
}