using Logic.Enums;
using System.Collections.Generic;

namespace Poker.Logic
{
    public interface IHandEvaluator
    {
        Hand Evaluate(IPlayer h);
        IPlayer Winner(List<IPlayer> players);
    }
}