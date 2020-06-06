namespace DataStructures.BinaryTree
{
    public class TreeNode<T>
    {
        private TreeNode<T> leftChild;
        private TreeNode<T> rightChild;

        public T Data;

        public TreeNode(T data, TreeNode<T> leftChild = null, TreeNode<T> rightChild = null)
        {
            Data = data;
            this.leftChild = leftChild;
            this.rightChild = rightChild;
        }

        TreeNode<T> getLeftChild() => leftChild;

        TreeNode<T> getRightChild() => rightChild;
    }
}