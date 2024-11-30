using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace DotnetSpanExamples;

[MemoryDiagnoser]
[HideColumns("Error", "StdDev", "Median", "RatioSD", "Gen0")]
public class SpanTest
{
    public string Substring()
    {
        string str = "Hello, World!";
        return str.Substring(7);
    }

    [Benchmark(Baseline = true)]
    public string SubstringBenchmark()
    {
        return Substring();
    }

    public ReadOnlySpan<char> Slice()
    {
        ReadOnlySpan<char> span = "Hello, World!";
        return span.Slice(7);
    }

    [Benchmark]
    public string SliceBenchmark()
    {
        return Slice().ToString();
    }
}

public class Program
{
    private static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<SpanTest>();
    }
}
