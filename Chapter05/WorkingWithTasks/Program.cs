using System.Diagnostics; //To use Stopwatch

OutputThreadInfo();
Stopwatch timer = Stopwatch.StartNew();
SectionTitle("Running methods synchronously on one thread.");
MethodA();
WriteLine($"{timer.ElapsedMilliseconds:#,##0}ms elapsed A.");
MethodB();
WriteLine($"{timer.ElapsedMilliseconds:#,##0}ms elapsed B.");
MethodC();

WriteLine($"{timer.ElapsedMilliseconds:#,##0}ms elapsed.");