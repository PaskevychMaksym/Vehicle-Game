public class StateMachine<T>
{
  private T _owner;
  private State<T> _currentState;

  public StateMachine(T owner)
  {
    _owner = owner;
  }

  public void ChangeState(State<T> newState)
  {
    _currentState?.Exit();
    _currentState = newState;
    _currentState.Enter(_owner);
  }

  public void Update()
  {
    _currentState?.Update(_owner);
  }
}

public abstract class State<T>
{
  public abstract void Enter(T owner);
  public abstract void Update(T owner);
  public abstract void Exit();
}