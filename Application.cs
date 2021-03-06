﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using VkNet;
using VkNet.Model;
using VkNet.Model.RequestParams;
using static System.Console;
using static System.IO.File;
using static System.Text.Json.JsonSerializer;
using static System.TimeSpan;
using static Authorization;
using static Terminal;

internal static class Application
{
    private static void Main(string[] args)
    {
        var api = LoginApi(args);
        foreach (var conversationAndLastMessage in api.Messages.GetConversations(new GetConversationsParams
        {
        }).Items)
        {
            conversationAndLastMessage.LastMessage.Println();
        }
        /*var analytic = new Analyst(LoginApi(args));
        for (var command = ReadCommand();; command = ReadCommand())
        {
            analytic.Execute(command);
        }*/
    }

    private static void Execute(this Analyst analyst, string command)
    {
        
    }
}