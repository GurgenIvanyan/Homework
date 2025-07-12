namespace AVL;

public class TreeNode
{
    public int Value;
    public TreeNode Left;
    public TreeNode Right;

    public TreeNode(int value)
    {
        Value = value;
        this.Left = null;
        this.Right = null;
    }
}

public class BST
{
    TreeNode root;

    public BST()
    {
        root = null;
    }

    public void Insert(int value)
    {
       root = InsertNode(root, value);
    }
    public int GetHeight(TreeNode node)
    {
        if(node == null) return -1;
        int Left = GetHeight(node.Left);
        int Right = GetHeight(node.Right);
        return 1 + Math.Max(Left, Right);
    }

    public int Bf(TreeNode node)
    {
        if(node == null) return 0;
        return GetHeight(node.Left) - GetHeight(node.Right);
    }

    public TreeNode RightRotation(TreeNode node)
    {
        if(node == null) return null;
        TreeNode tmp = node.Left;
        TreeNode T3 = tmp.Right;
        tmp.Right = node;
        node.Left = T3;
        return tmp;
    }

    public TreeNode LeftRotation(TreeNode node)
    {
        if(node == null) return null;
        TreeNode tmp = node.Right;
        TreeNode T3 = tmp.Left;
        tmp.Left = node;
        node.Right = T3;
        return tmp;
    }

    private TreeNode InsertNode(TreeNode root, int value)
    {
        if (root == null)
        {
            root = new TreeNode(value);
        }

        if (root.Value > value)
        {
            root.Left = InsertNode(root.Left, value);
        }
        else if (root.Value < value)
        {
            root.Right = InsertNode(root.Right, value);
        }
        else
        return root;
        int BFVal = Bf(root);
        if (BFVal > 1 && root.Left.Value < value)
        {
            root.Left = LeftRotation(root.Left);
           return  RightRotation(root);
        }

        if (BFVal > 1 && root.Left.Value > value)
        {
            return RightRotation(root);
        }

        if (BFVal < -1 && root.Right.Value > value)
        {
            root.Right = RightRotation(root.Right);
            return LeftRotation(root);
        }

        if (BFVal < -1 && root.Right.Value < value)
        {
            return LeftRotation(root);
        }
        return root;
    }
    public void PrintInOrder()
    {
        Console.Write("InOrder: ");
        InOrder(root);
        Console.WriteLine();
    }

    private void InOrder(TreeNode node)
    {
        if (node == null) return;
        InOrder(node.Left);
        Console.Write(node.Value + " ");
        InOrder(node.Right);
    }
}

class Program
{
    static void Main(string[] args)
    {
        BST avl = new BST();
        int[] values = { 10, 20, 30, 40, 50, 25 };

        foreach (var val in values)
        {
            avl.Insert(val);
            avl.PrintInOrder();
        }

        Console.WriteLine("AVL Balanced Tree Built Successfully ✅");
    }
}