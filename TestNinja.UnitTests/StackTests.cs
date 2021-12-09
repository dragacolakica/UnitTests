using NUnit.Framework;
using System.Collections;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        [Test]
        [TestCase(1)]
        public void StackPush_ReturnCountMore(int a)
        {
            var stack = new Stack<int>();
            stack.Push(a);
            Assert.That(stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void StackPush_ThrowArgumentNullException()
        {
            var stack = new Stack<string>();
            Assert.That(() => stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Count_EmptyStack_ReturnZero()
        {
            var stack = new Stack();
            Assert.That(stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Stack_EmptyPop_ThrowInvalidOperationException()
        {
            var stack = new Stack<string>();
            Assert.That(() => stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void StackPop_ReturnObjectOnTheTop()
        {
            var stack = new Stack<string>();
            stack.Push("1");
            stack.Push("2");
            stack.Push("3");

            var result = stack.Pop();

            Assert.That(result, Is.EqualTo("3"));
        }

        [Test]
        public void StackPop_RemoveObjectOnTheTop()
        {
            var stack = new Stack<string>();
            stack.Push("1");
            stack.Push("2");
            stack.Push("3");

            var result = stack.Pop();

            Assert.That(stack.Count, Is.EqualTo(2));
        }

        [Test]
        public void Peek_EmptyStack_ThrowsInvalidOperationException()
        {
            var stack = new Stack<string>();
            Assert.That(() => stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_ReturnItemOnTop()
        {
            var stack = new Stack<string>();
            stack.Push("1");
            stack.Push("2");
            stack.Push("3");

            var result = stack.Peek();

            Assert.That(result, Is.EqualTo("3"));
        }
        [Test]
        public void Peek_DoesNotRemoveObjectOnTop()
        {
            var stack = new Stack<string>();
            stack.Push("1");
            stack.Push("2");
            stack.Push("3");

            var result = stack.Peek();

            Assert.That(stack.Count, Is.EqualTo(3));
        }

    }
}
