namespace Rasky.API.IdentityDb{
    public interface IEntity<T>
    {
        string Id{get;set;}
        T AddErrors(object c);
    }
}