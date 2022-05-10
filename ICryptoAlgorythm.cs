interface ICryptoAlgorythm<TValue, TAlgorythm>
{
     public TValue DecryptValue(TAlgorythm value);
     public TAlgorythm EncryptValue(TValue value);
}
static class CryptoAlgorythm
{
     public static bool IsDecryptNormal<TValue, TAlgorythm>(this ICryptoAlgorythm<TValue, TAlgorythm> cryptoAlgorythm,
      TValue[] values)
     {
          var accumulator = new BooleanAccumulator();
          foreach (var item in values)
          {
               accumulator.And(Equals(cryptoAlgorythm.DecryptValue(cryptoAlgorythm.EncryptValue(item)), item));
          }
          return accumulator.Value;
     }
}