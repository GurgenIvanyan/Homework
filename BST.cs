namespace BT;

public class Node
{
    public int Value { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    public Node(int value)
    {
       Value = value;
       Left = null;
       Right = null;
    }
}

public class BinaryTree
{
    public Node Root { get; set; }

    public void Insert(int value)
    {
        Root = insertRec(Root, value);
    }

    public Node insertRec(Node node, int value)
    {
        if (node == null) return new Node(value);
        if (value < node.Value)
        {
            node.Left = insertRec(node.Left, value);
        }
        else if (value > node.Value)
            node.Right = insertRec(node.Right, value);

        return node;
    }

    public bool Search(int value)
    {
        return SearchRec(Root, value);
    }

    public bool SearchRec(Node node, int value)
    {
        if (node == null) return false;
        if (value == node.Value) return true;
        if (value < node.Value)
            return SearchRec(node.Left, value);
        else
        {
            return SearchRec(node.Right, value);
        }
    }

    public void InorderTraversal(Node node)
    {
        if (node == null) return;
        InorderTraversal(node.Left);
        Console.Write(node.Value);
        InorderTraversal(node.Right);
    }

    public void PreorderTraversal(Node node)
    {
        if (node == null) return;
        Console.Write(node.Value);
        PreorderTraversal(node.Left);
        PreorderTraversal(node.Right);
    }

    public void PostorderTraversal(Node node)
    {
        if (node == null) return;
        PostorderTraversal(node.Left);
        PostorderTraversal(node.Right);
        Console.Write(node.Value);
    }

    public void Delete(int value)
    {
        Root = DeleteRec(Root, value);
    }

    public Node GetMinimum(Node node)
    {
        if (node == null) return node;
        while (node.Left != null)
        {
            node = node.Left;
        }

        return node;
    }

    public Node DeleteRec(Node node, int value)
    {
        if (node == null) return null;
        if (value < node.Value)
        {
            node.Left = DeleteRec(node.Left, value);
        }
        else if (value > node.Value)
        {
            node.Right = DeleteRec(node.Right, value);
        }
        else
        {
            if (node.Left == null)
            {
                return node.Right;
            }

            else if (node.Right == null)
            {
                return node.Left;
            }
            else
            {
                Node temp = GetMinimum(node.Right);
                (node.Value, temp.Value) = (temp.Value, node.Value);
                node.Right=DeleteRec(node.Right, temp.Value);

            }
            
        }
        return node;
    }
}

class Program
{
    static void Main(string[] args)
    {
        BinaryTree tree = new BinaryTree();
        
        tree.Insert(10);
        tree.Insert(7);
        tree.Insert(12);
        tree.Insert(5);
        tree.Insert(8);
        tree.Insert(3);
        tree.Insert(11);
        tree.Insert(2);
        tree.Insert(4);
        tree.Insert(6);
        tree.Insert(9);
        tree.InorderTraversal(tree.Root);
        Console.WriteLine();
        tree.PreorderTraversal(tree.Root);
        Console.WriteLine();
        tree.PostorderTraversal(tree.Root);
        tree.Delete(6);
        Console.WriteLine();
        tree.PreorderTraversal(tree.Root);
       

        
    }
}
    