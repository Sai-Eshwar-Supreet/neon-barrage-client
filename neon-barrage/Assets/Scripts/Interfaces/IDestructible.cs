public interface IDestructible
{

    public bool IsDestroyed { get; set; }
    public void Destroy();

}
