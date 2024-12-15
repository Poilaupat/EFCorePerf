using BenchmarkDotNet.Running;
using EFCorePerf;

//EFCoreBenchmark.Init(97000);

BenchmarkRunner.Run<EFCoreBenchmark>();

//EFCoreBenchmark bench = new();
//bench.RunGetEntityEager();
//bench.RunGetEntityLazy();

