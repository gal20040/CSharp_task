using System;
using System.Text.RegularExpressions;

namespace DataStructures.BinaryTree
{
    public class TreeNode<T> : ITreeNode<T>
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

        #region add child
        public ITreeNode<T> AddLeftChild(ITreeNode<T> leftChild)
        {
            if (leftChild is null) throw new System.ArgumentNullException(nameof(leftChild));

            if (this.leftChild is null)
            {
                this.leftChild = leftChild as TreeNode<T>;
            }
            else
            {
                throw new System.ArgumentException($"{nameof(this.leftChild)} is not null");
            }

            return this;
        }

        public ITreeNode<T> AddRightChild(ITreeNode<T> rightChild)
        {
            if (rightChild is null) throw new System.ArgumentNullException(nameof(rightChild));

            if (this.rightChild is null)
            {
                this.rightChild = rightChild as TreeNode<T>;
            }
            else
            {
                throw new System.ArgumentException($"{nameof(this.rightChild)} is not null");
            }

            return this;
        }
        #endregion

        #region get children
        public ITreeNode<T> GetLeftChild() => leftChild;

        public ITreeNode<T> GetRightChild() => rightChild;
        #endregion

        #region has child
        public bool HasLeftChild() => leftChild != null;

        public bool HasRightChild() => rightChild != null;

        public ITreeNode<T> GetNodeWithTheLargestValueFromTheLeft(out ITreeNode<T> parent)
        {
            parent = this;
            var currentNode = leftChild;

            while (currentNode != null)
            {
                if (currentNode.HasRightChild())
                {
                    parent = currentNode;
                    currentNode = currentNode.rightChild; 
                }
                else
                    break;
            }

            return currentNode;
        }

        public ITreeNode<T> GetNodeWithTheSmallestValueFromTheRight(out ITreeNode<T> parent)
        {
            parent = this;
            var currentNode = rightChild;

            while (currentNode != null)
            {
                if (currentNode.HasLeftChild())
                {
                    parent = currentNode;
                    currentNode = currentNode.leftChild;
                }
                else
                    break;
            }

            return currentNode;
        }
        #endregion

        //#region Обход деревьев
        ///// <summary>Прямое рекурсивное прохождение узлов дерева</summary>
        ///// <param name="tree">Узел дерева для прохождения</param>
        //public void PreOrder(TreeNode<T> tree)
        //{
        //    // рекурсивное прохождение завершается на пустом поддереве
        //    if (tree is null) return;

        //    // посетить узел
        //    visit(tree->data);

        //    // спуститься по левому поддереву
        //    PreOrder(tree.getLeftChild());

        //    // спуститься по правому поддереву
        //    PreOrder(tree.getRightChild());
        //}

        ///// <summary>Симметричное рекурсивное прохождение узлов дерева</summary>
        ///// <param name="tree">Узел дерева для прохождения</param>
        //public void InOrder(TreeNode<T> tree)
        //{
        //    // рекурсивное прохождение завершается на пустом поддереве
        //    if (tree is null) return;

        //    // спуститься по левому поддереву
        //    InOrder(tree.getLeftChild());

        //    // посетить узел
        //    visit(tree->data);

        //    // спуститься по правому поддереву
        //    InOrder(tree.getRightChild());
        //}

        ///// <summary>Обратное рекурсивное прохождение узлов дерева</summary>
        ///// <param name="tree">Узел дерева для прохождения</param>
        //public void PostOrder(TreeNode<T> tree)
        //{
        //    // рекурсивное прохождение завершается на пустом поддереве
        //    if (tree is null) return;

        //    // спуститься по левому поддереву
        //    PostOrder(tree.getLeftChild());

        //    // спуститься по правому поддереву
        //    PostOrder(tree.getRightChild());

        //    // посетить узел
        //    visit(tree->data);
        //}
        //#endregion

        #region CountLeaves
        public int CountLeaves() => CountLeaves(this);

        private int CountLeaves(ITreeNode<T> tree)
        {
            // рекурсивное прохождение завершается на пустом поддереве
            if (tree is null) return 0;

            var treeNode = tree as TreeNode<T>;

            if (treeNode.IsLeaf()) return 1;

            return CountLeaves(treeNode.leftChild) + CountLeaves(treeNode.rightChild);
        }

        public bool IsLeaf() => !HasLeftChild() && !HasRightChild();
        #endregion

        #region delete child
        public ITreeNode<T> DeleteLeftChild()
        {
            var nodeForDelete = leftChild;

            leftChild = null;

            return nodeForDelete;
        }

        public ITreeNode<T> DeleteRightChild()
        {
            var nodeForDelete = rightChild;

            rightChild = null;

            return nodeForDelete;
        }
        #endregion

        #region Depth
        public int Depth() => Depth(this) - 1; //todo не знаю, как избавиться от лишнего уровня глубины

        private int Depth(ITreeNode<T> tree)
        {
            // рекурсивное прохождение завершается на пустом поддереве
            if (tree is null) return 0;

            var treeNode = tree as TreeNode<T>;

            var depthLeft = Depth(treeNode.leftChild);
            var depthRight = Depth(treeNode.rightChild);
            var depth = 1 + (depthLeft >= depthRight ? depthLeft : depthRight);

            return depth;
        }
        #endregion

        #region CopyTree
        public ITreeNode<T> CopyTree() => CopyTree(this);

        private TreeNode<T> CopyTree(ITreeNode<T> tree)
        {
            // остановить рекурсивное прохождение при достижении пустого дерева
            if (tree == null) return null;

            // строит новое дерево снизу вверх, сначала создавая двух сыновей, а затем их родителя

            var treeNode = tree as TreeNode<T>;

            var newLeftChild = CopyTree(treeNode.leftChild);

            var newRightChild = CopyTree(treeNode.rightChild);

            var newNode = new TreeNode<T>(treeNode.Data, newLeftChild, newRightChild);

            return newNode;
        }
        #endregion

        #region ToString
        public override string ToString()
        {
            var res = ToStringInOrder(this).Trim();
            return Regex.Replace(res, "[ ]+", " ");
        }

        private string ToStringInOrder(ITreeNode<T> tree)
        {
            // остановить рекурсивное прохождение при достижении пустого дерева
            if (tree == null) return "";

            var result = "";

            var treeNode = tree as TreeNode<T>;

            if (treeNode.HasLeftChild())
                result += ToStringInOrder(treeNode.leftChild);

            result += $"{treeNode.Data} ";

            if (treeNode.HasRightChild())
                result += ToStringInOrder(treeNode.rightChild);

            return result;
        }
        #endregion
    }
}