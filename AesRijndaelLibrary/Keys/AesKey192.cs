namespace AesRijndaelLibrary;

public class AesKey192 : AesKeyBase
{
    public AesKey192(byte[] key)
        : base(6, key)
    {
    }

    public AesKey192(string key)
       : base(6, key)
    {
    }

    public AesKey192()
        : base(6)
    {
    }
}
