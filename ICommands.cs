using System.Collections;
interface IBinaryCodeCommander
{
    public void Complete(BitArray bitArray);
}
interface IBinaryCodeDecoder
{
    public Action Decrypt(BitArray bitArray);
}
interface IFormatterCommander
{
    public void Complete(IFormatProvider? provider);
}
namespace System.Collections.Generic
{
    interface IChain<TActivate, TElement>
    {
        public void Activate(TActivate activate);
        public IEnumerator<TElement> GetEnumerator();
    }
    interface IInsertChain<TActivate, TElement>
    {
        public void Activate(TActivate activate, int index);
        public IEnumerator<TElement> GetEnumerator();
    }
}
