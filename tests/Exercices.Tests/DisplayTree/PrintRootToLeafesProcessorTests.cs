using Exercices.DisplayTree;

using Shouldly;

using Xunit;

namespace Exercices.Tests.DisplayTree;

public class PrintRootToLeafesProcessorTests
{
    [Fact]
    public void PrintRootToLeafesProcessor_Print_Should_Return_Successfully()
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

        var sut = new PrintRootToLeafesProcessor();
        var result = sut.Print(tree);

        result[0].ShouldBe("5->2->10");
        result[1].ShouldBe("5->2->4");
        result[2].ShouldBe("5->-3");
    }
}
