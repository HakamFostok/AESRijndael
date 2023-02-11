namespace AesRijndaelLibrary;

public class AesKey128 : AesKeyBase
{
    public AesKey128(byte[] key)
        : base(4, key)
    {

    }

    public AesKey128(string key)
       : base(4, key)
    {
    }

    public AesKey128()
        : base(4)
    {
    }
}
