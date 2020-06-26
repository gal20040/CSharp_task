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

        private TreeNode<int> Delete(TreeNode<int> deletedNode)
        {
            #region удаляемый узел не имеет потомков - просто удаляем его у его родителя.
            if (deletedNode.IsLeaf())
            {
                if (currentNodeParent == null)
                {
                    //удаляемый узел является корнем и единственным узлом в дереве - удаляем только его.
                    rootNode = null;
                    currentNode = null;
                }
                else
                {
                    if (deletedNode.Data < currentNodeParent.Data)
                    {
                        currentNodeParent.DeleteLeftChild();
                    }
                    else
                    {
                        currentNodeParent.DeleteRightChild();
                    }
                }

                nodeCount--;

                //возвращаем удалённый узел
                return deletedNode;
            }
            #endregion

            # region удаляемый узел имеет только левого сына
            if (deletedNode.HasLeftChild() &&
                !deletedNode.HasRightChild())
            {
                {
                    var leftChild = deletedNode.GetLeftChild() as TreeNode<int>;

                    if (currentNodeParent == null)
                    {
                        //удаляемый узел является корнем - передвигаем указатель корня на левого сына.
                        rootNode = leftChild;
                        deletedNode.DeleteLeftChild();
                    }
                    else
                    {
                        //присоединить левое поддерево узла к его родителю
                        if (deletedNode.Data < currentNodeParent.Data)
                        {
                            currentNodeParent.DeleteLeftChild();
                            currentNodeParent.AddLeftChild(leftChild);
                        }
                        else
                        {
                            currentNodeParent.DeleteRightChild();
                            currentNodeParent.AddRightChild(leftChild);
                        }
                    }
                }

                nodeCount--;

                //возвращаем удалённый узел
                return deletedNode;
            }
            #endregion

            #region удаляемый узел имеет только правого сына - присоединить правое поддерево узла к его родителю.
            if (!deletedNode.HasLeftChild() &&
                deletedNode.HasRightChild())
            {
                var rightChild = deletedNode.GetRightChild() as TreeNode<int>;

                if (currentNodeParent == null)
                {
                    //удаляемый узел является корнем - передвигаем указатель корня на правого сына.
                    rootNode = rightChild;
                    deletedNode.DeleteRightChild();
                }
                else
                {
                    //присоединить правое поддерево узла к его родителю
                    if (deletedNode.Data < currentNodeParent.Data)
                    {
                        currentNodeParent.DeleteLeftChild();
                        currentNodeParent.AddLeftChild(rightChild);
                    }
                    else
                    {
                        currentNodeParent.DeleteRightChild();
                        currentNodeParent.AddRightChild(rightChild);
                    }
                }

                nodeCount--;

                //возвращаем удалённый узел
                return deletedNode;
            }
            #endregion

            #region удаление узла с двумя сыновьями
            var smallestValueFromTheRight = deletedNode.GetNodeWithTheSmallestValueFromTheRight(out ITreeNode<int> IParent) as TreeNode<int>;
            var parent = IParent as TreeNode<int>;

            #region удаляем ссылку на smallestValueFromTheRight у его родителя
            if (smallestValueFromTheRight.Data < parent.Data)
            {
                parent.DeleteLeftChild();
            }
            else
            {
                //случай, когда smallestValueFromTheRight (53) является правым сыном удаляемого узла (28):
                //  28
                //    \
                //     53
                //       \
                //        57
                parent.DeleteRightChild();
            }
            #endregion

            #region правое поддерево заменяющего узла существует - перемещаем его к родителю заменяющего узла
            if (smallestValueFromTheRight.HasRightChild())
            {

                if (smallestValueFromTheRight.Data < parent.Data)
                {
                    parent.AddLeftChild(smallestValueFromTheRight.GetRightChild()); //добавляем родителю ссылку на правого сына у smallestValueFromTheRight
                }
                else
                {
                    //случай, когда smallestValueFromTheRight (53) является правым сыном удаляемого узла (28):
                    //  28
                    //    \
                    //     53
                    //       \
                    //        57
                    parent.AddRightChild(smallestValueFromTheRight.GetRightChild()); //добавляем родителю ссылку на правого сына у smallestValueFromTheRight
                }

                smallestValueFromTheRight.DeleteRightChild(); //удаляем правого сына у smallestValueFromTheRight - теперь он лист
            }
            #endregion

            {
                var leftChild = deletedNode.GetLeftChild();
                var righttChild = deletedNode.GetRightChild();
                deletedNode.DeleteLeftChild();
                deletedNode.DeleteRightChild();

                smallestValueFromTheRight.AddLeftChild(leftChild); //добавляем ему ссылку на левого сына удаляемого узла
                smallestValueFromTheRight.AddRightChild(righttChild); //добавляем ему ссылку на правого сына удаляемого узла
            }

            if (currentNodeParent == null)
            {
                //удаляемый узел является корнем.
                rootNode = smallestValueFromTheRight;
            }
            else
            {
                if (deletedNode.Data < currentNodeParent.Data)
                {
                    currentNodeParent.DeleteLeftChild();
                    currentNodeParent.AddLeftChild(smallestValueFromTheRight);
                }
                else
                {
                    currentNodeParent.DeleteRightChild();
                    currentNodeParent.AddRightChild(smallestValueFromTheRight);
                }
            }

            nodeCount--;

            //возвращаем удалённый узел
            return deletedNode;
            #endregion
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