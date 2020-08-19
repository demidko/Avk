using static Authorization;

/// <summary>
/// Точка входа описывает логику приложения на высоком уровне
/// </summary>
internal static class Application
{
    private static void Main(string[] user)
    {
        var api = Login(user);

        var t = api.Friends.Get()[0]!;
        
    }
}