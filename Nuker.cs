using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.Net;
using Discord.WebSocket;

namespace discord.nuke.net
{
    public class Nuker : discordManager
    {
        public static DiscordSocketClient client = discordManager._client;
        public static Dictionary<ulong, string> Datas = Program.Datas;
        public static List<string> originalSelected = Program.originalSelected;


        public static void deleteChannels()
        {
            Console.WriteLine("Delete Channels...");
            Console.WriteLine();
            ulong guildid = Convert.ToUInt64(Datas.ElementAt(0).Key);
            
            var guild = client.GetGuild(guildid);


            var channels = guild.Channels;
            foreach (var channel in channels)
            {
                Thread.Sleep(1500);
                channel.DeleteAsync();
                Console.WriteLine($"{channel.Name} -> deleted (if have permission)");
            }
        }

        public static async void KickUsers()
        {
            Console.WriteLine("Kick users of guild...");
            Console.WriteLine();
            ulong guildid = Convert.ToUInt64(Datas.ElementAt(0).Key);
            
            
            var guild = client.GetGuild(guildid);

            await guild.DownloadUsersAsync();

            var users = guild.Users.ToList();

            foreach (var user in users)
            {
                Thread.Sleep(1500);
                user.KickAsync();
                Console.WriteLine($"{user.Username}({user.DisplayName}#{user.Discriminator}) -> kicked (if have permission)");
            }
            

        }

        public static void Nuke()
        {
            deleteChannels();
            deleteRoles();
            KickUsers();
        }

        public static void deleteRoles()
        {
            Console.WriteLine("Delete roles...");
            Console.WriteLine();
            ulong guildid = Convert.ToUInt64(Datas.ElementAt(0).Key);
            
            
            var guild = client.GetGuild(guildid);

            var roles = guild.Roles;

            foreach (var role in roles)
            {
                Thread.Sleep(1500);
                role.DeleteAsync();
                Console.WriteLine($"{role.Name} -> deleted (if have permission.)");
            }
            

        }

        public static void startOptions()
        {

            for (int i = 0; i < originalSelected.Count; i++)
            {
                if (originalSelected[i] == "Delete Channels")
                {
                    Thread.Sleep(700);
                    deleteChannels();
                } if (originalSelected[i] == "Kick Users")
                {
                    Thread.Sleep(1200);
                    KickUsers();
                } if (originalSelected[i] == "Delete All Roles")
                {
                    Thread.Sleep(2000);
                deleteRoles();
                } if (originalSelected[i] == "Nuke Server")
                {
                    Nuke();
                }
            }

            Program.currentCount++;
            Program.Main(new string[]{});


        }
        
        
    }
}