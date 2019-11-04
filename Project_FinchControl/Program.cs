using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;

namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Finch Control
    // Description: 
    // Application Type: Console
    // Author: Michelle Vanwettere
    // Dated Created: October 2nd, 2019
    // Last Modified: November 2nd, 2019
    //
    // **************************************************

    class Program
    {

        public enum Command
        {
            NONE,
            MOVEFORWARD,
            MOVEBACKWARD,
            STOPMOTORS,
            WAIT,
            TURNRIGHT,
            TURNLEFT,
            LEDON,
            LEDOFF,
            ALL,
            TEMPERATURE,
            LIGHTVALUE,
            TONE,
            DONE
        }

        private static object finchRobot;
        /// <summary>
        /// main method
        /// </summary>
        static void Main(string[] args)
        {
            (ConsoleColor backgroundColor, ConsoleColor foregroundColor) theme;

            theme = ReadTheme();
            SetTheme(theme.backgroundColor, theme.foregroundColor);

            DisplayChangeTheme();
            
            DisplayWelcomeScreen();

            DisplayMainMenu();
        }
        #region theme
        /// <summary>
        /// apply changes made in the user programming 
        /// </summary>

        static void SetTheme(ConsoleColor backgroundColor, ConsoleColor foregroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
        }
        /// <summary>
        /// write the theme to the theme.txt file
        /// </summary>
        static void WriteTheme(ConsoleColor backgroundColor, ConsoleColor foregroundColor, string dataPath)
        {
            Console.WriteLine("Ready to write to the data file.");

            DisplayContinuePrompt();

            File.WriteAllText(dataPath, backgroundColor.ToString());
            File.AppendAllText(dataPath, foregroundColor.ToString());
        }
        /// <summary>
        /// read the theme from the theme.txt file
        /// </summary>
        static (ConsoleColor backgroundColor, ConsoleColor foregroundColor) ReadTheme()
        {
            string dataPath = @"Data\Theme.txt";
            string[] theme;
            ConsoleColor foregroundColor;
            ConsoleColor backgroundColor;

            DisplayScreenHeader("Read Colors from Data File");

            Console.WriteLine("Ready to read colors from the data file.");
            Console.WriteLine();

            DisplayContinuePrompt();

            theme = File.ReadAllLines(dataPath);
            Enum.TryParse(theme[0], out backgroundColor);
            Enum.TryParse(theme[1], out foregroundColor);
            Console.WriteLine();
            Console.WriteLine("Colors read from data file.");

            DisplayContinuePrompt();

            return (backgroundColor, foregroundColor);
        }

        /// <summary>
        /// let the user change the theme
        /// </summary>
        static void DisplayChangeTheme()
        {
            string userResponse;
            string background;
            string dataPath = @"Data\Theme/txt";

            DisplayScreenHeader("Set theme for the app.");
            Console.WriteLine("Would you like to change the theme?");
            userResponse = Console.ReadLine();

            if (userResponse == "yes")
            {
                Console.WriteLine("What color would you like as the background color?");
                Console.WriteLine("Please choose between red, blue or white.");
                background = Console.ReadLine();

                if (background == "red")
                {

                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Clear();
                    Console.WriteLine("Background color has been changed to red. Is this the color you want?");
                    userResponse = Console.ReadLine();
                    if (userResponse == "yes")
                    { Console.WriteLine("This setting will be saved."); }
                    else if (userResponse == "no")
                    {
                        Console.WriteLine("No problem, we will just start over. Press any key to continue");
                        Console.ReadKey();
                        DisplayChangeTheme();
                    }
                    else
                    {
                        Console.WriteLine("This is not a valid option. Please choose either yes or no.");
                        DisplayContinuePrompt();
                        DisplayChangeTheme();
                    }
                }
                else if (background == "blue")
                {

                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Clear();
                    Console.WriteLine("Background color has been changed to blue. Is this the color you want?");
                    userResponse = Console.ReadLine();
                    if (userResponse == "yes")
                    { Console.WriteLine("This setting will be saved."); }
                    else if (userResponse == "no")
                    {
                        Console.WriteLine("No problem, we will just start over.");
                        DisplayContinuePrompt();
                        DisplayChangeTheme();
                    }
                    else
                    {
                        Console.WriteLine("This is not a valid option. Please choose either yes or no.");
                        DisplayContinuePrompt();
                        DisplayChangeTheme();
                    }
                }
                else if (background == "white")
                {

                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Clear();
                    Console.WriteLine("Background color has been changed to white. Is this the color you want?");
                    userResponse = Console.ReadLine();
                    if (userResponse == "yes")
                    { Console.WriteLine("This setting will be saved."); }
                    else if (userResponse == "no")
                    {
                        Console.WriteLine("No problem, we will just start over.");
                        DisplayContinuePrompt();
                        DisplayChangeTheme();
                    }
                    else
                    {
                        Console.WriteLine("This is not a valid option. Please choose either yes or no.");
                        DisplayContinuePrompt();
                        DisplayChangeTheme();
                    }
                }
                else
                {
                    Console.WriteLine("Sorry, this is not a valid option. Please choose either red, blue or white.");
                    DisplayContinuePrompt();
                    DisplayChangeTheme();

                }
            }
            else if (userResponse == "no")
            {
                Console.WriteLine("Let's get straight to the app!");
                DisplayContinuePrompt();
            }
            else
            {
                Console.WriteLine("This is not a valid option. Please choose either yes or no.");
                DisplayContinuePrompt();
                DisplayChangeTheme();
            }
                    }
        #endregion
        #region TALENT SHOW
        /// <summary>
        /// plays song can't help falling in love and lights up in different colors
        /// </summary>
        static void SongAndLights(Finch finchRobot)
        {
            finchRobot.setLED(255, 0, 0);
            finchRobot.noteOn(587);
            finchRobot.wait(1000);
            finchRobot.noteOn(880);
            finchRobot.wait(1000);
            finchRobot.noteOn(587);
            finchRobot.wait(1000);
            finchRobot.setLED(0, 255, 0);
            finchRobot.noteOn(659);
            finchRobot.wait(500);
            finchRobot.noteOn(698);
            finchRobot.wait(500);
            finchRobot.noteOn(784);
            finchRobot.wait(1000);
            finchRobot.noteOn(698);
            finchRobot.wait(1000);
            finchRobot.noteOn(659);
            finchRobot.wait(1000);
            finchRobot.setLED(0, 0, 255);
            finchRobot.noteOn(349);
            finchRobot.wait(500);
            finchRobot.noteOn(382);
            finchRobot.wait(1000);
            finchRobot.noteOn(523);
            finchRobot.wait(1000);
            finchRobot.noteOn(587);
            finchRobot.wait(1000);
            finchRobot.noteOn(659);
            finchRobot.wait(750);
            finchRobot.noteOn(698);
            finchRobot.wait(750);
            finchRobot.noteOn(784);
            finchRobot.wait(750);
            finchRobot.setLED(250, 250, 250);
            finchRobot.noteOn(698);
            finchRobot.wait(1000);
            finchRobot.noteOn(659);
            finchRobot.wait(1000);
            finchRobot.noteOn(587);
            finchRobot.wait(1000);
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);
        }
        /// <summary>
        /// plays song father jack
        /// </summary>
        /// <param name="finchRobot"></param>
        static void PlaySong(Finch finchRobot)
        {
            finchRobot.noteOn(523);
            finchRobot.wait(500);
            finchRobot.noteOn(587);
            finchRobot.wait(500);
            finchRobot.noteOn(659);
            finchRobot.wait(500);
            finchRobot.noteOn(523);
            finchRobot.wait(1000);
            finchRobot.noteOn(523);
            finchRobot.wait(500);
            finchRobot.noteOn(587);
            finchRobot.wait(500);
            finchRobot.noteOn(659);
            finchRobot.wait(500);
            finchRobot.noteOn(523);
            finchRobot.wait(1000);
            finchRobot.noteOn(659);
            finchRobot.wait(500);
            finchRobot.noteOn(698);
            finchRobot.wait(500);
            finchRobot.noteOn(784);
            finchRobot.wait(1000);
            finchRobot.noteOn(659);
            finchRobot.wait(500);
            finchRobot.noteOn(698);
            finchRobot.wait(500);
            finchRobot.noteOn(784);
            finchRobot.wait(1000);
            finchRobot.noteOn(784);
            finchRobot.wait(200);
            finchRobot.noteOn(880);
            finchRobot.wait(200);
            finchRobot.noteOn(784);
            finchRobot.wait(200);
            finchRobot.noteOn(698);
            finchRobot.wait(500);
            finchRobot.noteOn(659);
            finchRobot.wait(500);
            finchRobot.noteOn(525);
            finchRobot.wait(1000);
            finchRobot.noteOn(784);
            finchRobot.wait(200);
            finchRobot.noteOn(880);
            finchRobot.wait(200);
            finchRobot.noteOn(784);
            finchRobot.wait(200);
            finchRobot.noteOn(698);
            finchRobot.wait(500);
            finchRobot.noteOn(659);
            finchRobot.wait(500);
            finchRobot.noteOn(525);
            finchRobot.wait(1000);
            finchRobot.noteOn(525);
            finchRobot.wait(500);
            finchRobot.noteOn(525);
            finchRobot.wait(349);
            finchRobot.noteOn(525);
            finchRobot.wait(500);
            finchRobot.noteOff();
        }
        /// <summary>
        ///  flashes lights in different colors based on user input
        /// </summary>
        static void FlashRobotLights(Finch finchRobot)
        {
            string color;

            Console.WriteLine("What color do you like best?");
            Console.WriteLine("Red");
            Console.WriteLine("Green");
            Console.WriteLine("Blue");
            color = Console.ReadLine();

            for (int i = 0; i < 5; i++)
            {

                if (color == "red")
                {
                    finchRobot.setLED(255, 0, 0);
                    finchRobot.wait(1000);
                    finchRobot.setLED(0, 0, 0);
                    finchRobot.wait(500);
                }
                else if (color == "green")
                {
                    finchRobot.setLED(0, 255, 0);
                    finchRobot.wait(1000);
                    finchRobot.setLED(0, 0, 0);
                    finchRobot.wait(500);
                }
                else if (color == "blue")
                {
                    finchRobot.setLED(0, 0, 255);
                    finchRobot.wait(1000);
                    finchRobot.setLED(0, 0, 0);
                    finchRobot.wait(500);
                }
                else
                {
                    Console.WriteLine($"Sorry, {color} is not available right now. Please choose a valid option.");
                }
            }
        }
        /// <summary>
        /// lights up in different colors
        /// </summary>
        static void LightUpRobot(Finch finchRobot)
        {
            string color;

            Console.WriteLine("What color do you like best?");
            Console.WriteLine("Red");
            Console.WriteLine("Green");
            Console.WriteLine("Blue");
            color = Console.ReadLine();

            if (color == "red")
            {
                finchRobot.setLED(255, 0, 0);
            }
            else if (color == "green")
            {
                finchRobot.setLED(0, 255, 0);
            }
            else if (color == "blue")
            {
                finchRobot.setLED(0, 0, 255);
            }
            else
            {
                Console.WriteLine($"Sorry, {color} is not an option right now. Please choose a valid option");
            }
        }
        /// <summary>
        /// moves robot in different directions based on user input
        /// </summary>

        static void MoveRobot(Finch finchRobot)
        {
            string direction;

            Console.WriteLine("Which way would you like your robot to go?");
            Console.WriteLine("Forward");
            Console.WriteLine("Backwards");
            Console.WriteLine("Turn");
            direction = Console.ReadLine();

            if (direction == "forward")
            {
                finchRobot.setMotors(400, 400);
                finchRobot.wait(1000);
                finchRobot.setMotors(0, 0);
            }
            else if (direction == "backwards")
            {
                finchRobot.setMotors(-255, -255);
                finchRobot.wait(1000);
                finchRobot.setMotors(0, 0);
            }
            else if (direction == "turn")
            {
                finchRobot.setMotors(255, 100);
                finchRobot.wait(1000);
                finchRobot.setMotors(0, 0);
            }
            else
            {
                Console.WriteLine("Please choose a valid option.");
            }
        }
        /// <summary>
        ///  robot plays a tune
        /// </summary>
        static void PlayATune(Finch finchRobot)
        {
            finchRobot.noteOn(500);
            finchRobot.wait(1000);
            finchRobot.noteOff();
        }
        #endregion
        #region MAIN MENU
        /// <summary>
        /// display main menu
        /// </summary>
        static void DisplayMainMenu()
        {
            //
            //instantiate a Finch object
            //
            Finch finchRobot = new Finch();
            bool finchRobotConnected = false;
            bool quitApplication = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Main Menu");
                //
                // get the user's menu choice
                //
                Console.WriteLine("a) Connect Finch Robot");
                Console.WriteLine("b) Talent Show");
                Console.WriteLine("c) Data Recorder");
                Console.WriteLine("d) Alarm System");
                Console.WriteLine("e) User Programming");
                Console.WriteLine("f) Disconnect Finch Robot");
                Console.WriteLine("q) Quit");
                Console.WriteLine("Enter Choice");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user's choice
                //
                switch (menuChoice)
                {
                    case "a":
                        finchRobotConnected = DisplayConnectFinchRobot(finchRobot);
                        break;

                    case "b":
                        if (finchRobotConnected)
                            DisplayTalentShow(finchRobot);
                        break;

                    case "c":
                        DataRecorder(finchRobot);
                        break;

                    case "d":
                        AlarmSystem(finchRobot);
                        break;

                    case "e":
                        UserProgramming(finchRobot);
                        break;

                    case "f":
                        DisplayDisconnectFinchRobot(finchRobot);
                        break;

                    case "q":
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine("\t*****************************************");
                        Console.WriteLine("\tPlease indicate your choice with a letter");
                        Console.WriteLine("\t*****************************************");

                        DisplayContinuePrompt();
                        break;
                }
            }
            while (!quitApplication);

            finchRobot.disConnect();
        }
        /// <summary>
        /// user programming
        /// </summary>
        static void UserProgramming(Finch finchRobot)
        {
            string menuChoice;
            bool quitApplication = false;
            (int motorSpeed, int ledBrightness, int waitSeconds, int toneFrequency) commandParameters;
            commandParameters.motorSpeed = 0;
            commandParameters.ledBrightness = 0;
            commandParameters.waitSeconds = 0;
            commandParameters.toneFrequency = 0;

            List<Command> commands = new List<Command>();

            do
            {
                DisplayScreenHeader("User Programming");
                //
                // get user menu choice
                //
                Console.WriteLine("a) Set Command Parameters");
                Console.WriteLine("b) Add Commands");
                Console.WriteLine("c) View Commands");
                Console.WriteLine("d) Execute Commands");
                Console.WriteLine("e) Save Commands To Text File");
                Console.WriteLine("f) Load Commands From Text File");
                Console.WriteLine("q) Quit");
                Console.WriteLine();
                Console.Write("Enter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //

                switch (menuChoice)
                {
                    case "a":
                        commandParameters = DisplayGetCommandParameters();
                        break;

                    case "b":
                        DisplayGetFinchCommands(commands);
                        break;

                    case "c":
                        DisplayFinchCommands(commands);
                        break;

                    case "d":
                        DisplayExecuteFinchCommands(finchRobot, commands, commandParameters);
                        Console.WriteLine("All commands completed.");
                        break;

                    case "e":
                        DisplayWriteUserProgrammingData(commands);
                        break;

                    case "f":
                        commands = DisplayReadUserProgrammingData();
                        break;

                    case "q":
                        quitApplication = true;
                        break;


                    default:
                        Console.WriteLine();
                        Console.WriteLine("Please enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }
            } while (!quitApplication);
        }
        /// <summary>
        /// read the user's programming
        /// </summary>
        static List<Command> DisplayReadUserProgrammingData()
        {
            string dataPath = @"Data\Data.txt";
            List<Command> commands = new List<Command>();
            string[] commandsString;

            DisplayScreenHeader("Read Commands from Data File");

            Console.WriteLine("Ready to read commands from the data file.");
            Console.WriteLine();


            commandsString = File.ReadAllLines(dataPath);

            Command command;
            foreach (string commandString in commandsString)
            {
                Enum.TryParse(commandString, out command);

                commands.Add(command);
            }

            Console.WriteLine();
            Console.WriteLine("Commands read from data file.");

            DisplayContinuePrompt();

            return commands;
        }
        /// <summary>
        /// write user programming to data.txt
        /// </summary>
        /// <param name="commands"></param>
        static void DisplayWriteUserProgrammingData(List<Command> commands)
        {
            string dataPath = @"Data\Data.txt";
            List<string> commandsString = new List<string>();

            DisplayScreenHeader("Write Commands To Data File");

            // create a list of command strings
            foreach (Command command in commands)
            {
                commandsString.Add(command.ToString());
            }
            Console.WriteLine("Ready to write to the data file.");
            DisplayContinuePrompt();
            File.WriteAllLines(dataPath, commandsString.ToArray());

            Console.WriteLine();
            Console.WriteLine("Commands written to data file.");

            DisplayContinuePrompt();
        }
        /// <summary>
        /// execute user programming
        /// </summary>

        static void DisplayExecuteFinchCommands(
            Finch finchRobot,
            List<Command> commands,
            (int motorSpeed, int ledBrightness, int waitSeconds, int toneFrequency) commandParameters)
        {
            int motorSpeed = commandParameters.motorSpeed;
            int ledBrightness = commandParameters.ledBrightness;
            int waitMilliSeconds = commandParameters.waitSeconds * 1000;
            int toneFrequency = commandParameters.toneFrequency;

            DisplayScreenHeader("Execute Finch Commands");

            // info and pause
            Console.ReadKey();

            foreach (Command command in commands)
            {
                switch (command)
                {
                    case Command.NONE:
                        break;

                    case Command.MOVEFORWARD:
                        finchRobot.setMotors(motorSpeed, motorSpeed);


                        break;

                    case Command.MOVEBACKWARD:
                        finchRobot.setMotors(-motorSpeed, -motorSpeed);
                        Console.WriteLine($"{command}Command completed.");
                        finchRobot.wait(500);
                        break;

                    case Command.STOPMOTORS:
                        finchRobot.setMotors(0, 0);
                        Console.WriteLine($"{command}Command completed.");
                        finchRobot.wait(500);
                        break;

                    case Command.WAIT:
                        finchRobot.wait(waitMilliSeconds);
                        Console.WriteLine($"{command}Command completed.");
                        finchRobot.wait(500);
                        break;

                    case Command.TURNRIGHT:
                        finchRobot.setMotors(-50, motorSpeed);
                        Console.WriteLine($"{command}Command completed.");
                        finchRobot.wait(500);
                        break;

                    case Command.TURNLEFT:
                        finchRobot.setMotors(motorSpeed, 0);
                        Console.WriteLine($"{command}Command completed.");
                        finchRobot.wait(500);
                        break;

                    case Command.LEDON:
                        finchRobot.setLED(ledBrightness, ledBrightness, ledBrightness);
                        Console.WriteLine($"{command}Command completed.");
                        finchRobot.wait(500);
                        break;

                    case Command.LEDOFF:
                        finchRobot.setLED(0, 0, 0);
                        Console.WriteLine($"{command}Command completed.");
                        finchRobot.wait(500);
                        break;

                    case Command.ALL:
                        finchRobot.setMotors(0, 0);
                        finchRobot.setLED(ledBrightness, ledBrightness, ledBrightness);
                        Console.WriteLine($"{command}Command completed.");
                        finchRobot.wait(500);
                        break;

                    case Command.TEMPERATURE:
                        double temperature;
                        temperature = finchRobot.getTemperature();
                        Console.WriteLine($"Current temperature: {temperature}");
                        ConvertCelciusToFahrenheit(temperature);
                        Console.WriteLine($"{command}Command completed.");
                        finchRobot.wait(500);
                        break;

                    case Command.LIGHTVALUE:
                        double lightValue;
                        lightValue = finchRobot.getRightLightSensor();
                        Console.WriteLine($"Current light value:{lightValue}");
                        Console.WriteLine($"{command}Command completed.");
                        finchRobot.wait(500);
                        break;

                    case Command.TONE:
                        finchRobot.noteOn(toneFrequency);
                        Console.WriteLine($"{command}Command completed.");
                        finchRobot.wait(500);
                        break;

                    case Command.DONE:
                        finchRobot.setLED(0, 0, 0);
                        finchRobot.noteOff();
                        finchRobot.setMotors(0, 0);
                        Console.WriteLine("Commands done.");

                        DisplayContinuePrompt();
                        DisplayMainMenu();
                        break;

                    default:
                        Console.WriteLine("Please enter a valid option.");
                        break;
                }
            }
            DisplayContinuePrompt();
        }

        static void DisplayFinchCommands(List<Command> commands)
        {
            DisplayScreenHeader("Finch Robot Commands");

            foreach (Command command in commands)
            {
                Console.WriteLine(command);
            }
            DisplayContinuePrompt();
        }



        static void DisplayGetFinchCommands(List<Command> commands)
        {
            Command command = Command.NONE;
            string userResponse;

            DisplayScreenHeader("Finch Robot Commands");
            Console.WriteLine();
            Console.WriteLine("Please enter commands for the robot. When you are done, please enter DONE. Press any key when you are ready to start programming the robot.");
            Console.ReadKey();
            Console.WriteLine();

            Console.WriteLine("Possible commands:");
            Console.WriteLine();
            Console.WriteLine("NONE");
            Console.WriteLine("MOVEFORWARD");
            Console.WriteLine("MOVEBACKWARD");
            Console.WriteLine("STOPMOTORS");
            Console.WriteLine("WAIT");
            Console.WriteLine("TURNRIGHT");
            Console.WriteLine("TURNLEFT");
            Console.WriteLine("LEDON");
            Console.WriteLine("LEDOFF");
            Console.WriteLine("ALL");
            Console.WriteLine("TEMPERATURE");
            Console.WriteLine("LIGHTVALUE");
            Console.WriteLine("TONE");
            Console.WriteLine("DONE");

            while (command != Command.DONE)
            {
                Console.Write("Enter Command:");
                userResponse = Console.ReadLine().ToUpper();
                Enum.TryParse(userResponse, out command);

                if (command != Command.NONE)
                {
                    commands.Add(command);
                    Console.WriteLine($"{command} has been added to the list of commands.");
                }
            }

            Console.WriteLine("All commands have been added. Please review your programming under View Commands to approve.");

            DisplayContinuePrompt();
        }

        static (int motorSpeed, int ledBrightness, int waitSeconds, int toneFrequency) DisplayGetCommandParameters()
        {
            (int motorSpeed, int ledBrightness, int waitSeconds, int toneFrequency) commandParameters;

            commandParameters.motorSpeed = 0;
            commandParameters.ledBrightness = 0;
            commandParameters.waitSeconds = 0;
            commandParameters.toneFrequency = 0;

            Console.Write("Enter Motor Speed [1 - 255]:");
            commandParameters.motorSpeed = int.Parse(Console.ReadLine());
            if (commandParameters.motorSpeed < 1 || commandParameters.motorSpeed > 255)
            { Console.WriteLine($"{commandParameters.motorSpeed} is not a valid value for motorspeed. Please enter a value between 1 and 255."); }
            else
            {
                Console.WriteLine($"The value you have set is {commandParameters.motorSpeed}");
            }

            Console.Write("Enter LED Brightness [1 - 255]:");
            commandParameters.ledBrightness = int.Parse(Console.ReadLine());
            if (commandParameters.ledBrightness < 1 || commandParameters.ledBrightness > 255)
            { Console.WriteLine($"{commandParameters.ledBrightness} is not a valid value for Led Brightness. Please enter a value between 1 and 255."); }
            else
            {
                Console.WriteLine($"The value you have set is {commandParameters.ledBrightness}");
            }

            Console.Write("Enter Wait in Seconds [1-10]:");
            commandParameters.waitSeconds = int.Parse(Console.ReadLine());
            if (commandParameters.waitSeconds < 1 || commandParameters.waitSeconds > 10)
            { Console.WriteLine("Please enter a value between 1 and 10."); }
            else
            {
                Console.WriteLine($"The value you have set is {commandParameters.waitSeconds}");
            }

            Console.WriteLine("Enter tone frequency [500-1000]");
            commandParameters.toneFrequency = int.Parse(Console.ReadLine());
            if (commandParameters.toneFrequency < 500 || commandParameters.toneFrequency > 1000)
            { Console.WriteLine($"{commandParameters.toneFrequency} is not a valid value for Tone Frequency. Please enter a value between 500 and 1000."); }
            else
            {
                Console.WriteLine($"The value you have set is {commandParameters.toneFrequency}");
            }

            return commandParameters;
        }

        /// <summary>
        /// display alarm system
        /// </summary>
        static void AlarmSystem(Finch finchRobot)
        {
            string alarmType;
            int maxSeconds;
            double threshold;
            double tempThreshold;
            bool thresholdExceeded;
            bool tempTresholeExceeded;

            DisplayScreenHeader("Alarm System");

            Console.WriteLine("The alarm system will monitor light or temperature and let you know when a threshold is exceeded.");
            Console.WriteLine();
            Console.WriteLine("Choose for the light option if you want to check whether anyone passes by the sensor while you are gone.");
            Console.WriteLine("Choose the temperature option if you want to make sure the temperature in the room does not exceed a certain level.");

            DisplayContinuePrompt();

            alarmType = DisplayGetAlarmType();
            maxSeconds = DisplayGetMaxSeconds();
            if (alarmType == "light")
            {
                threshold = DisplayGetThreshold(finchRobot, alarmType);
                Console.WriteLine($"You have chosen to follow up on {alarmType} for {maxSeconds} seconds or until the value of {threshold} is exceeded.");
                DisplayContinuePrompt();

                thresholdExceeded = MonitorCurrentLightLevels(finchRobot, threshold, maxSeconds);
                if (thresholdExceeded)
                {
                    Console.WriteLine();
                    Console.WriteLine("Maximum Light Level Exceeded.");
                }
                else
                {
                    Console.WriteLine("The current light level did not exceed the the threshold. No one passed by the sensor. No worries.");
                }
            }
            else if (alarmType == "temperature")
            {
                tempThreshold = DisplayGetTempThresHold(finchRobot, alarmType);
                Console.WriteLine($"You have chosen to follow up on {alarmType} for {maxSeconds} seconds or until the value of {tempThreshold} is exceeded.");
                DisplayContinuePrompt();

                tempTresholeExceeded = MonitorCurrentTempLevels(finchRobot, tempThreshold, maxSeconds);

                if (tempTresholeExceeded)
                {
                    Console.WriteLine();
                    Console.WriteLine("Maximum Temperature Level Exceeded.");
                }
                else
                {
                    Console.WriteLine("The temperature level did not exceed the threshold, you can chill. :)");
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Maximum Time Exceeded. The temperature did not exceed the threshold.");
            }
            DisplayContinuePrompt();

            finchRobot.setLED(0, 0, 0);
        }
        /// <summary>
        /// monitor the temperature levels
        /// </summary>
        static bool MonitorCurrentTempLevels(Finch finchRobot, double tempThresHold, int maxSeconds)
        {
            bool tempThresHoldExceeded = false;
            double currentTemplevel;
            double seconds = 0;

            finchRobot.setLED(0, 255, 0);

            Console.Clear();
            DisplayScreenHeader("Monitoring current levels.");

            while (!tempThresHoldExceeded && seconds <= maxSeconds)
            {
                currentTemplevel = finchRobot.getTemperature();

                DisplayScreenHeader("Monitor Temperature Levels");
                Console.WriteLine($"Maximum Temperature Level:{tempThresHold}.");
                Console.WriteLine($"Current Temperature Level:{currentTemplevel}.");
                ConvertCelciusToFahrenheit(currentTemplevel);

                if ((currentTemplevel * 9 / 5 + 32) > tempThresHold)
                {
                    finchRobot.setLED(255, 0, 0);
                    finchRobot.noteOn(1000);
                    finchRobot.wait(500);
                    finchRobot.noteOff();
                    tempThresHoldExceeded = true;
                }
                else
                {
                    finchRobot.wait(500);
                    seconds += 0.5;

                }
            }
            return tempThresHoldExceeded;
        }
        /// <summary>
        /// monitor light levels
        /// </summary>
        static bool MonitorCurrentLightLevels(Finch finchRobot, double thresHold, int maxSeconds)
        {
            bool thresHoldExceeded = false;
            int currentLightLevel;
            double seconds = 0;

            Console.Clear();
            while (!thresHoldExceeded && seconds <= maxSeconds)
            {
                finchRobot.setLED(0, 255, 0);
                currentLightLevel = finchRobot.getLeftLightSensor();

                DisplayScreenHeader("Monitor Light Levels");
                Console.WriteLine($"Minimum Light Level:{thresHold}.");
                Console.WriteLine($"Current Light Level:{currentLightLevel}.");


                if (currentLightLevel < thresHold)
                {

                    finchRobot.setLED(255, 0, 0);
                    finchRobot.noteOn(1000);
                    finchRobot.wait(500);
                    finchRobot.noteOff();
                    thresHoldExceeded = true;
                }
                else
                {
                    finchRobot.wait(500);
                    seconds += 0.5;
                }
            }
            return thresHoldExceeded;
        }
        /// <summary>
        /// prompt user about the temperature threshold
        /// </summary>

        static double DisplayGetTempThresHold(Finch finchRobot, string alarmType)
        {
            double celciusTemp;
            double tempThresHold = 0;

            Console.Clear();

            DisplayScreenHeader("Threshold Value for Temperature");

            if (alarmType == "temperature")
            {
                celciusTemp = finchRobot.getTemperature();
                Console.Write($"Current Temperature Level: {celciusTemp}");
                Console.WriteLine();
                ConvertCelciusToFahrenheit(celciusTemp);
                Console.Write("Enter Maximum Temperature Level [60-80]");
                tempThresHold = (double.Parse(Console.ReadLine()));


                if (tempThresHold > 80 || tempThresHold < 60)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{tempThresHold} is not a valid value. Please enter a value between 0 and 255.");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"You have selected a threshold of {tempThresHold}.");
                    Console.WriteLine();
                }
            }
            return tempThresHold;
        }
        /// <summary>
        /// prompt user for light threshold
        /// </summary>

        static double DisplayGetThreshold(Finch finchRobot, string alarmType)
        {
            double thresHold = 0;

            Console.Clear();
            DisplayScreenHeader($"Threshold Value for Light");

            if (alarmType == "light")
            {
                Console.Write($"Current Light Level: {finchRobot.getLeftLightSensor()}");
                Console.WriteLine();
                Console.Write("Enter Maximum Light Level [0-255]");
                thresHold = double.Parse(Console.ReadLine());

                if (thresHold > 255 || thresHold < 0)
                {
                    Console.WriteLine($"{thresHold} is not a valid value. Please enter a value between 0 and 255.");

                    DisplayContinuePrompt();
                    DisplayMainMenu();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"You have selected a threshold of {thresHold}");
                }
            }
            DisplayContinuePrompt();
            return thresHold;
        }
        /// <summary>
        /// prompt the user for the amount of seconds
        /// </summary>


        static int DisplayGetMaxSeconds()
        {
            int maxSeconds;

            Console.Clear();

            DisplayScreenHeader("Maximum Number of Seconds");
            Console.WriteLine("Enter maximum number of seconds.[5-20]");
            maxSeconds = int.Parse(Console.ReadLine());

            if (maxSeconds < 5 || maxSeconds > 20)
            {
                Console.WriteLine();
                Console.WriteLine($"{maxSeconds} is not an option in this case. Please enter a value between 5 and 20.");

                DisplayContinuePrompt();
                DisplayMainMenu();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"You have set the maximum number of seconds to {maxSeconds}.");
            }

            DisplayContinuePrompt();

            return maxSeconds;
        }
        /// <summary>
        /// prompt user for alarm type
        /// </summary>
        static string DisplayGetAlarmType()
        {
            string alarmType;

            Console.Clear();
            DisplayScreenHeader("Alarm Type");
            Console.WriteLine("Enter Alarm Type [light or temperature]:");
            alarmType = Console.ReadLine();

            if (alarmType == "light" || alarmType == "temperature")
            {
                Console.WriteLine();
                Console.WriteLine($"You have selected {alarmType}.");

                DisplayContinuePrompt();

                return alarmType;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"{alarmType} is not a valid option. Please choose between light or temperature.");

                DisplayContinuePrompt();
                DisplayMainMenu();
                return alarmType;
            }
        }

        /// <summary>
        /// data recorder
        /// </summary>
        static void DataRecorder(Finch finchRobot)
        {
            double dataPointFrequency;
            int numberOfDataPoints;
            string lightorTemp;
            DisplayScreenHeader("Finch Data Recorder");

            // give the user some info about what is going on

            Console.WriteLine("The finch robot will now record the data on a few data points that you pick.");

            DisplayContinuePrompt();

            // ask the user if they want to record lights or temperature and how many recording points they want

            lightorTemp = GetLightsOrTemperature();
            dataPointFrequency = DisplayGetDataPointFrequency();
            numberOfDataPoints = DisplayGetDataRecorderNumber();

            double[] temperatures = new double[numberOfDataPoints];
            double[] lights = new double[numberOfDataPoints];

            DisplayGetDataReadings(numberOfDataPoints, dataPointFrequency, lights, temperatures, lightorTemp, finchRobot);

            DisplayDataRecorderData(temperatures, lights, lightorTemp);

            DisplayContinuePrompt();
        }
        /// <summary>
        /// displays data the finch robot collected
        /// </summary>
        static void DisplayGetDataReadings(int numberofDataPoints, double dataPointFrequency, double[] lights, double[] temperatures, string lightorTemp, Finch finchRobot)
        {
            DisplayScreenHeader("Begin recording");

            Console.WriteLine();
            Console.WriteLine("The application is ready to begin recording.");
            DisplayContinuePrompt();

            // give the user info and a prompt

            if (lightorTemp == "temperature")
            {
                DisplayScreenHeader("Get Temperature");

                for (int index = 0; index < numberofDataPoints; index++)
                {
                    temperatures[index] = finchRobot.getTemperature();
                    int miliSeconds = (int)(dataPointFrequency * 1000);
                    finchRobot.wait(miliSeconds);

                    Console.WriteLine($"Temperature in Celsius {index + 1}: {temperatures[index]}");
                    ConvertCelciusToFahrenheit(temperatures[index]);

                    Console.WriteLine("The data recording is complete");
                }
            }

            else if (lightorTemp == "light")
            {
                DisplayScreenHeader("Get Light Value");

                for (int index = 0; index < numberofDataPoints; index++)
                {
                    lights[index] = (finchRobot.getLeftLightSensor() + finchRobot.getRightLightSensor() / 2);
                    int miliSeconds = (int)(dataPointFrequency * 1000);
                    finchRobot.wait(miliSeconds);


                    Console.WriteLine($"Lights {index + 1}: {lights[index]}");





                   
                }
            }

            else
            {
                Console.WriteLine("Data could not be recorded.");
            }
            Console.WriteLine("The data recording is complete");
            DisplayContinuePrompt();

        }
        /// <summary>
        /// asks the user whether they want to measure light or temperatures
        /// </summary>
        static string GetLightsOrTemperature()
        {
            string lightOrTemp;

            DisplayScreenHeader("Lights or Temperatures");
            Console.WriteLine("Would you like to record temperatures or light values?");
            lightOrTemp = Console.ReadLine();

            return lightOrTemp;
        }
        /// <summary>
        /// converts the temperatures in celsius to fahrenheit
        /// </summary>
        static void ConvertCelciusToFahrenheit(double celsiusTemp)
        {
            double fahrenheitTemp;

            fahrenheitTemp = ((celsiusTemp * 9 / 5 + 32));
            Console.WriteLine($"Temperature in Fahrenheit: {fahrenheitTemp}");
            Console.WriteLine();

        }
        /// <summary>
        /// records either light or temperature data based on user input
        /// </summary>

        static void DisplayDataRecorderData(double[] temperatures, double[] lights, string lightorTemp)
        {

            if (lightorTemp == "temperature")
            {
                DisplayScreenHeader("Temperatures");

                for (int index = 0; index < temperatures.Length; index++)
                {
                    Console.WriteLine($"Temperature in Celsius {index + 1}: {temperatures[index]}");

                    ConvertCelciusToFahrenheit(temperatures[index]);
                }
            }
            else if (lightorTemp == "light")
            {
                DisplayScreenHeader("Light");

                for (int index = 0; index < lights.Length; index++)
                {
                    Console.WriteLine($"Lights {index + 1}: {lights[index]}");
                }
            }
        }
        /// <summary>
        /// queries the user for the number of data points
        /// </summary>

        static int DisplayGetDataRecorderNumber()
        {
            int numberOfDataPoints;

            DisplayScreenHeader("Number of Data Points");
            Console.WriteLine("Enter the Number of Data Points");
            int.TryParse(Console.ReadLine(), out numberOfDataPoints);

            Console.WriteLine();
            Console.WriteLine($"The number of data points you picked is {numberOfDataPoints}.");

            DisplayContinuePrompt();

            return numberOfDataPoints;
        }
        /// <summary>
        /// queries the user for data point frequency
        /// </summary>

        static double DisplayGetDataPointFrequency()
        {
            double dataPointFrequency;

            DisplayScreenHeader("Data Point Frequency");

            Console.WriteLine("Enter frequency of recordings");
            double.TryParse(Console.ReadLine(), out dataPointFrequency);

            Console.WriteLine();
            Console.WriteLine($"The frequency of recordings you have chosen is {dataPointFrequency}");

            DisplayContinuePrompt();

            return dataPointFrequency;
        }

        /// <summary>
        /// disconnect the Finch Robot
        /// </summary>
        static void DisplayDisconnectFinchRobot(Finch finchRobot)
        {
            DisplayScreenHeader("Disconnect Finch Robot");
            Console.WriteLine();
            bool finchRobotDisconnected;
            Console.WriteLine("Ready to disconnect Finch Robot. Press any key to continue.");

            DisplayContinuePrompt();

            finchRobot.disConnect();
            finchRobotDisconnected = true;

            if (finchRobotDisconnected)
            {
                finchRobot.setLED(255, 0, 0);
                finchRobot.noteOn(15000);
                finchRobot.wait(1000);
                finchRobot.noteOff();

                Console.WriteLine();
                Console.WriteLine("Finch robot is now disconnected.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Unable to disconnect to the Finch robot");
            }
            DisplayContinuePrompt();
        }
        /// <summary>
        /// display the talent show
        /// </summary>
        static void DisplayTalentShow(Finch finchRobot)
        {
            bool finchRobotConnected = true;
            string showSelect;

            DisplayScreenHeader("Talent Show");
            Console.WriteLine("The Finch robot is ready to show you its talents");
            DisplayContinuePrompt();
            DisplayScreenHeader("Talent Show Menu");

            if (finchRobotConnected == true)
            {
                Console.WriteLine("What would you like the robot to do?");
                Console.WriteLine("a) Play a tone");
                Console.WriteLine("b) Move");
                Console.WriteLine("c) Light up");
                Console.WriteLine("d) Flash lights");
                Console.WriteLine("e) Play a song");
                Console.WriteLine("f) Play music and light up");
                showSelect = Console.ReadLine().ToLower();

                switch (showSelect)
                {
                    case "a":
                        PlayATune(finchRobot);
                        break;

                    case "b":
                        MoveRobot(finchRobot);
                        break;

                    case "c":
                        LightUpRobot(finchRobot);
                        break;

                    case "d":
                        FlashRobotLights(finchRobot);
                        break;

                    case "e":
                        PlaySong(finchRobot);
                        break;

                    case "f":
                        SongAndLights(finchRobot);
                        break;
                    default:
                        Console.WriteLine("Please choose a valid option");
                        DisplayContinuePrompt();
                        break;
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Please return to the main menu and connect the Finch robot");
                DisplayContinuePrompt();
            }

            DisplayContinuePrompt();

            DisplayClosingScreen();
        }

        /// <summary>
        /// display connect Finch Robot
        /// </summary>
        static bool DisplayConnectFinchRobot(Finch finchRobot)
        {
            DisplayScreenHeader("Connect Finch Robot");

            Console.WriteLine();
            bool finchRobotConnected = false;

            DisplayScreenHeader("Connect Finch Robot");

            Console.WriteLine("Ready to connect Finch robot. Please be sure to connect USB cable to both the robot and the computer.");

            DisplayContinuePrompt();

            finchRobotConnected = finchRobot.connect();

            if (finchRobotConnected)
            {
                finchRobot.setLED(0, 255, 0);
                finchRobot.noteOn(15000);
                finchRobot.wait(1000);
                finchRobot.noteOff();

                Console.WriteLine();
                Console.WriteLine("Finch robot is now connected.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Unable to connect to the Finch robot");
            }
            DisplayContinuePrompt();

            return finchRobotConnected;
        }
        /// <summary>
        /// display welcome screen
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFinch Control");
            Console.WriteLine();
            Console.WriteLine("Welcome to Finch Control!");
            Console.WriteLine("You will be using this app to control your Finch Robot");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display closing screen
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using Finch Control!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }
        #endregion


        #region HELPER METHODS

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        #endregion
    }
}