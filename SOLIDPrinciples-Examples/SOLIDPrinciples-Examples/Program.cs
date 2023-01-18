// See https://aka.ms/new-console-template for more information
using System.Threading.Tasks.Dataflow;
using SOLIDPrinciples_Examples;
using static System.Console;

WriteLine("Welcome to Solid Principles- Examples");
WriteLine("==================Single Responsibility Principle=======================");
WriteLine("Single Responsibility Principle");
Caller.CallSingleResponsibility();
WriteLine("========================================================================");

WriteLine("=================Open-Closed Principle==================================");
Caller.CallOpenClosed();
WriteLine("========================================================================");

WriteLine("=================Open-Closed Principle-2==================================");
Caller.CallOpenClosedPrinciple2();
WriteLine("========================================================================");

WriteLine("================Liskov Substitution Principle===========================");
Caller.CallLiskovSubstitution();
WriteLine("========================================================================");