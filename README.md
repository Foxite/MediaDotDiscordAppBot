# MediaDotDiscordAppBot
Discord bot that replaces urls to media.discordapp.net with cdn.discordapp.com.

## Usage
Join the bot into your server and optionally give it Manage Messages. If it has this permission, it will remove embeds from messages that it responds to.

## Docker deployment
Dockerfile in program folder, envvars:
- BOT_TOKEN
- RESPONSES (semicolon separated)
