using System;
using System.Collections.Generic;

namespace ConsoleCalculator.PolishNotations
{
    public class PolishNotaionHelper
    {
        /// <summary>Обратная польская нотация</summary>
        private PolishNotation reversedPolishNotation;

        /// <summary>Стек операций</summary>
        private Stack<Token> operationsStack;

        /// <summary>Входная очередь токенов в инфиксной форме</summary>
        private Queue<Token> tokens;

        /// <summary>Действия, которые необходимо выполнить для кортежа из двух TokenTypes.
        /// Первый TokenTypes - текущий токен из Queue<Token> tokens.
        /// Второй TokenTypes - верхний токен в Stack<Token> operationsStack.
        /// </summary>
        private readonly Dictionary<(TokenTypes, TokenTypes), Action> inputTokenActions = new Dictionary<(TokenTypes, TokenTypes), Action>();

        private void DetermineInputTokenActions()
        {
            /*
               |      |          NextToken           |
              O|------|------|---|---|---|---|---|---|
              p|      | Stop | + | - | * | / | ( | ) |
              e|------|------|---|---|---|---|---|---|
              r| Stop |  4   | 1 | 1 | 1 | 1 | 1 | 5 |
              a|  +   |  2   | 2 | 2 | 1 | 1 | 1 | 2 |
              t|  -   |  2   | 2 | 2 | 1 | 1 | 1 | 2 |
              i|  *   |  2   | 2 | 2 | 2 | 2 | 1 | 2 |
              o|  /   |  2   | 2 | 2 | 2 | 2 | 1 | 2 |
              n|  (   |  5   | 1 | 1 | 1 | 1 | 1 | 3 |
              s|------|------|---|---|---|---|---|---|
             
            //1 PushToOperationsStackAndGoToNextToken
            //2 MoveFromOperationsStackToRpnQueueAndStayAtCurrToken
            //3 PopFromOperationsStackAndAndGoToNextToken
            //4 FinalizeCalculation
            //5 InterruptDueToErrorInInputEquation
            //6 EnqueueToRpnQueueAndGoToNextToken //число всегда закидываем в rpnQueue
            */

            //число всегда закидываем в rpnQueue
            var currToken = TokenTypes.Number; //текущий токен из Queue<Token> tokens
            {
                inputTokenActions[(currToken, TokenTypes.Stopper)] = EnqueueToRpnQueueAndGoToNextToken;
                inputTokenActions[(currToken, TokenTypes.Plus)] = EnqueueToRpnQueueAndGoToNextToken;
                inputTokenActions[(currToken, TokenTypes.Minus)] = EnqueueToRpnQueueAndGoToNextToken;
                inputTokenActions[(currToken, TokenTypes.Multiplication)] = EnqueueToRpnQueueAndGoToNextToken;
                inputTokenActions[(currToken, TokenTypes.Division)] = EnqueueToRpnQueueAndGoToNextToken;
                inputTokenActions[(currToken, TokenTypes.OpeningBracket)] = EnqueueToRpnQueueAndGoToNextToken;
                //inputTokenActions[(currToken, TokenTypes.ClosingBracket)] = InterruptDueToErrorInInputEquation;
            }

            currToken = TokenTypes.Stopper; //текущий токен из Queue<Token> tokens
            {
                inputTokenActions[(currToken, TokenTypes.Unassigned)] = PushToOperationsStackAndGoToNextToken; //когда в operationsStack ещё ничего нет
                inputTokenActions[(currToken, TokenTypes.Stopper)] = FinalizeCalculation;
                inputTokenActions[(currToken, TokenTypes.Plus)] = MoveFromOperationsStackToRpnQueueAndStayAtCurrToken;
                inputTokenActions[(currToken, TokenTypes.Minus)] = MoveFromOperationsStackToRpnQueueAndStayAtCurrToken;
                inputTokenActions[(currToken, TokenTypes.Multiplication)] = MoveFromOperationsStackToRpnQueueAndStayAtCurrToken;
                inputTokenActions[(currToken, TokenTypes.Division)] = MoveFromOperationsStackToRpnQueueAndStayAtCurrToken;
                inputTokenActions[(currToken, TokenTypes.OpeningBracket)] = InterruptDueToErrorInInputEquation;
                //inputTokenActions[(currToken, TokenTypes.ClosingBracket)] = InterruptDueToErrorInInputEquation;
            }

            currToken = TokenTypes.Plus; //текущий токен из Queue<Token> tokens
            {
                inputTokenActions[(currToken, TokenTypes.Stopper)] = PushToOperationsStackAndGoToNextToken;
                inputTokenActions[(currToken, TokenTypes.Plus)] = MoveFromOperationsStackToRpnQueueAndStayAtCurrToken;
                inputTokenActions[(currToken, TokenTypes.Minus)] = MoveFromOperationsStackToRpnQueueAndStayAtCurrToken;
                inputTokenActions[(currToken, TokenTypes.Multiplication)] = MoveFromOperationsStackToRpnQueueAndStayAtCurrToken;
                inputTokenActions[(currToken, TokenTypes.Division)] = MoveFromOperationsStackToRpnQueueAndStayAtCurrToken;
                inputTokenActions[(currToken, TokenTypes.OpeningBracket)] = PushToOperationsStackAndGoToNextToken;
                //inputTokenActions[(currToken, TokenTypes.ClosingBracket)] = ;
            }

            currToken = TokenTypes.Minus; //текущий токен из Queue<Token> tokens
            {
                inputTokenActions[(currToken, TokenTypes.Stopper)] = PushToOperationsStackAndGoToNextToken;
                inputTokenActions[(currToken, TokenTypes.Plus)] = MoveFromOperationsStackToRpnQueueAndStayAtCurrToken;
                inputTokenActions[(currToken, TokenTypes.Minus)] = MoveFromOperationsStackToRpnQueueAndStayAtCurrToken;
                inputTokenActions[(currToken, TokenTypes.Multiplication)] = MoveFromOperationsStackToRpnQueueAndStayAtCurrToken;
                inputTokenActions[(currToken, TokenTypes.Division)] = MoveFromOperationsStackToRpnQueueAndStayAtCurrToken;
                inputTokenActions[(currToken, TokenTypes.OpeningBracket)] = PushToOperationsStackAndGoToNextToken;
                //inputTokenActions[(currToken, TokenTypes.ClosingBracket)] = ;
            }

            currToken = TokenTypes.Multiplication; //текущий токен из Queue<Token> tokens
            {
                inputTokenActions[(currToken, TokenTypes.Stopper)] = PushToOperationsStackAndGoToNextToken;
                inputTokenActions[(currToken, TokenTypes.Plus)] = PushToOperationsStackAndGoToNextToken;
                inputTokenActions[(currToken, TokenTypes.Minus)] = PushToOperationsStackAndGoToNextToken;
                inputTokenActions[(currToken, TokenTypes.Multiplication)] = MoveFromOperationsStackToRpnQueueAndStayAtCurrToken;
                inputTokenActions[(currToken, TokenTypes.Division)] = MoveFromOperationsStackToRpnQueueAndStayAtCurrToken;
                inputTokenActions[(currToken, TokenTypes.OpeningBracket)] = PushToOperationsStackAndGoToNextToken;
                //inputTokenActions[(currToken, TokenTypes.ClosingBracket)] = ;
            }

            currToken = TokenTypes.Division; //текущий токен из Queue<Token> tokens
            {
                inputTokenActions[(currToken, TokenTypes.Stopper)] = PushToOperationsStackAndGoToNextToken;
                inputTokenActions[(currToken, TokenTypes.Plus)] = PushToOperationsStackAndGoToNextToken;
                inputTokenActions[(currToken, TokenTypes.Minus)] = PushToOperationsStackAndGoToNextToken;
                inputTokenActions[(currToken, TokenTypes.Multiplication)] = MoveFromOperationsStackToRpnQueueAndStayAtCurrToken;
                inputTokenActions[(currToken, TokenTypes.Division)] = MoveFromOperationsStackToRpnQueueAndStayAtCurrToken;
                inputTokenActions[(currToken, TokenTypes.OpeningBracket)] = PushToOperationsStackAndGoToNextToken;
                //inputTokenActions[(currToken, TokenTypes.ClosingBracket)] = ;
            }

            currToken = TokenTypes.OpeningBracket; //текущий токен из Queue<Token> tokens
            {
                inputTokenActions[(currToken, TokenTypes.Stopper)] = PushToOperationsStackAndGoToNextToken;
                inputTokenActions[(currToken, TokenTypes.Plus)] = PushToOperationsStackAndGoToNextToken;
                inputTokenActions[(currToken, TokenTypes.Minus)] = PushToOperationsStackAndGoToNextToken;
                inputTokenActions[(currToken, TokenTypes.Multiplication)] = PushToOperationsStackAndGoToNextToken;
                inputTokenActions[(currToken, TokenTypes.Division)] = PushToOperationsStackAndGoToNextToken;
                inputTokenActions[(currToken, TokenTypes.OpeningBracket)] = PushToOperationsStackAndGoToNextToken;
                //inputTokenActions[(currToken, TokenTypes.ClosingBracket)] = ;
            }

            currToken = TokenTypes.ClosingBracket; //текущий токен из Queue<Token> tokens
            {
                inputTokenActions[(currToken, TokenTypes.Stopper)] = InterruptDueToErrorInInputEquation;
                inputTokenActions[(currToken, TokenTypes.Plus)] = MoveFromOperationsStackToRpnQueueAndStayAtCurrToken;
                inputTokenActions[(currToken, TokenTypes.Minus)] = MoveFromOperationsStackToRpnQueueAndStayAtCurrToken;
                inputTokenActions[(currToken, TokenTypes.Multiplication)] = MoveFromOperationsStackToRpnQueueAndStayAtCurrToken;
                inputTokenActions[(currToken, TokenTypes.Division)] = MoveFromOperationsStackToRpnQueueAndStayAtCurrToken;
                inputTokenActions[(currToken, TokenTypes.OpeningBracket)] = PopFromOperationsStackAndAndGoToNextToken;
                //inputTokenActions[(currToken, TokenTypes.ClosingBracket)] = ;
            }
        }

        private void PerformAction()
        {
            (TokenTypes, TokenTypes) tokenTuple;
            var inputToken = tokens.Peek();

            if (operationsStack.Count > 0)
            {
                var topOperationsStackToken = operationsStack.Peek();
                tokenTuple = (inputToken.TokenType, topOperationsStackToken.TokenType);
            }
            else
            {
                tokenTuple = (inputToken.TokenType, TokenTypes.Unassigned);
            }

            if (inputTokenActions.ContainsKey(tokenTuple))
            {
                inputTokenActions[tokenTuple]();
            }
            else
            {
                throw new ArgumentException("Неизвестный тип задания");
            }
        }

        private void EnqueueToRpnQueueAndGoToNextToken()
        {
            var inputToken = tokens.Dequeue();
            reversedPolishNotation.Tokens.Enqueue(inputToken);
        }

        private void PushToOperationsStackAndGoToNextToken()
        {
            var inputToken = tokens.Dequeue();
            operationsStack.Push(inputToken);
        }

        private void MoveFromOperationsStackToRpnQueueAndStayAtCurrToken()
        {
            var operationsStackToken = operationsStack.Pop();
            reversedPolishNotation.Tokens.Enqueue(operationsStackToken);
        }

        private void PopFromOperationsStackAndAndGoToNextToken()
        {
            operationsStack.Pop();
            tokens.Dequeue();
        }

        private void FinalizeCalculation()
        {
            tokens.Dequeue(); //Dequeue последний токен из входной очереди
        }

        private void InterruptDueToErrorInInputEquation()
        {
            var inputProcessor = new InputProcessor();
            throw new Exception($"Некорретное входное выражение: {inputProcessor.TokensToString(tokens)}");
        }

        /// <summary>
        /// Преобразует выражение в инфиксной форме в обратную польскую нотацию
        /// </summary>
        /// <param name="_tokens">Выражение в инфиксной форме</param>
        /// <returns>Обратная польская нотация</returns>
        public PolishNotation GetReversedPolishNotation(Queue<Token> _tokens)
        {
            if (inputTokenActions.Count == 0)
            {
                DetermineInputTokenActions();
            }

            tokens = _tokens;
            if (tokens is null)
            {
                throw new ArgumentNullException(nameof(tokens));
            }
            if (tokens.Count == 0)
            {
                throw new Exception($"{nameof(tokens)} has 0 items.");
            }

            reversedPolishNotation = new ReversedPolishNotation();
            operationsStack = new Stack<Token>();

            while (tokens.Count > 0)
            {
                PerformAction();
            }

            return reversedPolishNotation;
        }
    }
}