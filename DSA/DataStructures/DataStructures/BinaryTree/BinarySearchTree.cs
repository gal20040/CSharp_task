namespace DataStructures.BinaryTree
{
    //todo: сначала сделаю на int, с дженериками как-то не задалось - простое сравнение не работает: Operator >= cannot be applied to operands of type 'int' and 'int'
    public class BinarySearchTree : IBinarySearchTree<int>
    {
        private TreeNode<int> rootNode = null;
        private TreeNode<int> currentNode = null;

        private int nodeCount;

        public BinarySearchTree() { }

        public BinarySearchTree(BinarySearchTree tree)
        {
            throw new System.NotImplementedException();
        }

        public TreeNode<int> Delete(int item)
        {
            throw new System.NotImplementedException();
        }

        public TreeNode<int> Find(int value)
        {
            if (rootNode == null) return null;

            if (currentNode == null) currentNode = rootNode;

            TreeNode<int> requiredNode;

            if (value < currentNode.Data)
            {
                if (currentNode.HasLeftChild())
                {
                    currentNode = currentNode.GetLeftChild() as TreeNode<int>;
                    requiredNode = Find(value);
                    currentNode = null;
                }
                else
                {
                    requiredNode = null;
                }
            }
            else if (value == currentNode.Data)
            {
                requiredNode = currentNode;
            }
            else
            {
                if (currentNode.HasRightChild())
                {
                    currentNode = currentNode.GetRightChild() as TreeNode<int>;
                    requiredNode = Find(value);
                    currentNode = null;
                }
                else
                {
                    requiredNode = null;
                }
            }

            return requiredNode;
        }

        public TreeNode<int> FindNode(int item, TreeNode<int> parent)
        {
            throw new System.NotImplementedException();
        }

        public TreeNode<int> GetRoot() => rootNode;

        public TreeNode<int> Insert(int value)
        {
            if (rootNode == null)
            {
                rootNode = new TreeNode<int>(value);

                return rootNode;
            }

            if (currentNode == null) currentNode = rootNode;

            if (value < currentNode.Data)
            {
                if (currentNode.HasLeftChild())
                {
                    currentNode = currentNode.GetLeftChild() as TreeNode<int>;
                    Insert(value);
                    currentNode = null;
                }
                else
                {
                    currentNode.Update(currentNode.Data, new TreeNode<int>(value), currentNode.GetRightChild());
                }
            }
            else
            {
                if (currentNode.HasRightChild())
                {
                    currentNode = currentNode.GetRightChild() as TreeNode<int>;
                    Insert(value);
                    currentNode = null;
                }
                else
                {
                    currentNode.Update(currentNode.Data, currentNode.GetLeftChild(), new TreeNode<int>(value));
                }
            }

            return currentNode;
        }

        public TreeNode<int> Update(int item)
        {
            throw new System.NotImplementedException();
        }
    }
}