using System.Data;
using Microsoft.Data.SqlClient; // To use SqlInfoMessageEventArgs
partial class Program
{
    private static void Connection_StateChange(object sender, StateChangeEventArgs e)
    {
        WriteInColor($"State change from {e.OriginalState} to {e.CurrentState}.", ConsoleColor.DarkYellow);
    }

    private static void Connection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
    {
        WriteInColor($"info: {e.Message}", ConsoleColor.DarkBlue);
    }
}
