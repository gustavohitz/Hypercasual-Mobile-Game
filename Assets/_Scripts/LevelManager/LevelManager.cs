using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public Transform container;
    public List<GameObject> levels;
    
    [Header("Pieces")]
    public List<LevelPieceBase> levelPiecesStart;
    public List<LevelPieceBase> levelPieces;
    public List<LevelPieceBase> levelPiecesEnd;
    public int pieceNumber = 5;
    public int pieceStartNumber = 3;
    public int pieceEndNumber = 1;

    [SerializeField] private int _index;
    private GameObject _currentLevel;
    private List<LevelPieceBase> _spawnedPieces;

    void Awake() {
        //SpawnNextLevel();
        CreateLevelPieces();
    }
    void Update() {
        if(Input.GetKeyDown(KeyCode.D)) {
            SpawnNextLevel();
        }
    }

    private void SpawnNextLevel() {
        if(_currentLevel != null) {
            Destroy(_currentLevel);
            _index++;

            if(_index >= levels.Count) {
                ResetLevelIndex();
            }
        }

        _currentLevel = Instantiate(levels[_index], container);
        _currentLevel.transform.localPosition = Vector3.zero;
    }
    private void ResetLevelIndex() {
        _index = 0;
    }

    #region
    private void CreateLevelPieces() {
        _spawnedPieces = new List<LevelPieceBase>();
        
        for (int i = 0; i < pieceStartNumber; i++) {
            CreateLevelPiece(levelPiecesStart);
        }

        for (int i = 0; i < pieceNumber; i++) {
            CreateLevelPiece(levelPieces);
        }

        for (int i = 0; i < pieceEndNumber; i++) {
            CreateLevelPiece(levelPiecesEnd);
        }
    }
    private void CreateLevelPiece(List<LevelPieceBase> list) {
        var piece = list[Random.Range(0, list.Count)];
        var spawnedPiece = Instantiate(piece, container);

        if(_spawnedPieces.Count > 0) {
            var lastPiece = _spawnedPieces[_spawnedPieces.Count - 1];

            spawnedPiece.transform.position = lastPiece.endPiece.position;
        }

        _spawnedPieces.Add(spawnedPiece);
    }
    #endregion
  
}
