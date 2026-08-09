public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        //TODO Start Problem 1: Insert Unique Values Only
        
        // If the new value is smaller, it belongs in the left branch.
        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value); // Empty spot found! Create the new node here.
            else
                Left.Insert(value);    // Spot taken, ask the left node to handle inserting it.
        }
        // If the new value is larger, it belongs in the right branch.
        else if (value > Data)
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value); // Empty spot found! Create the new node here.
            else
                Right.Insert(value);    // Spot taken, ask the right node to handle inserting it.
        }
        
        // LAYMAN'S NOTE: If value == Data, we simply do nothing!
        // Skipping duplicate values ensures our tree only keeps unique items.
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2: Contains

        // 1. Check if the current node holds the value we are looking for.
        if (value == Data)
        {
            return true; // Bullseye! Found it.
        }
        // 2. If target value is smaller, search down the left branch.
        else if (value < Data)
        {
            // If there's no left node, the value doesn't exist. 
            // If there is a left node, pass the search down to it.
            return Left != null && Left.Contains(value);
        }
        // 3. If target value is larger, search down the right branch.
        else
        {
            // If there's no right node, the value doesn't exist.
            // If there is a right node, pass the search down to it.
            return Right != null && Right.Contains(value);
        }
    }

    public int GetHeight()
    {
        // TODO Start Problem 4: Tree Height

        // Ask the left child for its height. If there is no left child, its height is 0.
        int leftHeight = Left?.GetHeight() ?? 0;

        // Ask the right child for its height. If there is no right child, its height is 0.
        int rightHeight = Right?.GetHeight() ?? 0;

        // The overall height at this point is 1 (counting the current node) 
        // plus whichever branch (left or right) is taller.
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}