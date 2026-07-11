using Microsoft.VisualStudio.TestTools.UnitTesting;

// Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue two integers with different priorities
    // Expected Result: Highest priority dequeued first, then lower priority
    // Defect(s) Found: Items were not dequeued in correct priority order
    public void TestPriorityQueue_1()
    {
        var pq = new PriorityQueue<int>();
        pq.Enqueue(5, 1);   // lower priority
        pq.Enqueue(10, 3);  // higher priority

        Assert.AreEqual(10, pq.Dequeue());
        Assert.AreEqual(5, pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue strings with same priority
    // Expected Result: FIFO order respected within same priority
    // Defect(s) Found: Equal-priority items were not dequeued in insertion order
    public void TestPriorityQueue_2()
    {
        var pq = new PriorityQueue<string>();
        pq.Enqueue("first", 2);
        pq.Enqueue("second", 2);

        Assert.AreEqual("first", pq.Dequeue());
        Assert.AreEqual("second", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from empty queue
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: Exception type or message incorrect
    public void TestPriorityQueue_Empty()
    {
        var pq = new PriorityQueue<int>();

        try
        {
            pq.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}
