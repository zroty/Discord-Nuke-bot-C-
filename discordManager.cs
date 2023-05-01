using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace discord.nuke.net
{
    public class discordManager : Menu
    {
        
        public static  DiscordSocketClient _client;

        public static async Task MainAsync(string token)
        {
            DiscordSocketConfig _config = new DiscordSocketConfig
            {
                AlwaysDownloadUsers = true,
                GatewayIntents = GatewayIntents.AllUnprivileged | GatewayIntents.MessageContent | GatewayIntents.GuildMembers
            };
            _client = new DiscordSocketClient(_config);

            _client.Log += Log;

            
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            _client.Ready += () =>
            {
                Console.WriteLine("The bot ready to nuking.");
                System.Threading.Thread.Sleep(3000);
                Nuker.startOptions();

                return Task.CompletedTask;
            };
            
            await Task.Delay(-1);



        }
        
        public static Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
        
    }
}