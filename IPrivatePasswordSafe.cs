interface IPrivatePasswordSafe<TPassword>
{
    protected TPassword Password { get; set; }
    public void Call(ISecretCall<TPassword> call);
}
interface ISecretCall<TPassword>
{
    protected TPassword Password { get; }
}