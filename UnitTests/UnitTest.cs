using Lab5;

[TestClass]
public class WeightedGraphTests
{

    // Used AI to generate unit test ideas, refined from there
    private UndirectedWeightedGraph graph;

    [TestInitialize]
    public void Setup()
    {
        graph = new UndirectedWeightedGraph("../../../graphs/graph1-weighted.txt");
    }

    [TestMethod]
    public void ConnectedComponents_Returns1()
    {
        Assert.AreEqual(1, graph.ConnectedComponents);
    }

    [TestMethod]
    public void IsReachable_ValidNodes_ReturnsTrue()
    {
        Assert.IsTrue(graph.IsReachable("a", "c"));
        Assert.IsTrue(graph.IsReachable("a", "e"));
        Assert.IsTrue(graph.IsReachable("d", "c"));
    }

    [TestMethod]
    public void DFSPathBetween_AtoC_ReturnsCorrectPath()
    {
        var cost = graph.DFSPathBetween("a", "c", out List<Node> path);
        
        Assert.AreEqual(7, cost);
        CollectionAssert.AreEqual(
            new List<string> { "a", "b", "c" },
            path.ConvertAll(n => n.Name));
    }

    [TestMethod]
    public void BFSPathBetween_AtoD_ReturnsShortestEdges()
    {
        var cost = graph.BFSPathBetween("a", "d", out List<Node> path);
        
        Assert.AreEqual(3, cost);
        CollectionAssert.AreEqual(
            new List<string> { "a", "b", "d" },
            path.ConvertAll(n => n.Name));
    }

    [TestMethod]
    public void DijkstraPathBetween_AtoE_ReturnsShortestWeight()
    {
        var cost = graph.DijkstraPathBetween("a", "e", out List<Node> path);
        
        Assert.AreEqual(5, cost);
        CollectionAssert.AreEqual(
            new List<string> { "a", "b", "e" },
            path.ConvertAll(n => n.Name));
    }

    [TestMethod]
    public void PathBetween_InvalidNodes_ReturnsZero()
    {
        var cost = graph.DijkstraPathBetween("a", "z", out List<Node> path);
        Assert.AreEqual(0, cost);
        Assert.AreEqual(0, path.Count);
    }
}