using System;
using UnityEngine;

namespace Chess.Scripts.Core
{
    public class ChessPlayerPlacementHandler : MonoBehaviour
    {
        [SerializeField] public int row, column;

        private void Start()
        {
            if (ChessBoardPlacementHandler.Instance == null)
            {
                Debug.LogError("ChessBoardPlacementHandler.Instance is null. Ensure it is initialized before this script.");
                return;
            }

           
            if (row < 0 || row >= 8 || column < 0 || column >= 8)
            {
                Debug.LogError($"Invalid row ({row}) or column ({column}) for {gameObject.name}");
                return;
            }

            
            GameObject tile = ChessBoardPlacementHandler.Instance.GetTile(row, column);
            if (tile == null)
            {
                Debug.LogError($"Tile at row {row}, column {column} is null. Check chessboard setup.");
                return;
            }

            transform.position = tile.transform.position;
        }
    }
}
