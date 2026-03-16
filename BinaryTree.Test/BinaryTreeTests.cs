using BinaryTree.Lib;

namespace BinaryTree.Test;

[TestClass]
public sealed class BinaryTreeTests
{
    [TestMethod]
    public void TestToStringExplicit()
    {
        var bt = new Lib.BinaryTree(5);
        bt.Insert(7);
        bt.Insert(2);
        Assert.AreEqual("{2, 5, 7}", bt.ToString());
    }

    [TestMethod]
    public void TestContainsWhenPresent()
    {
        var bt = new Lib.BinaryTree([5,7,9]);
        Assert.IsTrue(bt.Contains(7));
    }

    [TestMethod]
    public void TestContainsWhenNotPresent()
    {
        var bt = new Lib.BinaryTree([5,7,9]);
        Assert.IsFalse(bt.Contains(10));
    }
    
    [TestMethod]
    public void TestSum()
    {
        var bt = new Lib.BinaryTree(5);
        bt.Insert(7);
        bt.Insert(9);
        Assert.AreEqual(21, bt.Sum);
    }

    [TestMethod]
    public void TestDuplicates()
    {
        var bt = new Lib.BinaryTree([5,3,7,9,3]);
        Assert.IsTrue(bt.Duplicates());
    }

    [TestMethod]
    public void TestDepth()
    {
        var bt = new Lib.BinaryTree([5,3,7,2,4,6,8]);
        Assert.AreEqual(3, bt.Depth());
    }

    [TestMethod]
    public void TestIsBalanced()
    {
        var bt = new Lib.BinaryTree([5,3,7,2,4,6,8]);
        Assert.IsTrue(bt.IsBalanced);
    }
}
