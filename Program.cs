using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;

namespace discord.nuke.net
{
    class Program : Menu
    {

        public static int dataCount = 1;
        public static int currentCount = 0;
        public static Dictionary<ulong, string> Datas = new Dictionary<ulong, string>();
        public static List<string> originalSelected = new List<string>();
        
        private static string token;
        private static ulong guildid;

        public static void startAction()
        {
            string token = (Datas.ElementAt(0).Value);

            var _ = discordManager.MainAsync(token);
            

        }
        public static void collectDatas()
        {
            
            Console.WriteLine("Enter the data count: ");
            
            
            try
            {
                dataCount = Convert.ToInt32(Console.ReadLine());

            }
            catch (Exception e)
            {
                Console.WriteLine("The input got failed. Please correct format. (Int -> Number)");                
            }
            
            Console.Clear();
                
            Console.WriteLine("Enter the guild id: ");

            try
            {
                guildid = Convert.ToUInt64(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("The input got failed. Please correct format. (Int -> Number)");                
            }

            Console.Clear();
                
            Console.WriteLine("Enter the token: ");

            try
            {
                token = Convert.ToString(Console.ReadLine());

            }
            catch (Exception e)
            {
                Console.WriteLine("The input got failed. Please correct format. (String -> Letters)");                
            }

            Datas.Add(
                guildid, token
            );

            
            startAction();


            
        }

        public static void start(List<int> selected, List<string> Menu)
        {
            for (int i = 0; i < selected.Count; i++)
            {
                if (!originalSelected.Contains(selected[i].ToString()))
                {
                    originalSelected.Add(Menu[selected[i]]);
                }
            }
            collectDatas();
        }
        
        public static void Main(string[] args)
        {
            if (dataCount > currentCount)
            {
                Console.Clear();
                Menu.RenderMenu();

            }
            else
            {
                System.Environment.Exit(0);
            }
        }
    }
}