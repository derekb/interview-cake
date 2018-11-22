using System;

namespace BinaryTreeSolver
{
    public class BinaryTreeSolver<T>
    {


        public T GetSecondLargest(BinaryTreeNode<T> root) 
        {
            if (root == null || (root.Left == null && root.Right == null))
                return default(T);
            
            var results = GetLargest(root);

            if (results.largest.Left != null) 
            {
                return GetLargest(results.largest.Left).largest.Value;
            } 
            else
            {
                return results.parent.Value;
            }
        }

        private (BinaryTreeNode<T> parent, BinaryTreeNode<T> largest) GetLargest(BinaryTreeNode<T> subtree) {
            BinaryTreeNode<T> parentOfLargestYet = null;
            BinaryTreeNode<T> largestYet = subtree;

            while (largestYet.Right != null) 
            {
                parentOfLargestYet = largestYet;
                largestYet = largestYet.Right;
            }        

            return (parentOfLargestYet, largestYet);    
        }
    }
    public  class BinaryTreeNode<T> {
        public T Value { get; private set; }
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set;}

        public BinaryTreeNode(T value) {
            this.Value = value;
        }
    }
}
