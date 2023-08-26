using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Input;

namespace BotTormenta.Commands
{
    public class FontCommands : BaseCommandModule
    {
        [Command("help")]
        [Description("Displays a list of available commands.")]
        public async Task HelpAsync(CommandContext ctx)
        {
            var embed = new DiscordEmbedBuilder
            {
                Color = new DiscordColor(0x4287F5), // Blue color
                Title = "Bot Commands",
                Description = "List of available commands:",
            };

            var commands = ctx.CommandsNext.RegisteredCommands;
            foreach (var command in commands)
            {
                var desc = command.Value.Description ?? "No description available";
                embed.AddField(command.Key, desc, inline: false);
            }

            await ctx.RespondAsync(embed: embed.Build());
        }


        [Command("magia")]
        [Description("Displays information about a magic spell.")]
        public async Task MagiaCommand(CommandContext ctx, [RemainingText] string buscarMagia)
        {
            if (string.IsNullOrWhiteSpace(buscarMagia))
            {
                await ctx.RespondAsync("Por favor, forneça o nome da magia a ser buscada.");
                return;
            }

            DataTable dt = bdSQL.ConsultaMagi(buscarMagia);

            if (dt.Rows.Count > 0)
            {
                string title = dt.Rows[0][0].ToString();
                string desc = dt.Rows[0][1].ToString();

                var embed = new DiscordEmbedBuilder()
                    .WithTitle($"**{title}**")
                    .WithDescription(desc)
                    .WithColor(DiscordColor.IndianRed);

                await ctx.RespondAsync(embed: embed);
            }
            else
            {
                await ctx.RespondAsync($"Magia '{buscarMagia}' não encontrada.");
            }
        }

        [Command("talento")]
        [Description("Displays information about a talent.")]
        public async Task TalentCommand(CommandContext ctx, [RemainingText] string buscarTalent)
        {
            if (string.IsNullOrWhiteSpace(buscarTalent))
            {
                await ctx.RespondAsync("Por favor, forneça o nome da magia a ser buscada.");
                return;
            }

            DataTable dt = bdSQL.ConsultaTalent(buscarTalent);

            if (dt.Rows.Count > 0)
            {
                string title = dt.Rows[0][0].ToString();
                string desc = dt.Rows[0][1].ToString();

                var embed = new DiscordEmbedBuilder()
                    .WithTitle($"**{title}**")
                    .WithDescription(desc)
                    .WithColor(DiscordColor.IndianRed);

                await ctx.RespondAsync(embed: embed);
            }
            else
            {
                await ctx.RespondAsync($"Talento '{buscarTalent}' não encontrada.");
            }
        }
    }
}
