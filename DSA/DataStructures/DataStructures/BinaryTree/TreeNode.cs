using System;

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
    }
}