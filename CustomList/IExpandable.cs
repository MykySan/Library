using System;

namespace CustomList
{
    public interface IExpandable
    {
        event Action? OnExpandedEvent;
    }
}