using System;
using System.Collections.Generic;

namespace ConsoleCalculator.PolishNotations
{
    public class RPNEvaluationHelper
    {
        private readonly Stack<double> numbersStack = new Stack<double>();

        private readonly MathOperationsHelper mathOperationsHelper = new MathOperationsHelper();

        public double Evaluate(ReversedPolishNotation reversedPolishNotation)
        {
            CheckArgument(reversedPolishNotation);
            DetermineMathActions();

            var tokens = reversedPolishNotation.Tokens;
            Token token;

            while (tokens.Count > 0)
            {
                token = tokens.Dequeue();

                switch (token.TokenType)
                {
                    case TokenTypes.Number:
                        numbersStack.Push(token.Number);
                        continue;

                    case TokenTypes.Plus:
                    case TokenTypes.Minus:
                    case TokenTypes.Multiplication:
                    case TokenTypes.Division:
                        mathActions[token.TokenType]();
                        break;

                    case TokenTypes.OpeningBracket:
                    case TokenTypes.ClosingBracket:
                    case TokenTypes.Stopper:
                    case TokenTypes.Unassigned:
                        throw new Exception($"Неожидаемое значение {nameof(TokenTypes)}: {token.TokenType}");

                    default:
                        throw new Exception(string.Format(Settings.UnknownValueTemplate, nameof(TokenTypes), token.TokenType));
                }
            }

            PerformFinalCheck();

            return numbersStack.Pop();
        }

        private void PerformFinalCheck()
        {
            //в конце обработки в стеке должно остаться только одно число
            if (numbersStack.Count != 1)
            {
                throw new Exception($"В конце вычисления в {numbersStack} должно остаться 1 число - результат вычисления, текущее кол-во элементов: {numbersStack.Count}.");
            }
        }

        private double GetNumber(Stack<double> numbersStack)
        {
            #region Check
            if (numbersStack == null)
            {
                throw new ArgumentNullException(nameof(numbersStack));
            }

            if (numbersStack.Count == 0)
            {
                throw new Exception(string.Format(Settings.NoItemsTemplate, nameof(numbersStack)));
            }
            #endregion

            return numbersStack.Pop();
        }

        private void CheckArgument(ReversedPolishNotation reversedPolishNotation)
        {
            if (reversedPolishNotation == null)
            {
                throw new ArgumentNullException(nameof(reversedPolishNotation));
            }

            if (reversedPolishNotation.Tokens == null)
            {
                throw new ArgumentNullException(nameof(reversedPolishNotation.Tokens));
            }

            if (reversedPolishNotation.Tokens.Count == 0)
            {
                throw new Exception(string.Format(Settings.NoItemsTemplate, nameof(reversedPolishNotation.Tokens)));
            }
        }

        /// <summary>Действия (математическая операция), которые необходимо выполнить для переданного TokenTypes</summary>
        private readonly Dictionary<TokenTypes, Action> mathActions = new Dictionary<TokenTypes, Action>();

        private void DetermineMathActions()
        {
            mathActions[TokenTypes.Plus] = PerformSum;
            mathActions[TokenTypes.Minus] = PerformSubtraction;
            mathActions[TokenTypes.Multiplication] = PerformMultiplication;
            mathActions[TokenTypes.Division] = PerformDivision;
        }

        private void PerformSum()
        {
            var y = GetNumber(numbersStack);
            var x = GetNumber(numbersStack);
            var operResult = mathOperationsHelper.Sum(x, y);
            numbersStack.Push(operResult);
        }

        private void PerformSubtraction()
        {
            var y = GetNumber(numbersStack);
            var x = GetNumber(numbersStack);
            var operResult = mathOperationsHelper.Subtract(x, y);
            numbersStack.Push(operResult);
        }

        private void PerformMultiplication()
        {
            var y = GetNumber(numbersStack);
            var x = GetNumber(numbersStack);
            var operResult = mathOperationsHelper.Multiply(x, y);
            numbersStack.Push(operResult);
        }

        private void PerformDivision()
        {
            var y = GetNumber(numbersStack);
            var x = GetNumber(numbersStack);
            var operResult = mathOperationsHelper.Divide(x, y);
            numbersStack.Push(operResult);
        }
    }
}