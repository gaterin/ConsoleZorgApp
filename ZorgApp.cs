using System;

public class ZorgApp
{

    /*User user = new User();*/
    ProfileList ProfileListOne = new ProfileList();
    public ZorgApp()
    {
        GetAndCheckInputAdmin();
    }

    public void GetAndCheckInputAdmin()
    {

    start:

        Random random = new Random();
        int randomNumber = random.Next(1, 7);
        Console.WriteLine($"\n       \u001b[3{randomNumber}m Input please\n");
        string[] input = Console.ReadLine().Split(" ");
        input[0].ToLower();

        switch (input[0])
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