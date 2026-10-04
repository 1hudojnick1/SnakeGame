public abstract class BaseGameLogic : ConsoleInput.IArrowListener
{
    public void InitializeInput(ConsoleInput input)
    {
        input.Subscribe(this);
    }

    public abstract void Update(float deltaTime);

    public virtual void OnArrowUp()
    {
    }

    public virtual void OnArrowDown()
    {
    }

    public virtual void OnArrowLeft()
    {
    }

    public virtual void OnArrowRight()
    {
    }
}