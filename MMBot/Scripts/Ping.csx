﻿var robot = Require<Robot>();

robot.Respond(@"PING$",msg => msg.Send("PONG"));

robot.Respond(@"ECHO (.*)$", msg => msg.Send(msg.Match[1]));

robot.Respond(@"TIME$", msg => msg.Send(string.Format("Server time is: {0} {1}", DateTime.Now.ToString("U"), TimeZoneInfo.Local.DisplayName)));

robot.Respond(@"DIE$", msg => Environment.Exit(0));

robot.Respond(@"RESPAWN$", msg => {msg.Finish(); robot.Reset(); });

robot.AddHelp(
    "mmbot ping -  Reply with pong",
    "mmbot echo <text> - Reply back with <text>",
    "mmbot time - Reply with current time",
    "mmbot die - End mmbot process"
);
