using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities and verify dequeue order.
    // Expected Result: Apple (Pri:3), Grape (Pri:2), Banana (Pri:1)
    // Defect(s) Found: The loop condition in `Dequeue` was `index < _queue.Count - 1` instead of `index < _queue.Count`. This meant the last element in the queue was never considered when finding the highest priority, leading to incorrect dequeueing if the highest priority item was at the end.
    public void TestPriorityQueue_BasicPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Banana", 1);
        priorityQueue.Enqueue("Apple", 3);
        priorityQueue.Enqueue("Grape", 2);

        Assert.AreEqual("Apple", priorityQueue.Dequeue());
        Assert.AreEqual("Grape", priorityQueue.Dequeue());
        Assert.AreEqual("Banana", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with same highest priority and verify FIFO rule.
    // Expected Result: Item A (Pri:5), Item C (Pri:5), Item B (Pri:4)
    // Defect(s) Found: The condition `_queue[index].Priority >= _queue[highPriorityIndex].Priority` was used to find the highest priority. When priorities were equal, this would update `highPriorityIndex` to a later index, violating the FIFO rule for ties. It should be `> ` to ensure the first highest priority item is chosen.
    public void TestPriorityQueue_TieBreakerFIFO()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item A", 5);
        priorityQueue.Enqueue("Item B", 4);
        priorityQueue.Enqueue("Item C", 5);

        Assert.AreEqual("Item A", priorityQueue.Dequeue()); // Item A added first with priority 5
        Assert.AreEqual("Item C", priorityQueue.Dequeue()); // Item C added second with priority 5
        Assert.AreEqual("Item B", priorityQueue.Dequeue()); // Item B has priority 4
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty priority queue.
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None. The `InvalidOperationException` was correctly thrown and caught.
    public void TestPriorityQueue_EmptyQueueException()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                 e.GetType(), e.Message)
            );
        }
    }
}