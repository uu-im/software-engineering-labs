using System;
using System.Collections.Generic;

class Program{
  public static void Main()
  {
    ICalculator calc = new Calculator();

    IList<ICalculatorCommand> commands = new List<ICalculatorCommand>(){
      new AddCommand(calc, 2),
      new AddCommand(calc, 3),
      new AddCommand(calc, 4),
      new SubtractCommand(calc, 10),
      new SubtractCommand(calc, 2)
    };

    // Execute all
    foreach(ICalculatorCommand c in commands)
      c.Execute();

    // Unexecute all
    foreach(ICalculatorCommand c in commands)
      c.Unexecute();
  }
}



interface ICalculator{
  void Add(double operand);
  void Subtract(double operand);
  void Divide(double operand);
  void Multiply(double operand);
}


interface ICalculatorCommand{
  void Execute();
  void Unexecute();
}


class Calculator : ICalculator{
  double result = 0;

  public void Add(double operand){
    result += operand;
    Console.WriteLine(result + " \t After Add " + operand);
  }

  public void Subtract(double operand){
    result -= operand;
    Console.WriteLine(result + " \t After Subtract " + operand);
  }

  public void Multiply(double operand){
    result *= operand;
    Console.WriteLine(result + " \t After Multiply " + operand);
  }

  public void Divide(double operand){
    result /= operand;
    Console.WriteLine(result + " \t After Divide " + operand);
  }
}


class AddCommand : ICalculatorCommand{
  ICalculator calculator;
  double operand;

  public AddCommand(ICalculator calc, double operand){
    this.calculator = calc;
    this.operand = operand;
  }

  public void Execute(){
    calculator.Add(operand);
  }

  public void Unexecute(){
    calculator.Subtract(operand);
  }
}


class SubtractCommand : ICalculatorCommand{
  ICalculator calculator;
  double operand;

  public SubtractCommand(ICalculator calc, double operand){
    this.calculator = calc;
    this.operand = operand;
  }

  public void Execute(){
    calculator.Subtract(operand);
  }

  public void Unexecute(){
    calculator.Add(operand);
  }
}
