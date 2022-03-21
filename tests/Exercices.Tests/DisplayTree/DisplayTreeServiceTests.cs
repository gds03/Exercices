using Exercices.DisplayTree;

using Shouldly;

using System;
using System.Collections.Generic;
using System.Text;

using Xunit;

namespace Exercices.Tests.DisplayTree;

public class DisplayTreeServiceTests
{
    [Fact]
    public void DisplayEachBranch_Should_ReturnCorrectly()
    {
        Node<int> tree = new Node<int>();

        tree.Value = 5;
        tree.Left = new Node<int>
        {
            Value = 2,
            Left = new Node<int>
            {
                Value = 10
            },
            Right = new Node<int>
            {
                Value = 4
            }
        };
        tree.Right = new Node<int>
        {
            Value = -3
        };

        DisplayTreeService sut = new DisplayTreeService();
        var result = sut.GetAllBranchesFullPath(tree);

        result[0].ShouldBe("5->2->10");
        result[1].ShouldBe("5->2->4");
        result[2].ShouldBe("5->-3");
    }
}
