using Exercices.Luhn;
using System;
using Xunit;

namespace Exercices.Tests.Luhn
{
    public class LuhnCheckServiceTests
    {
        private readonly LuhnCheckService sut = new LuhnCheckService();

        [Fact]
        public void IsValid_Throws_ArgumentNullException_NullText()
        {
            // arrange
            Func<object> act = () => sut.IsValid(null);

            // act & assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("               ")]
        [InlineData("a")]
        [InlineData("1")]
        public void IsValid_Throws_InvalidOperationException_StringSizeInvalid(string text)
        {
            // arrange
            Func<object> act = () => sut.IsValid(text);

            // act & assert
            Assert.Throws<InvalidOperationException>(act);
        }


        [Theory]
        [InlineData("   4539 1488 0343 6467")]
        [InlineData("4539 1488 0343 6467    ")]
        [InlineData("4539 1488 0343 6467")]
        [InlineData("4539 148803436467")]
        [InlineData("4539148803436467")]
        public void IsValid_ReturnsTrue_CreditCard_IsValid(string text)
        {
            // act
            var result = sut.IsValid(text);

            // arrange
            Assert.True(result);
        }

        [Theory]
        [InlineData("   8273 1232 7352 0569")]
        [InlineData("8273 1232 7352 0569    ")]
        [InlineData("8273 1232 7352 0569")]
        [InlineData("8273 123273520569")]
        [InlineData("8273123273520569")]
        public void IsValid_ReturnsFalse_CreditCard_IsInvalid(string text)
        {
            // act
            var result = sut.IsValid(text);

            // arrange
            Assert.False(result);
        }
    }
}
