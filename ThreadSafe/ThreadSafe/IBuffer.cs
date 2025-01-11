namespace ThreadSafe;

public interface IBuffer<T>
{
    void Add(T item);
    T Remove();
    void CompleteAdding();
    bool IsAddingCompleted { get; }
}