using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Binary_Tree_Traversal
{
    class Binary_Tree
    {
        public string val;
        public Binary_Tree left;
        public Binary_Tree right;
        public Binary_Tree(string x)
        {
            val = x;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //creat tree
            Binary_Tree Node = new Binary_Tree("A");
            Node.left = new Binary_Tree("B") { left = new Binary_Tree("D") { left = new Binary_Tree("G") },right=new Binary_Tree("E") { right=new Binary_Tree("H")} };
            //Node.right = new Binary_Tree("C") { left = new Binary_Tree("I"),right = new Binary_Tree("F") };
            Node.right = new Binary_Tree("C") { right = new Binary_Tree("F") };

            PreOrder(Node);
            Console.WriteLine();
            NoRePreOrder(Node);
            Console.WriteLine();
            Console.WriteLine();
            InOrder(Node);
            Console.WriteLine();
            NoReInOrder(Node);
            Console.WriteLine();
            Console.WriteLine();
            PostOrder(Node);
            Console.WriteLine();
            NoRePostOrder(Node);
            Console.WriteLine();
            Console.WriteLine();
            LevelOrder(Node);
            Console.WriteLine();
            Console.WriteLine();
            Z_LevelOrder(Node);
            Console.WriteLine();
        }


        //recursion traversal
        public static void PreOrder(Binary_Tree Tree)
        {
            if (Tree == null)
                return;
            Console.Write(Tree.val);
            PreOrder(Tree.left);
            PreOrder(Tree.right);
        }


        public static void InOrder(Binary_Tree Tree)
        {
            if (Tree == null)
                return;
            InOrder(Tree.left);
            Console.Write(Tree.val);
            InOrder(Tree.right);
        }

        public static void PostOrder(Binary_Tree Tree)
        {
            if (Tree == null)
                return;
            PostOrder(Tree.left);
            PostOrder(Tree.right);
            Console.Write(Tree.val);
        }

        public static bool IsSameTree(Binary_Tree p, Binary_Tree q)
        {
            if ((p == null) && (q == null))
            {
                return true;

            }
            else if ((p == null) || (q == null))
            {
                return false;
            }
            {
                if (p.val != q.val)
                    return false;
                else
                    return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
            }
        }
        //norecursion traversal
        public static void NoRePreOrder(Binary_Tree Tree)
        {
            if (Tree == null)
                return;
            Stack<Binary_Tree> stack = new Stack<Binary_Tree>();
            while ((Tree != null)||(stack.Count()!=0))
            {
                if (Tree != null)
                {
                    Console.Write(Tree.val);
                    stack.Push(Tree);
                    Tree = Tree.left;
                }
                else
                {
                    Tree = stack.Pop().right;
                }                           
            }
        }


        public static void NoReInOrder(Binary_Tree Tree)
        {
            if (Tree == null)
                return;
            Stack<Binary_Tree> stack = new Stack<Binary_Tree>();
            while ((Tree != null) || (stack.Count() != 0))
            {
                if (Tree != null)
                {
                    stack.Push(Tree);
                    Tree = Tree.left;
                }
                else
                {
                    Tree = stack.Pop();
                    Console.Write(Tree.val);
                    Tree = Tree.right;
                }
            }
        }

        public static void NoRePostOrder(Binary_Tree Tree)
        {
            if (Tree == null)
                return;
            Stack<Binary_Tree> stack = new Stack<Binary_Tree>();

            Binary_Tree Pre_Node=null;
            while ((Tree != null) || (stack.Count() != 0))
            {
                if (Tree != null)
                {
                    stack.Push(Tree);
                    Tree = Tree.left;
                    Pre_Node = null;
                }
                else
                {
                    Binary_Tree node = stack.Peek();
                    if ((node.left == Pre_Node)&&(node.right != null))
                    {
                        Tree = node.right;
                    }
                    else
                    {
                        node = stack.Pop();
                        Pre_Node = node;
                        Console.Write(node.val);
                        Tree = null;
                    }                                                          
                }
            }
        }



        public static void LevelOrder(Binary_Tree Tree)
        {
            if (Tree == null)
                return;
            else
            {
                Console.Write(Tree.val);
                Queue<Binary_Tree> tree_queue = new Queue<Binary_Tree>();
                tree_queue.Enqueue(Tree.left);
                tree_queue.Enqueue(Tree.right);
                while (tree_queue.Count() != 0)
                {
                    int count = tree_queue.Count();
                    for (int i = 0; i < count; i++)
                    {
                        Binary_Tree temp_tree = tree_queue.Dequeue();
                        if (temp_tree != null)
                        {
                            Console.Write(temp_tree.val);
                            tree_queue.Enqueue(temp_tree.left);
                            tree_queue.Enqueue(temp_tree.right);
                        }
                    }
                }
            }
        }

        public static void Z_LevelOrder(Binary_Tree Tree)
        {
            int depth = 1;
            if (Tree == null)
                return;
            else
            {
                Console.Write(Tree.val);
                Queue<Binary_Tree> queue = new Queue<Binary_Tree>();
                queue.Enqueue(Tree.right);
                queue.Enqueue(Tree.left);
                while (queue.Count() != 0)
                {
                    depth++;
                    int count = queue.Count();

                        List<Binary_Tree> list = new List<Binary_Tree>();
                        for (int i = 0; i < count; i++)
                        {
                            Binary_Tree temp_node = queue.Dequeue();
                            list.Add(temp_node);
                            if (temp_node != null)
                                Console.Write(temp_node.val);
                        }
                        for (int i = count - 1; i >= 0; i--)
                        {
                            Binary_Tree temp_node = list[i];
                            if (temp_node != null)
                            {
                                if (depth % 2 == 0)
                                {
                                    queue.Enqueue(temp_node.left);
                                    queue.Enqueue(temp_node.right);
                                }
                                else
                                {
                                    queue.Enqueue(temp_node.right);
                                    queue.Enqueue(temp_node.left);
                                }
                                    
                            }
                                
                        }
                    

                }
                
            }
        }

        public static bool NoReIsSameTree(Binary_Tree p, Binary_Tree q)
        {
            if ((p == null) && (q == null))
            {
                return true;

            }
            else if ((p == null) || (q == null))
            {
                return false;
            }
            else
            {
                Stack<Binary_Tree> stack_p = new Stack<Binary_Tree>();
                Stack<Binary_Tree> stack_q = new Stack<Binary_Tree>();
                while (((p != null) && (q != null))||((stack_p.Count()!=0)&&(stack_q.Count()!=0)))
                {
                    if ((p != null) && (q != null))
                    {
                        if (p.val != q.val)
                        {
                            return false;
                        }
                        else
                        {
                            stack_p.Push(p);
                            stack_q.Push(q);
                            p = p.left;
                            q = q.left;
                        }
                    }
                    else if ((p == null) && (q == null))
                    {
                        p = stack_p.Pop().right;
                        q = stack_q.Pop().right;
                    }
                    else
                    {
                        return false;
                    }
                }

                if ((p == null) && (q == null) && (stack_p.Count() == 0) && (stack_q.Count() == 0))
                    return true;
                else
                    return false;
            }
        }


    }
}
