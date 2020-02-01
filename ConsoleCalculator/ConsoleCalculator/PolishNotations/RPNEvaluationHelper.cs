﻿using System;
using System.Collections.Generic;

namespace ConsoleCalculator.PolishNotations
{
    public class RPNEvaluationHelper
    {
        private Stack<double> numbersStack = new Stack<double>();

        private MathOperationsHelper mathOperationsHelper = new MathOperationsHelper();

        public double Evaluate(ReversedPolishNotation reversedPolishNotation)
        {
            CheckArgument(reversedPolishNotation);

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
                        PerformSum();
                        break;

                    case TokenTypes.Minus:
                        PerformSubtraction();
                        break;

                    case TokenTypes.Multiplication:
                        PerformMultiplication();
                        break;

                    case TokenTypes.Division:
                        PerformDivision();
                        break;

                    case TokenTypes.OpeningBracket:
                    case TokenTypes.ClosingBracket:
                    case TokenTypes.Stopper:
                    case TokenTypes.Unassigned:
                        throw new Exception($"Неожидаемое значение {nameof(TokenTypes)}: {token.TokenType}");

                    default:
                        throw new Exception($"Неизвестное значение {nameof(TokenTypes)}: {token.TokenType}");
                }
            }

            PerformFinalCheck(reversedPolishNotation);

            return numbersStack.Pop();
        }

        private void PerformFinalCheck(ReversedPolishNotation reversedPolishNotation)
        {
            //в конце обработки в стеке должно остаться только одно число
            if (numbersStack.Count != 1)
            {
                throw new Exception($"Входное выражение некорретно.");
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
                throw new Exception($"Структура {nameof(numbersStack)} пуста, нечего возвращать.");
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
                throw new Exception($"В {nameof(reversedPolishNotation)} не инициализирован {nameof(reversedPolishNotation.Tokens)}");
            }

            if (reversedPolishNotation.Tokens.Count == 0)
            {
                throw new Exception($"Структура {nameof(reversedPolishNotation.Tokens)} в {nameof(reversedPolishNotation)} пуста.");
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