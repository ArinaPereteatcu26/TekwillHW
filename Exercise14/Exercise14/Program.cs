using System;
using System.Collections.Generic;

public class PriorityQueue<T>
{
    private class PriorityQueueItem
    {
        public T Item { get; set; }
        public int Priority { get; set; }

        public PriorityQueueItem(T item, int priority)
        {
            Item = item;
            Priority = priority;
        }
    }

    private List<PriorityQueueItem> queue;

    public PriorityQueue()
    {
        queue = new List<PriorityQueueItem>();
    }

    public void Enqueue(T item, int priority)
    {
        var newItem = new PriorityQueueItem(item, priority);
        queue.Add(newItem);
        queue.Sort((x, y) => y.Priority.CompareTo(x.Priority));
    }

    public T Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Coada de prioritate este goala.");
        }

        var highestPriorityItem = queue[0];
        queue.RemoveAt(0);
        return highestPriorityItem.Item;
    }

    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Coada de prioritate este goala.");
        }

        return queue[0].Item;
    }

    public bool IsEmpty()
    {
        return queue.Count == 0;
    }
}

public class TestPriorityQueue
{
    public static void Main(string[] args)
    {

        PriorityQueue<int> intQueue = new PriorityQueue<int>();
        intQueue.Enqueue(10, 2);
        intQueue.Enqueue(20, 1);
        intQueue.Enqueue(30, 3);

        Console.WriteLine(" PriorityQueue cu int:");
        while (!intQueue.IsEmpty())
        {
            Console.WriteLine(intQueue.Dequeue());
        }

        PriorityQueue<string> stringQueue = new PriorityQueue<string>();
        stringQueue.Enqueue("low priority", 1);
        stringQueue.Enqueue("high priority", 3);
        stringQueue.Enqueue("medium priority", 2);

        Console.WriteLine("PriorityQueue cu string-uri:");
        while (!stringQueue.IsEmpty())
        {
            Console.WriteLine(stringQueue.Dequeue());
        }
    }
}