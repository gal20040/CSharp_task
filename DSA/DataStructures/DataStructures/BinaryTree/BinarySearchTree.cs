namespace DataStructures.BinaryTree
{
    public class BinarySearchTree<T> : IBinarySearchTree<T>
    {
        private TreeNode<T> rootNode = null;
        private TreeNode<T> currentNode = null;

        private int nodeCount;

        public BinarySearchTree() { }
        
        public BinarySearchTree(BinarySearchTree<T> tree)
        {
            throw new System.NotImplementedException();
        }

        public TreeNode<T> Delete(T item)
        {
            throw new System.NotImplementedException();
        }

        public int Find(T item)
        {
            throw new System.NotImplementedException();
        }

        public TreeNode<T> FindNode(T item, TreeNode<T> parent)
        {
            throw new System.NotImplementedException();
        }

        public TreeNode<T> GetRoot() => rootNode;

        public TreeNode<T> Insert(T item)
        {
            if (rootNode == null)
            {
                rootNode = new TreeNode<T>(item);
                //currentNode = rootNode;

                return rootNode;
            }

            if (currentNode == null) currentNode = rootNode;

            //if (item < currentNode.Data)
            //{
            //    if (currentNode.getLeftChild())
            //}

            return currentNode;
        }

        public TreeNode<T> Update(T item)
        {
            throw new System.NotImplementedException();
        }
    }
}