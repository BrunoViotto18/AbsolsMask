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

    public static void Clear()
        => keysPressed.Clear();
}
