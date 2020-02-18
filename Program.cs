using System;
using System.Collections.Generic;

namespace backendZorgApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Commander commander = new Commander();
        }
    }
    public class Commander
    {

        public Commander()
        {
            ProfileList ProfileListOne = new ProfileList();

        start:
            Console.WriteLine("\n       Input please\n");
            string[] input = Console.ReadLine().Split(" ");

            switch (input[0].ToLower())
            {
                case "help":
                    Console.WriteLine("\nthese are all the methods usable:\n" +
                        "help\n" +
                        "renderprofile, param(int) id  \n" +
                        "setprofile, param (int)id (string)name (string)surname (int)age (double)weight (double)length\n" +
                        "createprofile, param (string)name (string)surname (int)age (double)weight (double)length \n" +
                        "deleteprofile, param (int) id \n" +
                        "Renderall \n" +
                        "clear \n");
                    goto start;
                case "renderprofile":
                    ProfileListOne.RenderProfile(int.Parse(input[1]));
                    goto start;
                case "setprofile":
                    try
                    {
                        ProfileListOne.SetProfile(int.Parse(input[1]), input[2], input[3], int.Parse(input[4]), double.Parse(input[5]), double.Parse(input[6]));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message + "\n");
                        Console.WriteLine("Correct format: (int)id (string)name (string)surname (int)age (double)weight (double)length");
                    }

                    goto start;
                case "deleteprofile":
                    try
                    {
                        ProfileListOne.DeleteProfile(int.Parse(input[1]));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message + "\n");
                        Console.WriteLine("Correct format: (int)id");
                    }

                    goto start;
                case "createprofile":
                    try
                    {
                        ProfileListOne.CreateProfile(input[1], input[2], int.Parse(input[3]), double.Parse(input[4]), double.Parse(input[5]));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message + "\n");
                        Console.WriteLine("Correct format: (string)name (string)surname (int)age (double)weight (double)length");
                    }

                    goto start;
                case "renderall":
                    ProfileListOne.RenderAllProfiles();
                    goto start;
                case "clear":
                    Console.Clear();
                    goto start;
                default:
                    Console.WriteLine("\nmethod not found");
                    goto start;
            }
        }
    }
    public class ProfileList
    {
        List<Profile> profiles = new List<Profile>();
        public ProfileList()
        {
            profiles.Add(new Profile { id = 1, name = "Hugh", surname = "Mungu", age = 96, weight = 68.71, length = 1.31 });
            profiles.Add(new Profile { id = 2, name = "Jack", surname = "Mango", age = 56, weight = 78.23, length = 1.81 });
            profiles.Add(new Profile { id = 3, name = "Phil", surname = "PorPo", age = 14, weight = 45.22, length = 2.11 });
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
                    Console.WriteLine($"{profile.id}  |  {profile.name} | {profile.surname}  |  {profile.age} |  {profile.weight}  |  {profile.length}  |  {profile.GetBmi(profile.weight, profile.length)}");
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
                Console.WriteLine($"{profile.id}  | {profile.name} | {profile.surname}  |  {profile.age} |  {profile.weight}  |  {profile.length}  |  {profile.GetBmi(profile.weight, profile.length)}");
            }
        }
    }

    public class Profile
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }
        public double weight { get; set; }
        public double length { get; set; }

        public Profile() { }
        public double GetBmi(double weight, double length)
        {
            return Math.Round(weight / (length * length), 2);
        }

    }


}