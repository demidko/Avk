using System;
using System.Collections.Generic;
using VkNet.Model;
using static Authorization;

internal class Application
{
    
    
    private readonly Dictionary<User, (DateTime timestamp, LinkedList<User> onlineFriends)>
        _db = new Dictionary<User, (DateTime, LinkedList<User>)>();

    private void UpdateAsync()
    {
        // dump there
    }

    private void DumpAsync()
    {
        throw new NotImplementedException();
    }

    private void Analyze(User user)
    {
        
    }

    private static void Main(string[] user)
    {
        var api = Login(user);
    }
    
}