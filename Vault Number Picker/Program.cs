using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace Vault_Number_Picker
{
    class Program
    {
        static void Title()
        {
            Divider(5, false);
            Console.Write(" --== F A L L O U T   V A U L T   A V A I L A B I L I T Y   T R A C K E R  ==-- ");
            Divider(5, true);
        }

        static void Divider(int z, bool NextLine)
        {
            for (int i = 0; i <= z; i++)
            {
                Console.Write("=");         
            }
            if (NextLine == true)
            {
                Console.Write("\n");
            }
        }

        static void Spacer(int x, List<int> AvailableVaults)
        {
            if (AvailableVaults[x] < 10)
            {
                Console.Write("  ");
            }
            else if (AvailableVaults[x] < 100)
            {
                Console.Write(" ");
            }
            Console.Write(" --  ");
        }

        static int ModReference(int r)
        {
            Console.Write("Already Modded || ");
            string[] Links = File.ReadLines(@"C:\Vault Number Picker\Modded Vaults Links.txt").ToArray();
            Console.Write(Links[r]);
            r++;
            return r;
        }

        static void Startup()
        {
            Console.SetWindowSize(237,63);
            Title();
            Divider(68, true);
            Console.WriteLine("                             Intro");
            Divider(68, true);
            Console.WriteLine("Nocture\n@2023");
            Divider(68, true);
            string Intro = File.ReadAllText(@"C:\Vault Number Picker\Intro.txt");
            Console.WriteLine(Intro);
            Console.ReadLine();
            Console.Clear();
        }

        static void Main(string[] args)
        {
            int x;
            int r = 0;
            int Dummy;
            string Answer = "";
            int Parameters = 120;
            int UsedVaultNum = 0;
            List<int> AvailableVaults = new List<int>();

            int[] Fallout1Vaults = {12,13,15}; // All Vaults in FO
            int[] Fallout2Vaults = {8,13,15}; // All Vaults in FO2
            int[] Fallout3Vaults = {77,87,92,101,106,108,112}; // All Vaults in FO3
            int[] FalloutNVVaults = {3,11,17,19,21,22,34}; // All Vaults in FONV
            int[] Fallout4Vaults = {75,81,88,95,111,114}; // All Vaults in FO4
            int[] Fallout76Vaults = {29,51,63,76,79,94,96}; // All Vaults in FO76

            int[] NonCanonVaults = {0,1,6,10,24,39,65,70,74,100,113,117,120,121};
            int[] OtherVaults = {7,32,33,44,84,109};
            int[] BibleVaults = {27,36,42,43,53,55,56,68,69,77};
            int[] Vaults = {3,8,11,12,13,15,17,19,21,22,29,34,51,63,75,76,77,79,81,87,88,92,94,95,96,101,106,108,111,112,114,118};
            int[] ModdedVaults = {4,24,28,57,61,66,83,89,98,99,104,116,120,139,165,172,273,494,951,1080};

            Startup();

            Title();
            Divider(68, true);
            Console.Write("\nPlease set lowest Vault Number: ");
            try // Makes sure program doesn't crash when invalid input is detected
            {
                x = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("\nERROR: Invalid Input: Setting Min to 0.");
                x = 0;
            }
            
            Console.Write("\nPlease set max Vault number: ");
            try
            {
                Parameters = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("\nERROR: Invalid Input: Setting Max to 122.");
                Parameters = 122;
                Console.ReadLine();
            }
            
            if (x < 0 || Parameters < 0)
            {
                Console.WriteLine("\nERROR: Negative inputs detected: Inversing");
                x = Math.Abs(x);
                Parameters = Math.Abs(Parameters);
                Console.ReadLine();
            }
            if (x > Parameters) // Quality of Life feature. Swaps inputs if x > Parameters
            {
                Console.WriteLine("\nERROR: Min > Max: Swapping Inputs");
                Dummy = x;
                x = Parameters;
                Parameters = Dummy;
            }
            
            Console.ReadLine();
            Console.Clear();
            
            while (Answer != "y" || Answer != "n")
            {
                r = 0;
                Console.Clear();
                Title();
                Divider(68, true);
                try
                {
                    Console.Write("\nDo you want to only list Non-Canon/Unused Vault Numbers?: y/n ");
                    Answer = Console.ReadLine();
                }
                catch
                {
                    Console.WriteLine("\nERROR: Invalid Input: Setting Answer to y");
                    Answer = "y";
                    Console.ReadLine();
                }
                Console.Clear();

                Title();
                Divider(138, true);
                Console.WriteLine("|| Name     |  | Status                             ||    FO   ||    FO2    ||    FO3    ||    FONV           ||    FO4    ||    FO76    ||");
                Divider(138, true);
                if (Answer == "y")
                {
                    while (x <= Parameters)
                    {
                        if (Vaults.Contains(x) != true && OtherVaults.Contains(x) != true)
                        {
                            AvailableVaults.Add(x);
                        }
                        x++;
                    }
                    x = 0;
                    while (x < AvailableVaults.Count)
                    {
                        Console.Write("|| Vault " + AvailableVaults[x]);
                        Spacer(x, AvailableVaults);
                        if (ModdedVaults.Contains(AvailableVaults[x]) == true)
                        {
                            r = ModReference(r);
                            UsedVaultNum++;
                        }
                        else
                        {
                            Console.Write("Available                          ||         ||           ||           ||                   ||           ||            ||");
                        }
                        Console.Write("\n");
                        x++;
                    }
                    r = 0;
                }
                else if (Answer == "n")
                {
                    while (x <= Parameters)
                    {
                        AvailableVaults.Add(x);
                        x++;
                    }
                    x = 0;
                    while (x < AvailableVaults.Count)
                    {
                        bool IsModded = false;
                        Console.Write("|| Vault " + AvailableVaults[x]);
                        Spacer(x, AvailableVaults);
                        if (Vaults.Contains(x)) //Canon Vaults that already exist in Fallout
                        {
                            Console.Write("Canon               ");
                            UsedVaultNum++;
                        }
                        else if (OtherVaults.Contains(x)) //Vaults that have or will appear in other canon Fallout media
                        {
                            Console.Write("Other Canon Property");
                            UsedVaultNum++;
                        }
                        else if (BibleVaults.Contains(x)) //Vaults mentioned in the Fallout Bible
                        {
                            Console.Write("Fallout Bible       ");
                        }
                        else if (ModdedVaults.Contains(x) == true) //Vaults that have been created by Modders already
                        {
                            r = ModReference(r);
                            IsModded = true;
                            UsedVaultNum++;
                        }
                        else if (NonCanonVaults.Contains(x)) //Mods considered by Bethesda, but were eventually cut for whatever reason
                        {
                            Console.Write("Non-Canon           ");
                        }
                        else //Only if Available
                        {
                            Console.Write("Available           ");
                        }
                        
                        if (IsModded == false)
                        {
                            Console.Write("               ||");
                            if (Fallout1Vaults.Contains(x))
                            {
                                Console.Write(" Fallout ||");
                            }
                            else
                            {
                                Console.Write("         ||");
                            }
                            if (Fallout2Vaults.Contains(x))
                            {
                                Console.Write(" Fallout 2 ||");
                            }
                            else
                            {
                                Console.Write("           ||");
                            }
                            if (Fallout3Vaults.Contains(x))
                            {
                                Console.Write(" Fallout 3 ||");
                            }
                            else
                            {
                                Console.Write("           ||");
                            }
                            if (FalloutNVVaults.Contains(x))
                            {
                                Console.Write(" Fallout New Vegas ||");
                            }
                            else
                            {
                                Console.Write("                   ||");
                            }
                            if (Fallout4Vaults.Contains(x))
                            {
                                Console.Write(" Fallout 4 ||");
                            }
                            else
                            {
                                Console.Write("           ||");
                            }
                            if (Fallout76Vaults.Contains(x))
                            {
                                Console.Write(" Fallout 76 ||");
                            }
                            else
                            {
                                Console.Write("            ||");
                            }
                        }
                        Console.Write("\n");
                        x++;
                    }
                }
                Divider(138, true);
                Console.WriteLine("\n There are {0} Unused Vaults in this range", (Parameters - x) - UsedVaultNum);
                Console.WriteLine("\nPress [ENTER] to Close");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }
    }
}
