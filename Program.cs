{
string piece;
string smallmove;
bool IsCaptured;
string file;
bool EnPassant;
for (int i = 0; i < args.Length; i++)
{
    string move = args[i];
    if (args[i] != "e.p.")
    {
        piece = DeterminePiece(out piece, move);
        smallmove = DetermineMove(out smallmove, move, out IsCaptured, piece, out file, out EnPassant, args[i + 1]);
        if (IsCaptured)
        {
            if (EnPassant)
            {
                System.Console.WriteLine($"{piece} on the {file} captures the piece en passant and moves to {smallmove}");
            }
            else if (file != "0")
            {
                System.Console.WriteLine($"{piece} on the {file} captures the piece on {smallmove}");
            }
            else
            {
                System.Console.WriteLine($"{piece} captures the piece on {smallmove}");
            }
        }
        else if (!IsCaptured)
        {
            if (file != "0")
            {
                System.Console.WriteLine($"{piece} on the {file} captures the piece on {smallmove}");
            }
            else
            {
                System.Console.WriteLine($"{piece} moves to {smallmove}");
            }
        }
        if (move.Contains('#'))
        {
            System.Console.Write("checkmate");
        }
    }
}
}
string DeterminePiece(out string piece, string move)
{
    switch (move[0])
    {
        case 'Q': piece = "Queen"; break;
        case 'B': piece = "Bishop"; break;
        case 'N': piece = "Knight"; break;
        case 'R': piece = "Rook"; break;
        case 'K': piece = "King"; break;
        default: piece = "Pawn"; break;
    }
    return piece;

}
string DetermineMove(out string smallmove, string move, out bool IsCaptured, string piece, out string file, out bool EnPassant, string secondmove)
{
    IsCaptured = false;
    EnPassant = false;
    file = "0";
    if (move.Contains('x'))
    {
        IsCaptured = true;
        move = move.Replace("x", "");
        if (piece == "Pawn")
        {
            file = $"{move[0]} - file";
            if (secondmove == "e.p.")
            {
                EnPassant = true;
            }
        }
    }
    if (piece == "Pawn" && !IsCaptured)
    {
        smallmove = move;
    }
    else
    {
        smallmove = move.Substring(1, 2);
    }
    return smallmove;
}