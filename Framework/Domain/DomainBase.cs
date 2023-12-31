namespace Framework.Domain;

public class DomainBase<T>
{
    public T Id { get; private set; }
    public string CreationDate { get; private set; }

    public DomainBase()
    {
        CreationDate = DateTime.Now.ToString();
    }
}