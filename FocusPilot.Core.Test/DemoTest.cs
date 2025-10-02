namespace FocusPilot.Core.Test;

public class DemoTest
{
    /// <summary>
    /// Verifies that FocusPilot.Core.Test is properly connected to FocusPilot.Core by testing a TmpDemo.AddTwo method
    /// </summary>
    /// <remarks>
    /// This test is just for validation of the test suite
    /// </remarks>
    /// <example>
    /// Example usage:
    /// <code>
    /// int result = TmpDemo.AddTwo(1, 2);
    /// Assert.Equal(3, result);
    /// </code>
    /// </example>
    [Fact]
    public void TestTmpDemo()
    {
        // Assemble
        int testNum1 = 1;
        int testNum2 = 2;
        int expected = 3;
        
        // Act
        int actual = TmpDemo.AddTwo(testNum1, testNum2);
        
        // Assert
        Assert.Equal(expected, actual);
    }
}
