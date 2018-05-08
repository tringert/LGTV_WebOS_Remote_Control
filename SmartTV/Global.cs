static class Global
{
    private static int _volume = 0;

    public static int GlobalVolume
    {
        get { return _volume; }
        set { _volume = value; }
    }
}