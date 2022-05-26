namespace AbsolsMask;

public static class KeyPressManager
{
    private static List<Keys> keysPressed = new List<Keys>();


    public static Keys[] KeysPressed
    {
        get
        {
            Keys[] keys = new Keys[keysPressed.Count];
            keysPressed.CopyTo(keys, 0);
            return keys;
        }
    }


    public static void AddKey(Keys key)
    {
        if (!keysPressed.Contains(key))
            keysPressed.Add(key);
    }

    public static void RemoveKey(Keys key)
    {
        keysPressed.Remove(key);
    }

    public static Keys? LastKey(params Keys[] args)
    {
        return args.LastOrDefault(k => KeysPressed.Contains(k));
    }

    public static void Clear()
    {
        keysPressed.Clear();
    }
}
