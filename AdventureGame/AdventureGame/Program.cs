
//Adventure Game 
//Nitya Patel

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    class Program
    {
        private int pos; // player’s current room position
        Player player = new Player();
        static string choosePlayer;
        private const int INVENTORY = -1;

        Room krishaHouse = new Room();
        Room jungle = new Room();
        Room river = new Room();
        Room strangeHouse = new Room();
        Room cave = new Room();
        Room princeKingdom = new Room();
        Room princeHouse = new Room();
        Room[] map = new Room[7];


        public Items[] items = new Items[9]; //array of unknown lenghth

       
        public void intro()
        {
            // Show intro screen and title

            Console.Title = "Adventure Time!!!";
            Console.Read();

            string TitleText = @" 
     ___ __     ___   __   __  __   ___    __    ___  __   __ __  ____     __  ______   ___   ____  _  _
    //   ||    // \\ (( \ (( \ ||  //      ||   ((  \/ ))  || || ||       (( \ | || |  // \\  || \\ \\//    
   ((    ||    ||=||  \\   \\  || ((       ||    \\   //   \\ // ||==      \\    ||   ((   )) ||_//  )/ 
    \\__ ||__| || || \_)) \_)) ||  \\__    ||__|  \\_//     \V/  ||___    \_))   ||    \\_//  || \\ //    ";


            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(TitleText);
          
            Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nThis game is based on a love story where, a girl(player) is finding her prince by going through every single parts of this game and taking risk for her life.");
                
        }

        
        public void howToPlay()
        {
            // Show how to play instructions

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nTo play this game you will need some commands like." +
                "\nN,S,E,W- to go in any direction," + "U-to use one item with something else," + " T- to take ," + "D - drop ," + "C-combine two items and Q- to quit this game. \nClick Enter after every commmend!!");

            Console.ReadLine();
        }

        public void getPlayerName()
        {
            // Ask for player’s name

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\nEnter Player's (girl) Name: ");
            choosePlayer = Console.ReadLine();
 
        }

        public void setUpGame()
        {
            // Set up player and start game

            pos = 0;//start at room 0 
            player.setLoc(pos);
            //set up player
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            player.setName(choosePlayer);
            howToPlay();
            player.setDesc("a 18 year old girl who is finding her prince.");
            
            Console.WriteLine("\nPlayer: " + player.getName());
            Console.WriteLine("Description: " + player.getDesc());

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\nLet's Start!!!");
            Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            makeRoom();


        }

        public void makeRoom()
        {
            // Create rooms and connect them
            krishaHouse.setName(choosePlayer+"'s House");
            jungle.setName("Path of Jungle");
            river.setName("River Bank");
            cave.setName("Cave");
            strangeHouse.setName("Stranger House");
            princeKingdom.setName("Kingdom of Prince");
            princeHouse.setName("House of Prince");

            krishaHouse.setDesc("Old, Small Hut, located in middle of jungle where " + player.getName() +" lives with one old lady who stole her from her parent when she was 5 year old." + 
            "\nHint: You will need something very important to go farther.");
            jungle.setDesc("Dark jungle with little bit of sunlight and a lot of wild animals.");
            river.setDesc("Calm river where animals drink water."+
              "\nHint: Combine somethings"  );
            cave.setDesc("Dark, Rocky cave with lot of small, poisony insects"); 
            strangeHouse.setDesc("a hunted house, where people go in but never comes out because Meet the witch lives their who is hungry for human Blood."+
               "\nHint: Combine!!" );
            princeKingdom.setDesc("Hint: use keys" +
                "it's beautiful and wealthy kingdom where prince lives.");
            princeHouse.setDesc( "This is your destination. You won the Game");

            krishaHouse.setExits(-1, -1, -1, -1);//magic glitter to go jungle (-1, -1, 1, -1)
            jungle.setExits(-1, -1, -1 , 0);//rose to go river (-1,-1,2,0)
            river.setExits(-1, -1, -1, -1); // combine pot and water to go cave(-1,3,-1,1)
            cave.setExits (2, -1, -1, -1);//rock to go starnge house (2, -1, -1, 4)
            strangeHouse.setExits(1, -1, 3, -1);//combine slipper and mirror to go with prince(1,-1, 3, 5)
            princeKingdom.setExits(0, -1, -1, -1);//key to go(0, -1, -1, 6)
            princeHouse.setExits(-1, -1, -1, -1);

            map[0] = krishaHouse;
            map[1] = jungle;
            map[2] = river;
            map[3] = cave;
            map[4] = strangeHouse;
            map[5] = princeKingdom;
            map[6] = princeHouse;

          

        }

        public void look()
        {
            // Show current location and status
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Location: " + map[player.getLoc()].getName());
            Console.WriteLine("\nDescription: " + map[player.getLoc()].getDesc());
            Console.WriteLine();

            win();
            showInventory();
            checkForItem();
            askForCommand();
        }

        public void win()
        {
            // Check win condition
            if (pos.Equals(6))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string goodjob = @"  
   ___                       _                 _           _         _    
  / __|    ___     ___    __| |     o O O   _ | |   ___   | |__     | |   
 | (_ |   / _ \   / _ \  / _` |    o       | || |  / _ \  | '_ \    |_|   
  \___|   \___/   \___/  \__,_|   TS__[O]  _\__/   \___/  |_.__/    (_)  
                    ";

                Console.WriteLine(goodjob);
                Console.WriteLine("Great, Thanks for playing!");

                for (int i = 0; i < items.Length; i++)
                {
                    
                    if (pos.Equals(6))
                    {
                        items[i].setLoc(0);
                    }

                }

            }
            
        }

        public void setUpItem()
        {
            // Create and place all items

            items[0] = new Items();
            items[0].setName("Sand");
            items[0].setDesc("goldeny Glitter");
            items[0].setLoc(INVENTORY);

            items[1] = new Items();
            items[1].setName("Key");
            items[1].setDesc("golden & old (key is from her old parents)." +
                " Hint: You will need this");
            items[1].setLoc(0);

            items[2] = new Items();
            items[2].setName("Rose");
            items[2].setDesc("rose is little abnormal than other flower, it is shiny, red & bright. ");
            items[2].setLoc(1);

            items[3] = new Items();
            items[3].setName("Water");
            items[3].setDesc("river's drinkable water.");
            items[3].setLoc(2);

            items[4] = new Items();
            items[4].setName("Pot");
            items[4].setDesc("black & old pot.");
            items[4].setLoc(2);

            items[5] = new Items();
            items[5].setName("Rock");
            items[5].setDesc("a perfect transperent rock.");
            items[5].setLoc(3);

            items[6] = new Items();
            items[6].setName("Dimond");
            items[6].setDesc("a shiny dimond that is magical & that gone help you to get out of this place." +
                " Hint: use it with mirror");
            items[6].setLoc(4);

            items[7] = new Items();
            items[7].setName("Mirror");
            items[7].setDesc("it can help you to get out of this place.");
            items[7].setLoc(4);

            items[8] = new Items();
            items[8].setName("Door");
            items[8].setDesc("a door you have to open to see prince." +
                " Hint: You have something to use");
            items[8].setLoc(5);

            for (int i = 0; i < items.Length; i++)
                items[i].setName(items[i].getName().ToUpper());


        }

        public void showInventory()
        {
            // Display inventory items

            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].getLoc() == INVENTORY)
                {
                    Console.WriteLine("The Items that You Have in your pocket is " + items[i].getName() + " - " + items[i].getDesc());
                }
               

            }
            
        }

        public void checkForItem()
        {
            // Show items in current room
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].getLoc() == player.getLoc())
                {
                    Console.WriteLine("Items that are here: " + items[i].getName() + "->" + items[i].getDesc());
                }
                
            }
            
        }

        public void combine(String item1, String item2)
        {
            // Combine two items
            item1 = item1.ToUpper();
            item2 = item2.ToUpper();

            switch(item1)
            {
                case "POT":
                    {
                       if(item2.Equals("WATER"))
                       {
                            if(pos==2)
                            {
                               
                                Console.WriteLine("Now you can move to south!!");
                                river.setExits(-1, 3, -1, 1);
                                
                            }
                       }
                    }
                    break;

                case "WATER":
                    {
                        if (item2.Equals("POT"))
                        {
                            if (pos == 2)
                            {

                                Console.WriteLine("Now you can move south!!");
                                river.setExits(-1, 3, -1, 1);

                            }
                        }
                    }
                    break;

               
            }


        }

        public void use(String item1, String item2)
        {
            // Use one item with another
            item1 = item1.ToUpper();
            item2 = item2.ToUpper();

            switch (item1)
            {
                case "KEY":
                    {
                        if (item2.Equals("DOOR"))
                        {
                            if (pos == 5)
                            {
                                Console.WriteLine("Now you can meet your prince.");
                                princeKingdom.setExits(0, 6, 6, 6);
                            }
                        }
                    }
                    break;

                case "DIMOND":
                    {
                        if (item2.Equals("MIRROR"))
                        {
                            if (pos == 4)
                            {
                                Console.WriteLine("Now you have door that teleport to the prince kingdom.");
                                strangeHouse.setExits(-1, 5, 5, 5);
                            }
                        }
                    }
                    break;
            }
        }

        public void dropItem(String s)
        {
            // Drop item from inventory

            Console.ForegroundColor = ConsoleColor.Magenta;
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].getName().ToUpper().Equals(s))
                    if (items[i].getLoc() == INVENTORY)
                    {
                        items[i].setLoc(pos);
                        Console.WriteLine("You dropped the " + s + "!");
                    }
            }
            askForCommand();
        }

        public void takeItem(String s)
        {
            // Take item from room

            Console.ForegroundColor = ConsoleColor.Magenta;
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].getName().ToUpper().Equals(s))
                    if (items[i].getLoc() == pos)
                    {
                        items[i].setLoc(INVENTORY);
                        Console.WriteLine("You took the " + s + "!");
                    }
                    else Console.WriteLine("No......");
            }
            askForCommand();

        }

        public void move(String dir)
        {
            // Move to another room
            if (items[0].getLoc() == INVENTORY)
            {
                krishaHouse.setExits(-1, -1, 1, -1);
                //Console.WriteLine("Now you can move to east!!");
            }
            if (items[2].getLoc() == INVENTORY && items[0].getLoc() != INVENTORY)
            
            {
                jungle.setExits(-1, -1, 2, 0);
                //Console.WriteLine("Now you can move to next destiny.");
            }
           
            if (items[5].getLoc()==INVENTORY)
           {
                cave.setExits(2, -1, -1, 4);
                //Console.WriteLine("Now you can move to the west.");
            }

            Console.ForegroundColor = ConsoleColor.Red;
            int newRoom = -1;
            switch (dir)
            {
                case "N": newRoom = map[pos].getNorth(); break;
                case "S": newRoom = map[pos].getSouth(); break;
                case "E": newRoom = map[pos].getEast(); break;
                case "W": newRoom = map[pos].getWest(); break;
                default: Console.Write("you are stuck!!"); break;
            }
            
            if (newRoom != -1)
            {
                pos = newRoom;
                player.setLoc(pos);
            }
            else
            {
                Console.WriteLine("you can't go there, that's wrong");
            }
            look();

            askForCommand();
        }

        public void doCommand(String[] s)
        {
            // Handle player commands
            Console.ForegroundColor = ConsoleColor.Red;
            switch (s[0])
            {
                case ("N"):
                case ("S"):
                case ("E"):
                case ("W"): move(s[0]); break;
                case ("L"): look(); break;
                case ("T"): takeItem(s[1]); break;
                case ("D"): dropItem(s[1]); break;
                case ("C"): combine(s[1],s[2]);break;
                case ("U"): use(s[1], s[2]);break;
                case ("Q"): quitGame(); break;
                default: Console.WriteLine("You can't do that, BRO!!"); break;
            }
            
        }

        public void askForCommand()
        {
            // Ask for user command input
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nWhat you want to do next?:  ");
            string command = Console.ReadLine().ToUpper();
            String[] commandList = command.Split(' ');

            doCommand(commandList);
        }

        public void quitGame()
        {
            // Quit game and exit
            Console.ForegroundColor = ConsoleColor.Red;
            string goodBye = @"
  __  _   _   _     _       _      __  _  _        _              __   _  ___           
 /__ / \ / \ | \   |_) \_/ |_ |   (_  |_ |_   \_/ / \ | |    /\  /__  /\   |  |\ |       
 \_| \_/ \_/ |_/   |_)  |  |_ o   __) |_ |_    |  \_/ |_|   /--\ \_| /--\ _|_ | \| o o o 
                                                                                         ";
            Console.WriteLine(goodBye);
            Console.ReadKey();
            Environment.Exit(0);
        }
       
        static void Main(string[] args)
        {
            // Main entry point
            Program game = new Program();
            game.intro();

            game.getPlayerName();
            game.setUpGame ();
            game.setUpItem();
            game.look();

            game.askForCommand();

        
        }
    }
}
