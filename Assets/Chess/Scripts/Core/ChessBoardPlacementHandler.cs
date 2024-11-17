using System;
using UnityEngine;
using System.Diagnostics.CodeAnalysis;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public sealed class ChessBoardPlacementHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] _rowsArray;
    [SerializeField] private GameObject _highlightPrefab;
    [SerializeField] private GameObject _enemyHighlightPrefab; 
    private GameObject[,] _chessBoard;

    internal static ChessBoardPlacementHandler Instance;

    private void Awake()
    {
        Instance = this;
        GenerateArray();
    }

    private void GenerateArray()
    {
        _chessBoard = new GameObject[8, 8];
        for (var i = 0; i < 8; i++)
        {
            for (var j = 0; j < 8; j++)
            {
                _chessBoard[i, j] = _rowsArray[i].transform.GetChild(j).gameObject;
            }
        }
    }

    internal GameObject GetTile(int i, int j)
    {
        try
        {
            return _chessBoard[i, j];
        }
        catch (Exception)
        {
            Debug.LogError("Invalid row or column.");
            return null;
        }
    }

    internal void Highlight(int row, int col)
    {
        var tile = GetTile(row, col)?.transform;
        if (tile == null)
        {
            Debug.LogError("Invalid row or column.");
            return;
        }
        Instantiate(_highlightPrefab, tile.position, Quaternion.identity, tile);
    }

    internal void HighlightEnemy(int row, int col)
    {
        var tile = GetTile(row, col)?.transform;
        if (tile == null)
        {
            Debug.LogError("Invalid row or column.");
            return;
        }
        Instantiate(_enemyHighlightPrefab, tile.position, Quaternion.identity, tile); 
    }

    internal void ClearHighlights()
    {
        for (var i = 0; i < 8; i++)
        {
            for (var j = 0; j < 8; j++)
            {
                var tile = GetTile(i, j);
                if (tile.transform.childCount <= 0) continue;
                foreach (Transform childTransform in tile.transform)
                {
                    Destroy(childTransform.gameObject);
                }
            }
        }
    }
}