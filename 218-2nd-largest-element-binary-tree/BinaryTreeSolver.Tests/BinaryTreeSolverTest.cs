using NUnit.Framework;
using BinaryTreeSolver;

namespace Tests
{
    public class BinaryTreeSolverTest
    {

        [Test]
        public void NullTreeHasDefaultAnswer()
        {
            var answer = GetSecondLargest<int>(null);
            Assert.AreEqual(0, answer);
        }

        [Test]
        public void SingleElementTreeHasDefaultAnswer()
        {
            var root = new BinaryTreeNode<int>(1);

            var answer = GetSecondLargest(root);

            Assert.AreEqual(0, answer);
        }

        [Test]
        public void TwoElementTreeReturnsSecondLargestLeft()
        {
            var root = CreateNode(2);
            root.Left = CreateNode(1);

            var answer = GetSecondLargest(root);

            Assert.AreEqual(1, answer);
        }

        [Test]
        public void TwoElementTreeReturnsSecondLargestRight()
        {
            var root = CreateNode(1);
            root.Right = CreateNode(2);

            var answer = GetSecondLargest(root);

            Assert.AreEqual(1, answer);
        }

        [Test]
        public void ThreeElementTreeReturnsSecondLargestMid()
        {
            var root = CreateNode(2);
            root.Right = CreateNode(3);
            root.Left = CreateNode(1);

            var answer = GetSecondLargest(root);

            Assert.AreEqual(2, answer);
        }

        [Test]
        public void ThreeElementTreeReturnsSecondLargestRight()
        {
            var root = CreateNode(2);
            var largest = CreateNode(4);
            root.Right = largest;
            largest.Left = CreateNode(3);

            var answer = GetSecondLargest(root);

            Assert.AreEqual(3, answer);
        }

        [Test]
        public void ThreeElementTreeReturnsSecondLargestLeft()
        {
            var root = CreateNode(4);
            root.Left = CreateNode(2);
            root.Left.Right = CreateNode(3);

            var answer = GetSecondLargest(root);

            Assert.AreEqual(3, answer);
        }

        private static BinaryTreeNode<int> CreateNode(int value)
        {
            return new BinaryTreeNode<int>(value);
        }

        private T GetSecondLargest<T>(BinaryTreeNode<T> root) {
            return CreateSolver<T>().GetSecondLargest(root);
        }
        private BinaryTreeSolver.BinaryTreeSolver<T> CreateSolver<T>() {
            return new BinaryTreeSolver.BinaryTreeSolver<T>();
        }
    }
}