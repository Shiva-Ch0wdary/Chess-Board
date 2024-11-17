using Chess.Scripts.Core;
using UnityEngine;

public class ChessPieceSelector : MonoBehaviour
{
    [SerializeField] private string pieceType; 
    [SerializeField] private bool isWhite; 
    private ChessBoardPlacementHandler _boardHandler;

    private void Start()
    {
        _boardHandler = ChessBoardPlacementHandler.Instance;
    }

    private void OnMouseDown()
    {
        Debug.Log($"{name} was clicked!");
        _boardHandler.ClearHighlights(); 
        HighlightPossibleMoves(); 
    }

    private void HighlightPossibleMoves()
    {
        switch (pieceType)
        {
            case "Pawn":
                HighlightPawnMoves();
                break;
            case "Knight":
                HighlightKnightMoves();
                break;
            case "Rook":
                HighlightRookMoves();
                break;
            case "Bishop":
                HighlightBishopMoves();
                break;
            case "Queen":
                HighlightQueenMoves();
                break;
            case "King":
                HighlightKingMoves();
                break;
        }
    }

    private void HighlightTile(int row, int col)
    {
        
        if (row < 0 || row >= 8 || col < 0 || col >= 8) return;

        GameObject tile = _boardHandler.GetTile(row, col);
        if (tile == null) return;

     
        ChessPieceSelector piece = tile.GetComponentInChildren<ChessPieceSelector>();
        if (piece == null)
        {
            
            _boardHandler.Highlight(row, col);
        }
        else if (piece.isWhite != this.isWhite)
        {
            
            _boardHandler.HighlightEnemy(row, col);
        }
      
    }


    private void HighlightPawnMoves()
    {
        int row = GetComponent<ChessPlayerPlacementHandler>().row;
        int col = GetComponent<ChessPlayerPlacementHandler>().column;

        int direction = isWhite ? -1 : 1; 

        
        if (_boardHandler.GetTile(row + direction, col)?.GetComponentInChildren<ChessPieceSelector>() == null)
        {
            HighlightTile(row + direction, col);
        }

        
        HighlightTile(row + direction, col - 1);
        HighlightTile(row + direction, col + 1);
    }

    private void HighlightKnightMoves()
    {
        int row = GetComponent<ChessPlayerPlacementHandler>().row;
        int col = GetComponent<ChessPlayerPlacementHandler>().column;

        int[,] knightMoves = new int[,]
        {
            {2, 1}, {2, -1}, {-2, 1}, {-2, -1},
            {1, 2}, {1, -2}, {-1, 2}, {-1, -2}
        };

        for (int i = 0; i < knightMoves.GetLength(0); i++)
        {
            HighlightTile(row + knightMoves[i, 0], col + knightMoves[i, 1]);
        }
    }

    private void HighlightRookMoves()
    {
        int row = GetComponent<ChessPlayerPlacementHandler>().row;
        int col = GetComponent<ChessPlayerPlacementHandler>().column;

        for (int i = 1; i < 8; i++)
        {
            if (!HighlightDirection(row + i, col)) break; 
        }
        for (int i = 1; i < 8; i++)
        {
            if (!HighlightDirection(row - i, col)) break; 
        }
        for (int i = 1; i < 8; i++)
        {
            if (!HighlightDirection(row, col + i)) break; 
        }
        for (int i = 1; i < 8; i++)
        {
            if (!HighlightDirection(row, col - i)) break; 
        }
    }

    private void HighlightBishopMoves()
    {
        int row = GetComponent<ChessPlayerPlacementHandler>().row;
        int col = GetComponent<ChessPlayerPlacementHandler>().column;

        for (int i = 1; i < 8; i++)
        {
            if (!HighlightDirection(row + i, col + i)) break; 
        }
        for (int i = 1; i < 8; i++)
        {
            if (!HighlightDirection(row + i, col - i)) break; 
        }
        for (int i = 1; i < 8; i++)
        {
            if (!HighlightDirection(row - i, col + i)) break; 
        }
        for (int i = 1; i < 8; i++)
        {
            if (!HighlightDirection(row - i, col - i)) break; 
        }
    }

    private void HighlightQueenMoves()
    {
        HighlightRookMoves();
        HighlightBishopMoves();
    }

    private void HighlightKingMoves()
    {
        int row = GetComponent<ChessPlayerPlacementHandler>().row;
        int col = GetComponent<ChessPlayerPlacementHandler>().column;

        int[,] kingMoves = new int[,]
        {
            { 1, 0 },  
            { -1, 0 }, 
            { 0, 1 },  
            { 0, -1 }, 
            { 1, 1 }, 
            { 1, -1 }, 
            { -1, 1 }, 
            { -1, -1 } 
        };

        for (int i = 0; i < kingMoves.GetLength(0); i++)
        {
            HighlightTile(row + kingMoves[i, 0], col + kingMoves[i, 1]);
        }
    }

    private bool HighlightDirection(int row, int col)
    {
        GameObject tile = _boardHandler.GetTile(row, col);
        if (tile == null) return false; 

        ChessPieceSelector piece = tile.GetComponentInChildren<ChessPieceSelector>();
        if (piece == null)
        {
            HighlightTile(row, col); 
            return true;
        }
        else if (piece.isWhite != this.isWhite)
        {
            HighlightTile(row, col); 
            return false; 
        }

        return false; 
    }
}
