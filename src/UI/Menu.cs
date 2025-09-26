using System;
using System.Collections.Generic;

namespace Baldilands;

public class Menu
{
    public SaveManager SM;
    public DungeonMaster DM;

    public Menu(DungeonMaster DM)
    {
        this.SM = new SaveManager();
        this.DM = DM;
    }

    private string ParseCommand(string Raw)
    {
        Raw = Raw.ToLower();

        if (Raw.Equals("1") || Raw.Equals("new game"))
            return "new game";
        else if (Raw.Equals("2") || Raw.Equals("load game"))
            return "load game";
        else if (Raw.Equals("3") || Raw.Equals("delete save") || Raw.Equals("delete"))
            return "delete";
        else if (Raw.Equals("4") || Raw.Equals("exit"))
            return "exit";
        else
            return "";
    }

    private string ParseTownCommand(string Raw)
    {
        Raw = Raw.ToLower();

        if (Raw.Equals("1") || Raw.Equals("battle"))
            return "battle";
        else if (Raw.Equals("2") || Raw.Equals("shop"))
            return "shop";
        else if (Raw.Equals("3") || Raw.Equals("manage inventory") || Raw.Equals("inventory"))
            return "manage inventory";
        else if (Raw.Equals("4") || Raw.Equals("rest"))
            return "rest";
        else if (Raw.Equals("5") || Raw.Equals("save game") || Raw.Equals("save"))
            return "save game";
        else if (Raw.Equals("6") || Raw.Equals("exit game") || Raw.Equals("exit"))
            return "exit";
        else
            return "";
    }

    private void ShowMonsters(List<string> Monsters)
    {
        Console.WriteLine(
            "Which monster do you want to battle with? (Type ENTER on empty monster to return)\n"
        );
        Console.WriteLine("1. Random\t\t21. Ghost\t\t41. Phoenix");
        for (int i = 2; i <= 16; i++)
        {
            Console.WriteLine(
                "{0}. {3}\t{6}{1}. {4}\t{7}{2}. {5}",
                i,
                i + 20,
                i + 40,
                Monsters[i - 2].Capitalize(),
                Monsters[i + 18].Capitalize(),
                Monsters[i + 38].Capitalize(),
                Monsters[i - 2].Length < 12 ? "\t" : "",
                Monsters[i + 18].Length < 12 ? "\t" : ""
            );
        }
    }

    private string ParseShop(string Raw)
    {
        Raw = Raw.ToLower();

        if (Raw.Equals("1") || Raw.Equals("gold shop") || Raw.Equals("gold"))
            return "gold";
        else if (
            Raw.Equals("2")
            || Raw.Equals("experience shop")
            || Raw.Equals("experience")
            || Raw.Equals("exp")
        )
            return "exp";
        else if (Raw.Equals("3") || Raw.Equals("return"))
            return "return";
        else
            return "";
    }

    public void Town()
    {
        string Input;

        Console.Clear();
        while (true)
        {
            Console.WriteLine("Where do you want to go now?");
            Console.WriteLine("1. Battle");
            Console.WriteLine("2. Shop");
            Console.WriteLine("3. Manage Inventory");
            Console.WriteLine("4. Rest");
            Console.WriteLine("5. Save Game");
            Console.WriteLine("6. Exit Game");

            Input = Console.ReadLine();
            Input = this.ParseTownCommand(Input);

            if (Input.Equals("battle"))
            {
                Console.Clear();
                List<string> Monsters = Initializer.InitMonsters();
                while (true)
                {
                    this.ShowMonsters(Monsters);

                    string Ans = Console.ReadLine();
                    Ans = Ans.ToLower();
                    int Index = new int();
                    int Value = -1;
                    bool Numeric = false;

                    if (Ans.Equals("1") || Ans.Equals("random"))
                    {
                        int d = Dice.Roll(Monsters.Count) - 1;
                        string[] tokens = Monsters[d].Split(' ');
                        string file = String.Join("", tokens);
                        Enemy E = Bestiary.Load(file);
                        BattleController BC = new BattleController(this.DM.Hero, E);
                        BC.Battle();
                        Console.Clear();
                        break;
                    }
                    else if (Ans.Equals(""))
                        break;
                    else
                    {
                        try
                        {
                            Value = Int32.Parse(Ans);
                            Numeric = true;
                        }
                        catch (SystemException)
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid monster\n");
                            Numeric = false;
                        }
                    }

                    if (Numeric)
                        if (Value >= 2 && Value <= Monsters.Count + 1)
                            Index = Value - 2;
                        else
                            Index = Monsters.BinarySearch(Ans);
                    else
                        Index = Monsters.BinarySearch(Ans);

                    if (Index < 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid monster\n");
                    }
                    else
                    {
                        string[] tokens = Monsters[Index].Split(' ');
                        string file = String.Join("", tokens);
                        Enemy E = Bestiary.Load(file);
                        BattleController BC = new BattleController(this.DM.Hero, E);
                        BC.Battle();
                        Console.Clear();
                        break;
                    }
                }
            }
            else if (Input.Equals("shop"))
            {
                string Market;

                Console.Clear();
                while (true)
                {
                    Console.WriteLine("Which shop do you want to visit?");
                    Console.WriteLine("1. Gold Shop");
                    Console.WriteLine("2. Experience Shop");
                    Console.WriteLine("3. Return");

                    Market = Console.ReadLine();
                    Market = this.ParseShop(Market);

                    if (Market.Equals("gold"))
                    {
                        Market MK = new Market(this.DM.Hero);
                        MK.Shop();
                        Console.Clear();
                    }
                    else if (Market.Equals("exp"))
                    {
                        ExpMarket EM = new ExpMarket(this.DM.Hero);
                        EM.Shop();
                        Console.Clear();
                    }
                    else if (Market.Equals("return"))
                    {
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid shop\n");
                    }
                }
            }
            else if (Input.Equals("manage inventory"))
                InventoryController.Manage(this.DM.Hero);
            else if (Input.Equals("rest"))
            {
                this.DM.Hero.Rest();
                Console.Clear();
                Console.WriteLine("You are fully replenished\n");
            }
            else if (Input.Equals("save game"))
            {
                Console.Clear();
                if (this.SM.SaveGame(this.DM.Hero, this.SM.CurrentSlot))
                    Console.WriteLine("Game saved!\n");
                else
                    Console.WriteLine("Error! Could not save game\n");
            }
            else if (Input.Equals("exit"))
            {
                Console.Clear();
                return;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid command\n");
            }
        }
    }

    public bool MainMenu()
    {
        string Input;
        Hero H = null;

        Console.Clear();
        while (true)
        {
            Console.WriteLine("+------------+");
            Console.WriteLine("| Baldilands |");
            Console.WriteLine("+------------+\n");
            Console.WriteLine("1. New Game");
            Console.WriteLine("2. Load Game");
            Console.WriteLine("3. Delete Save");
            Console.WriteLine("4. Exit");

            Input = Console.ReadLine();
            Input = this.ParseCommand(Input);

            if (Input.Equals("new game"))
            {
                this.SM.SetSaveSlot();
                if (this.SM.CurrentSlot != -1)
                    H = CharacterCreator.Create();
                else
                {
                    Console.Clear();
                    continue;
                }
            }
            else if (Input.Equals("load game"))
            {
                this.SM.SetLoadSlot();
                if (this.SM.CurrentSlot != -1)
                {
                    H = this.SM.LoadGame(this.SM.CurrentSlot);
                }
                else
                {
                    Console.Clear();
                    continue;
                }
            }
            else if (Input.Equals("delete"))
            {
                Console.Clear();
                this.SM.ClearSlot();
            }
            else if (Input.Equals("exit"))
            {
                Console.Clear();
                return false;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid command\n");
            }
            if (H != null)
            {
                this.DM.Hero = H;
                this.SM.SaveGame(H, this.SM.CurrentSlot);
                return true;
            }
        }
    }
}
