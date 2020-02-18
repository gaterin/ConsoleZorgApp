using System;
using System.Collections.Generic;
using System.Text;


    
    class User
    {
    string type;
    string name;
    string password;
    public User()
    {
       string[] userInput = GetInput();
        bool checkedInput = CheckInput(userInput);
    }

    public string[] GetInput()
    {
       string[] input = Console.ReadLine().Split();

       return input;
    }

    public bool CheckInput(string[] userInput)
    {
        string username = userInput[0];
        string passWord = userInput[1];

        return true;
    }
}

