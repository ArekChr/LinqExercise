using System;
using LINQ_Exercises.Extensions;

namespace LINQ_Exercises.Core
{
    public class GameCore : Core
    {
        public override void Start()
        {
            ConsoleEx.Log("Game started!", ConsoleColor.Yellow);
        }

        public override void End()
        {
            ConsoleEx.Log("Game ended!", ConsoleColor.Yellow);
        }
    }

    public abstract class Core
    {
        public abstract void Start();

        public abstract void End();
    }
}
