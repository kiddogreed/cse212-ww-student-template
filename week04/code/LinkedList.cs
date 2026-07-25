using System.Collections;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        // Create new node
        Node newNode = new(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, then only head will be affected.
        else
        {
            newNode.Next = _head; // Connect new node to the previous head
            _head.Prev = newNode; // Connect the previous head to the new node
            _head = newNode; // Update the head to point to the new node
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {   
         // TODO Problem 1
        // 1. Create a brand new box (node) to hold our value.
        Node newNode = new(value);

        // 2. Check if the list is totally empty right now.
        if (_head is null)
        {
            // If empty, this new node is BOTH the front (_head) and the back (_tail).
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            // 3. If the list already has items:
            // Tell the current last node (_tail) to point its 'Next' arrow to our new node.
            _tail.Next = newNode;

            // Tell our new node to point its 'Prev' arrow back to the current last node.
            newNode.Prev = _tail;

            // Update our list's _tail marker so it knows the new node is now the end of the line.
            _tail = newNode;
        }
    }

    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        // If the list has only one item in it, then set head and tail 
        // to null resulting in an empty list.  This condition will also
        // cover an empty list.  Its okay to set to null again.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If the list has more than one item in it, then only the head
        // will be affected.
        else if (_head is not null)
        {
            _head.Next!.Prev = null; // Disconnect the second node from the first node
            _head = _head.Next; // Update the head to point to the second node
        }
    }

    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {   
        // TODO Problem 2
        // 1. If there's only 1 item (or 0 items) in the list:
        if (_head == _tail)
        {
            // Empty out the list by clearing both markers.
            _head = null;
            _tail = null;
        }
        else if (_tail is not null)
        {
            // 2. If there are 2 or more items in the list:
            // Disconnect the second-to-last node from the last node by wiping its 'Next' pointer.
            _tail.Prev!.Next = null;

            // Move the _tail marker backward so it points to the second-to-last node.
            _tail = _tail.Prev;
        }
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        // Search for the node that matches 'value' by starting at the 
        // head of the list.
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If the location of 'value' is at the end of the list,
                // then we can call insert_tail to add 'new_value'
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                // For any other location of 'value', need to create a 
                // new node and reconnect the links to insert.
                else
                {
                    Node newNode = new(newValue);
                    newNode.Prev = curr; // Connect new node to the node containing 'value'
                    newNode.Next = curr.Next; // Connect new node to the node after 'value'
                    curr.Next!.Prev = newNode; // Connect node after 'value' to the new node
                    curr.Next = newNode; // Connect the node containing 'value' to the new node
                }

                return; // We can exit the function after we insert
            }

            curr = curr.Next; // Go to the next node to search for 'value'
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {   
        // TODO Problem 3
        // 1. Start searching from the front of the list (_head).
        Node? curr = _head;

        while (curr is not null)
        {
            // Check if the current node holds the number we want to delete.
            if (curr.Data == value)
            {
                // CASE 1: The matching node is the FIRST item in the list.
                if (curr == _head)
                {
                    RemoveHead(); // Reuse our existing RemoveHead method
                }
                // CASE 2: The matching node is the LAST item in the list.
                else if (curr == _tail)
                {
                    RemoveTail(); // Reuse our existing RemoveTail method
                }
                // CASE 3: The matching node is somewhere in the MIDDLE.
                else
                {
                    // Bridge over 'curr': Tell the node BEFORE 'curr' to point straight to the node AFTER 'curr'.
                    curr.Prev!.Next = curr.Next;

                    // Tell the node AFTER 'curr' to point straight back to the node BEFORE 'curr'.
                    curr.Next!.Prev = curr.Prev;
                }

                // Stop searching completely as soon as we delete the first match!
                return;
            }

            // Move step-by-step to the next node in the chain.
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        // TODO Problem 4
        // 1. Start at the very beginning of the list.
        Node? curr = _head;

        // 2. Walk through every single node until we reach the end (null).
        while (curr is not null)
        {
            // If the node contains the old value, swap it for the new value.
            if (curr.Data == oldValue)
            {
                curr.Data = newValue;
            }

            // Move forward to inspect the next node.
            // (No 'return' here because we want to replace ALL matches!)
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        // call the generic version of the method
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head; // Start at the beginning since this is a forward iteration.
        while (curr is not null)
        {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Next; // Go forward in the linked list
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable Reverse()
    {   
         // TODO Problem 5
        // 1. Start at the BACK of the list (_tail) instead of the front.
        Node? curr = _tail;

        // 2. Walk backward until we pass the front of the list (null).
        while (curr is not null)
        {
            // Hand the current node's value back to the caller (e.g., a foreach loop).
            yield return curr.Data;

            // Move BACKWARD through the chain using the 'Prev' pointer.
            curr = curr.Prev;
        }
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public Boolean HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    // Just for testing.
    public Boolean HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }
}

public static class IntArrayExtensionMethods {
    public static string AsString(this IEnumerable array) {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}