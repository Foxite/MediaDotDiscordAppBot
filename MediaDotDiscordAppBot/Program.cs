using System.Text.RegularExpressions;
using DSharpPlus;
using DSharpPlus.Exceptions;

string[] responses = Environment.GetEnvironmentVariable("RESPONSES")!.Split(';');
string botToken = Environment.GetEnvironmentVariable("BOT_TOKEN")!;

var random = new Random();
var linkRegex = new Regex(@"https://media\.discordapp\.(com|net)/([^\b])+");
var discord = new DiscordClient(new DiscordConfiguration() {
	Token = botToken,
	Intents = DiscordIntents.GuildMessages | DiscordIntents.Guilds
});

discord.MessageCreated += async (o, e) => {
	MatchCollection matches = linkRegex.Matches(e.Message.Content);
	if (matches.Count > 0) {
		try {
			await e.Message.ModifyEmbedSuppressionAsync(true);
		} catch (UnauthorizedException) {
			// Ignore
		}

		string response = string.Join('\n', matches.Select(match => "https://cdn.discordapp.com" + new Uri(match.Value).PathAndQuery)) + "\n" + responses[random.Next(0, responses.Length)];
		await e.Message.RespondAsync(response);
	}
};

await discord.ConnectAsync();
await Task.Delay(-1);
