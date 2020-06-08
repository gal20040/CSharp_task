using System;
using System.Text.RegularExpressions;

namespace DataStructures.BinaryTree
{
    public class TreeNode<T>
    {
        private TreeNode<T> leftChild;
        private TreeNode<T> rightChild;

        public T Data;

        public TreeNode(T data, TreeNode<T> leftChild = null, TreeNode<T> rightChild = null)
        {
            //todo data не может быть null, но я не знаю, как сделать в данном случае проверку data на null
            Data = data;
            this.leftChild = leftChild;
            this.rightChild = rightChild;
        }

        public TreeNode<T> getLeftChild() => leftChild;

        public TreeNode<T> getRightChild() => rightChild;

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
        /// <summary>Подсчитать количество листьев в данном поддереве.</summary>
        /// <returns>Количество листьев в данном поддереве.</returns>
        public int CountLeaves() => CountLeaves(this);

        private int CountLeaves(TreeNode<T> tree)
        {
            // рекурсивное прохождение завершается на пустом поддереве
            if (tree is null) return 0;

            if (tree.IsLeaf()) return 1;

            return CountLeaves(tree.leftChild) + CountLeaves(tree.rightChild);
        }

        public bool IsLeaf() => leftChild == null && rightChild == null;
        #endregion

        #region Depth
        /// <summary>Вычисляет глубину дерева.</summary>
        public int Depth() => Depth(this) - 1; //todo не знаю, как избавиться от лишнего уровня глубины

        private int Depth(TreeNode<T> tree)
        {
            // рекурсивное прохождение завершается на пустом поддереве
            if (tree is null) return 0;

            var depthLeft = Depth(tree.leftChild);
            var depthRight = Depth(tree.rightChild);
            var depth = 1 + (depthLeft >= depthRight ? depthLeft : depthRight);

            return depth;
        }
        #endregion

        #region CopyTree
        /// <summary>Создаёт дубликат дерева tree и возвращает корень нового дерева.</summary>
        /// <param name="tree"></param>
        /// <returns></returns>
        public TreeNode<T> CopyTree() => CopyTree(this);

        private TreeNode<T> CopyTree(TreeNode<T> tree)
        {
            // остановить рекурсивное прохождение при достижении пустого дерева
            if (tree == null) return null;

            // строит новое дерево снизу вверх, сначала создавая двух сыновей, а затем их родителя

            TreeNode<T> newLeftChild = null;
            if (tree.leftChild != null)
                newLeftChild = CopyTree(tree.leftChild);

            TreeNode<T> newRightChild = null;
            if (tree.rightChild != null)
                newRightChild = CopyTree(tree.rightChild);

            var newNode = new TreeNode<T>(tree.Data, newLeftChild, newRightChild);

            return newNode;
        }
        #endregion

        #region ToString
        public override string ToString()
        {
            var res = ToStringInOrder(this).Trim();
            return Regex.Replace(res, "[ ]+", " ");
        }

        private string ToStringInOrder(TreeNode<T> tree)
        {
            // остановить рекурсивное прохождение при достижении пустого дерева
            if (tree == null) return "";

            var result = "";

            if (tree.leftChild != null)
                result += ToStringInOrder(tree.leftChild);

            result += $"{tree.Data.ToString()} ";

            if (tree.rightChild != null)
                result += ToStringInOrder(tree.rightChild);

            return result;
        }
        #endregion
    }
}