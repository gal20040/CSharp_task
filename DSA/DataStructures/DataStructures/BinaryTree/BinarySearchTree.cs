using System;

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

        public TreeNode<int> Delete(int value)
        {
            var requiredNode = Find(value);

            if (requiredNode == null)
            {
                //нет такого значения, нечего удалять
                return requiredNode;
            }

            return Delete(requiredNode);
        }

        private TreeNode<int> Delete(TreeNode<int> requiredNode)
        {
            //удаляемый узел не имеет потомков - просто удаляем его у его родителя.
            if (requiredNode.IsLeaf())
            {
                if (currentNodeParent == null)
                {
                    //удаляемый узел является корнем и единственным узлом в дереве - удаляем только его.
                    rootNode = null;

                    //возвращаем удалённый узел
                    return requiredNode;
                }

                if (requiredNode.Data < currentNodeParent.Data)
                {
                    currentNodeParent.DeleteLeftChild();
                }
                else
                {
                    currentNodeParent.DeleteRightChild();
                }

                //возвращаем удалённый узел
                return requiredNode;
            }

            bool requiredNodeIsLeftChild = false;
            if (requiredNode.Data < currentNodeParent.Data)
            {
                requiredNodeIsLeftChild = true;
            }

            //удаляемый узел имеет только левого сына - присоединить левое поддерево узла к его родителю.
            if (requiredNode.HasLeftChild() &&
                !requiredNode.HasRightChild())
            {
                var leftChild = requiredNode.GetLeftChild();

                if (requiredNodeIsLeftChild)
                {
                    currentNodeParent.DeleteLeftChild();
                    currentNodeParent.AddLeftChild(leftChild);
                }
                else
                {
                    currentNodeParent.DeleteRightChild();
                    currentNodeParent.AddRightChild(leftChild);
                }

                //возвращаем удалённый узел
                return requiredNode;
            }

            //удаляемый узел имеет только правого сына - присоединить правое поддерево узла к его родителю.
            if (!requiredNode.HasLeftChild() &&
                requiredNode.HasRightChild())
            {
                var rightChild = requiredNode.GetRightChild();

                if (requiredNodeIsLeftChild)
                {
                    currentNodeParent.DeleteLeftChild();
                    currentNodeParent.AddLeftChild(rightChild);
                }
                else
                {
                    currentNodeParent.DeleteRightChild();
                    currentNodeParent.AddRightChild(rightChild);
                }

                //возвращаем удалённый узел
                return requiredNode;
            }

            //Удаление узла с двумя сыновьями
            throw new NotImplementedException();
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

        public TreeNode<int> FindNode(int value, TreeNode<int> parent)
        {
            throw new System.NotImplementedException();
        }

        public TreeNode<int> GetRoot() => rootNode;

        public TreeNode<int> Insert(int value)
        {
            if (rootNode == null)
            {
                rootNode = new TreeNode<int>(value);

                nodeCount++;
                currentNodeParent = null;
                currentNode = rootNode;

                return currentNode;
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

            nodeCount++;

            return currentNode;
        }

        public TreeNode<int> Update(int value)
        {
            throw new System.NotImplementedException();
        }
    }
}