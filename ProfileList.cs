using System;
using System.Collections.Generic;


public class ProfileList
{
    List<Profile> profiles = new List<Profile>();
    public ProfileList()
    {
        profiles.Add(new Profile { id = 1, name = "Hugh", surname = "Mungu", age = 96, weight = 68.71, length = 1.31, type = 1 , username = "hugh" , password = "mungu"  });
        profiles.Add(new Profile { id = 2, name = "Jack", surname = "Mango", age = 56, weight = 78.23, length = 1.81, type = 2, username = "jack", password = "mango" });
        profiles.Add(new Profile { id = 3, name = "Phil", surname = "PorPo", age = 14, weight = 45.22, length = 2.11, type = 2, username = "phil", password = "porpo" });
    }
    public void CreateProfile(string name, string surname, int age, double weight, double length)
    {
        int highestId = 0;
        foreach (var profile in profiles)
        {

            if (profile.id > highestId)
            {
                highestId = profile.id + 1;
            }
        }
        profiles.Add(new Profile { id = highestId, name = name, surname = surname, age = age, weight = weight, length = length });
    }
    public void DeleteProfile(int id)
    {

        foreach (var profile in profiles)
        {

            if (profile.id == id)
            {
                profiles.Remove(profile);
                break;
            }
        }

    }
    public void SetProfile(int id, string name, string surname, int age, double weight, double length)
    {

        foreach (var profile in profiles)
        {

            if (profile.id == id)
            {
                profile.name = name;
                profile.surname = surname;
                profile.age = age;
                profile.weight = weight;
                profile.length = length;
                break;

            }
        }
    }
    public void RenderProfile(int id)
    {

        foreach (var profile in profiles)
        {
            if (profile.id == id)
            {
                Console.WriteLine("ID | Name | Surname | Age | Weight | Length | Bmi");
                Console.WriteLine($"{profile.id}  |  {profile.name} | {profile.surname}  |  {profile.age}  |  {profile.weight}  |  {profile.length}  |  {profile.GetBmi(profile.weight, profile.length)}");
                break;
            }
        }
    }

    public void RenderAllProfiles()
    {
        Console.WriteLine("ID | Name | Surname | Age | Weight | Length | Bmi");
        Console.WriteLine("-------------------------------------------------");
        foreach (var profile in profiles)
        {
            Console.WriteLine($"{profile.id}  |  {profile.name} | {profile.surname}  |  {profile.age} | {profile.weight}  |  {profile.length}  | {profile.GetBmi(profile.weight, profile.length)}");
        }
    }
}
