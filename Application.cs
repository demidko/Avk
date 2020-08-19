using System;
using System.Collections.Generic;
using VkNet;
using VkNet.Model;
using static Authorization;

internal class Application
{
    private readonly VkApi _api;
    private readonly Dictionary<User, (DateTime timestamp, LinkedList<User> onlineFriends)>
        _db = new Dictionary<User, (DateTime, LinkedList<User>)>();

    private Application(VkApi api)
    {
        _api = api;
        // десериализация из файла
    }
    
    private void UpdateAsync()
    {
        
    }

    private void DumpAsync()
    {
        // простая сериализация в файл
    }

    private void Analyze(User user)
    {
        
    }

    private static void Main(string[] user)
    {
        var api = Login(user);
    }
    
}