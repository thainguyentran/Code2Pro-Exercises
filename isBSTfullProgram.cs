using System;
using System.Collections.Generic;

namespace ShadyProgramming
{
    class Node
    {
        public Node left,right;
        public int data;
        
        public Node(int data)
        {
            this.data = data;
            left = right = null;
        }
    }
    
    class Program
    {
        static void Main(String[] args)
        {
            Functions f = new Functions();
            Node root = null;
            int T = Int32.Parse(Console.ReadLine());
            
            while(T --> 0)
            {
                int data = Int32.Parse(Console.ReadLine());
                root = f.insert(root, data);            
            }

            Console.WriteLine(f.isBST(root));
        }
    }

    class Functions
    {
        const bool isABST = true;
        const bool isNOTABST = false;
        
        public Node insert(Node root, int data)
        {
            if(root == null)
            {
                return new Node(data);
            }
            else
            {
                Node cur;
                if(data >= root.data)
                {
                    cur = insert(root.left, data);
                    root.left = cur;
                }
                else
                {
                    cur = insert(root.right, data);
                    root.right = cur;
                }
                return root;
            }
        }

        public bool isBST(Node root)
        {
            if(root == null)
                return isNOTABST;
            else
            {
                Queue<Node> bSTQ = new Queue<Node>();
                bSTQ.Enqueue(root);
                while (bSTQ.Count > 0)
                {
                    Node curr = bSTQ.Dequeue();
                    if(curr.left != null) 
                    {
                        if(curr.data < curr.left.data)
                            return isNOTABST;
                        else bSTQ.Enqueue(curr.left);
                    }
                    if(curr.right != null)
                    {
                        if(curr.data > curr.right.data)
                            return isNOTABST;
                        else bSTQ.Enqueue(curr.right);
                    } 
                }
                return isABST;
            }
        }
    }
}
