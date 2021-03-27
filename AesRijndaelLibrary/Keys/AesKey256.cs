namespace AesRijndaelLibrary
{
    public class AesKey256 : AesKeyBase
    {
        public AesKey256(byte[] key)
            : base(8, key)
        {
        }

        public AesKey256(string key)
            : base(8, key)
        {
        }

        [System.Obsolete("Must be removed")]
        public AesKey256()
            : base(8)
        {
        }
    }
}