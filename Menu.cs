using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace discord.nuke.net
{
    public class Menu
    {
        public static List<string> Menus = new List<string>();
        public static List<int> selectedMenus = new List<int>();
        public static int selected = 0;
        public static void AddMenu()
        {
            
            Menus.Clear();
            selectedMenus.Clear();
            selected = 0;
            
            Menus.Add("Delete Channels");
            Menus.Add("Kick Users");
            Menus.Add("Delete All Roles");
            Menus.Add("Nuke server");
            PrintMenu(selectedMenus);
        }

        public static Boolean printSelectedMenus(List<int> selectedMenus, int id)
        {
            for (int i = 0; i < selectedMenus.Count; i++)
            {
                if (selectedMenus[i] == id)
                {
                    return true;
                }
            }
            return false;
        }
        public static void PrintMenu(List<int> selectedMenus)
        {
            Console.Clear();
            
            Console.WriteLine("Move: UpArrow / DownArrow | Select: Enter. If you done select then just press 'Z'");
            
            Console.WriteLine();
            
            if (selectedMenus.Count > 0)
            {
                for (int i = 0; i < Menus.Count; i++)
                {
                    Boolean _selected = printSelectedMenus(selectedMenus, i);
                    if (_selected)
                    {
                        if (selected == i)
                        {
                            Console.WriteLine($">> [ X ]: {Menus[i]}");
                        }
                        else
                        {
                            Console.WriteLine($"[ X ]: {Menus[i]}");
                        }
                    }
                    else
                    {
                        if (selected == i)
                        {
                            Console.WriteLine($">> [   ]: {Menus[i]}");
                        }
                        else
                        {
                            Console.WriteLine($"[   ]: {Menus[i]}");
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < Menus.Count; i++)
                {
                    if (i == selected)
                    {
                        Console.WriteLine($">> [   ]: {Menus[i]}");
                    }
                    else
                    {
                        Console.WriteLine($"[   ]: {Menus[i]}");
                    }
                }
            }
            
            
            moveInMenu();
            
        }

        public static void moveInMenu()
        {

            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        if ((selected + 1) == Menus.Count) return;
                        selected++;
                        PrintMenu(selectedMenus);
                        break;
                    case ConsoleKey.UpArrow:
                        if ((selected - 1) < 0) return;
                        selected--;
                        PrintMenu(selectedMenus);
                        break;
                    case ConsoleKey.Enter:
                        selectedMenus.Add(selected);
                        manageSelecting();
                        break;
                    case ConsoleKey.Z:
                        Program.start(selectedMenus, Menus);
                        break;
                }

            } while (key.Key != ConsoleKey.Escape);
        }

        public static void manageSelecting()
        {
            pickSelect();
            nukeOption();
            PrintMenu(selectedMenus);

        }

        public static void pickSelect()
        {
            List<int> selectedCopy = new List<int>();
            for (int i = 0; i < selectedMenus.Count; i++)
            {
                if (!selectedCopy.Contains(selectedMenus[i]))
                {
                    selectedCopy.Add(selectedMenus[i]);
                }
            }
            
            for (int i = 0; i < selectedCopy.Count; i++)
            {
                int count = 0;
                for (int k = 0; k < selectedMenus.Count; k++)
                {
                    if (selectedMenus[k] == selectedCopy[i])
                    {
                        count++;
                    }
                }

                if (count > 1)
                {
                    for (int j = 0; j < count; j++)
                    {
                        selectedMenus.Remove(selectedCopy[i]);
                    }
                }
                
            }
            

        }

        public static void nukeOption()
        {
            for (int i = 0; i < selectedMenus.Count; i++)
            {
                if (selectedMenus[i] == 3)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        selectedMenus.Remove(k);
                    }
                    selectedMenus.Add(3);

                    break;

                }

            }
            
            
        }
        
        public static void RenderMenu()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            AddMenu();
            
        }
        
    }
}