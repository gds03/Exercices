using System.Collections.Generic;

namespace Exercices.DisplayTree
{
    public class PrintRootToLeafesProcessor
    {
        public string[] Print<T>(Node<T> tree)
        {
            if (tree == null) return null;
            List<string> paths = new();
            string currentPath = "";

            Explore(tree, currentPath, paths);
            return paths.ToArray();
        }

        public void Explore<T>(Node<T> node, string path, List<string> paths)
        {
            if(node == null) return;
            path += node.Value;

            if (IsLeaf(node))
            {
                paths.Add(path);
                return;
            }

            path += "->";

            Explore(node.Left, path, paths);
            Explore(node.Right, path, paths);
        }

        static bool IsLeaf<T>(Node<T> node) => node.Left == null && node.Right == null;
    }
}
