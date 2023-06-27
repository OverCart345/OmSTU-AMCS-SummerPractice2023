namespace SalonLib;
public class ServiceLocator
{
    private static IDictionary<string, Func<string>> store;

    static ServiceLocator()
    {
        store = new Dictionary<string, Func<string>>();
        store.Add("Читать стихи", () => "В читальном зале");
        store.Add("Петь романсы", () => "У рояля");
        store.Add("Писать статьи", () => "В кабинете");
    }

    public static string GetService(string key)
    {
        return store[key].Invoke();
    }

}
