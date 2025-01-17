using BenchmarkDotNet.Running;
using EFCorePerf;

//EFCoreBenchmark.Init(100000);

//BenchmarkRunner.Run<EFCoreBenchmark>();

EFCoreBenchmark bench = new();
//bench.RunGetEntityEager();
//bench.RunGetEntityLazy();
//bench.RunGetBusinessEager();
//bench.RunGetBusinessLazy();

bench.RunGetEntityEagerAsSplitQuery();
