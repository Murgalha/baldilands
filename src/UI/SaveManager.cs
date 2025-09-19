using System;
using System.IO;

namespace Baldilands;

public class SaveManager {
    private SaveExpert _saveExpert;

    public int MaxSlots { get; }
    public int CurrentSlot { get; private set; }

    public SaveManager() {
        MaxSlots = 20;
        CurrentSlot = -1;
        _saveExpert = new SaveExpert();
    }

    public void SetLoadSlot() {
        string Num;
        int Value;

        Console.Clear();
        while (true) {
            Console.WriteLine(
                "Which slot would you like to load? (Type ENTER on empty slot to return)");
            PrintSaveSlots();

            Num = Console.ReadLine();
            if (Num.Equals(""))
                return;
            try {
                Value = Int32.Parse(Num);
            } catch (FormatException) {
                Console.Clear();
                Console.WriteLine("Invalid slot number\n");
                continue;
            }
            if (Value < 1 || Value > MaxSlots) {
                Console.Clear();
                Console.WriteLine("Invalid slot number\n");
                continue;
            }
            if (File.Exists(_saveExpert.GetSlotPath(Value))) {
                CurrentSlot = Value;
                return;
            } else {
                Console.Clear();
                Console.WriteLine("Empty slot\n");
                continue;
            }
        }
    }

    public int SetSaveSlot() {
        string Num;
        int Value = 0;

        Console.Clear();
        while (true) {
            Console.WriteLine(
                "Which slot do you want to save in? (Type ENTER on empty slot to return)");
            PrintSaveSlots();

            Num = Console.ReadLine();
            if (Num.Equals(""))
                return -1;
            try {
                Value = Int32.Parse(Num);
            } catch (FormatException) {
                Console.Clear();
                Console.WriteLine("Invalid slot number\n");
                continue;
            }
            if (Value < 1 || Value > MaxSlots) {
                Console.Clear();
                Console.WriteLine("Invalid slot number\n");
                continue;
            }
            if (!File.Exists(_saveExpert.GetSlotPath(Value))) {
                CurrentSlot = Value;
                return Value;
            } else {
                Console.Clear();
                string Ans;

                while (true) {
                    Console.WriteLine("This slot is already full");
                    Console.WriteLine("Do you wish to overwrite it?");
                    Console.WriteLine("1. Yes");
                    Console.WriteLine("2. No");

                    Ans = Console.ReadLine();
                    Ans = YesNoInput.Parse(Ans);

                    if (Ans.Equals("yes")) {
                        CurrentSlot = Value;
                        return Value;
                    } else if (Ans.Equals("no")) {
                        Console.Clear();
                        break;
                    } else {
                        Console.Clear();
                        Console.WriteLine("Invalid command\n");
                    }
                }
            }
        }
    }

    public void ClearSlot() {
        string Num;
        int Value = 0;

        Console.Clear();
        while (true) {
            Console.WriteLine(
                "Which slot would you like to delete? (Type ENTER on empty slot to return)");
            PrintSaveSlots();
            Num = Console.ReadLine();
            if (Num.Equals("")) {
                Console.Clear();
                return;
            }
            try {
                Value = Int32.Parse(Num);
            } catch (FormatException) {
                Console.Clear();
                Console.WriteLine("Invalid slot number\n");
                continue;
            }
            if (Value < 1 || Value > MaxSlots) {
                Console.Clear();
                Console.WriteLine("Invalid slot number\n");
                continue;
            }
            if (File.Exists(_saveExpert.GetSlotPath(Value))) {
                Console.Clear();
                _saveExpert.DeleteGame(Value);
                Console.WriteLine("Slot {0} deleted\n", Value);
            } else {
                Console.Clear();
                Console.WriteLine("Empty slot\n");
            }
        }
    }

    public bool SaveGame(Hero H, int slot) => _saveExpert.SaveGame(H, slot);

    public Hero LoadGame(int slot) => _saveExpert.LoadGame(slot);

    private void PrintSaveSlots() {
        for (int i = 1; i <= MaxSlots; i++) {
            string slotPath = _saveExpert.GetSlotPath(i);
            if (!File.Exists(slotPath))
                Console.WriteLine("> {0} - Empty", i);
            else {
                string displayName = _saveExpert.GetDisplayName(i);

                if (string.IsNullOrEmpty(displayName)) {
                    Console.WriteLine("> {0} - Empty", i);
                } else {
                    Console.WriteLine("> {0} - {1}", i, displayName);
                }
            }
        }
    }
}
