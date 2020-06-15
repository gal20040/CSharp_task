namespace DataStructures.BinaryTree
{
    //todo: сначала сделаю на int, с дженериками как-то не задалось - простое сравнение не работает: Operator >= cannot be applied to operands of type 'int' and 'int'
    public class BinarySearchTree : IBinarySearchTree<int>
    {
        private TreeNode<int> rootNode = null;
        private TreeNode<int> currentNode = null;
        private TreeNode<int> currentNodeParent = null;

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

            currentNode = rootNode;
            currentNodeParent = null;
            TreeNode<int> requiredNode = null;

            while (currentNode != null)
            {
                if (value < currentNode.Data)
                {
                    currentNodeParent = currentNode;
                    currentNode = currentNode.GetLeftChild() as TreeNode<int>;
                }
                else if (value == currentNode.Data)
                {
                    requiredNode = currentNode;
                    break;
                }
                else
                {
                    currentNodeParent = currentNode;
                    currentNode = currentNode.GetRightChild() as TreeNode<int>;
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

            currentNode = rootNode;
            currentNodeParent = null;
            var newNode = new TreeNode<int>(value);

            while (currentNode != null)
            {
                currentNodeParent = currentNode;

                if (value < currentNode.Data)
                {
                    if (currentNode.HasLeftChild())
                    {
                        currentNode = currentNode.GetLeftChild() as TreeNode<int>;
                    }
                    else
                    {
                        currentNode.AddLeftChild(newNode);
                        currentNode = newNode;

                        break;
                    }
                }
                else
                {
                    if (currentNode.HasRightChild())
                    {
                        currentNode = currentNode.GetRightChild() as TreeNode<int>;
                    }
                    else
                    {
                        currentNode.AddRightChild(newNode);
                        currentNode = newNode;

                        break;
                    }
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