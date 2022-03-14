using System.Collections.Generic;

namespace Exercices.DisplayTree
{
    public class DisplayTreeService
    {
        public string[] GetAllBranchesFullPath<T>(Node<T> tree)
        {
            List<string> branchPaths = new List<string>();
            SetAllBranchesFullPath(tree, "", branchPaths);
            return branchPaths.ToArray();
        }

        public void SetAllBranchesFullPath<T>(Node<T> tree, string path, List<string> branchPaths)
        {
            if (tree == null)
                return;

            path = path + tree.Value;

            if (tree.Left == null && tree.Right == null)
            {
                branchPaths.Add(path);
                return;
            }

            path = path + "->";

            SetAllBranchesFullPath(tree.Left, path, branchPaths);


            SetAllBranchesFullPath(tree.Right, path, branchPaths);
        }
    }
}
