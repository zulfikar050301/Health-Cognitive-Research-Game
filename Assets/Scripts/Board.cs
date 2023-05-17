using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Board : MonoBehaviour
{
    public Tilemap tilemap { get; private set; }
    public Piece activePiece  { get; private set; }
    public TetrominoData[] tetrominoes; 
    public Vector3Int spawnPosition;
    public Vector2Int boardSize = new Vector2Int(10, 20);

    public float speed;

    GameObject scoreUITextGO; //referenceto the game score

    GameObject TextTime;

    public GameObject GameOverUI;

    public RectInt Bounds
    {
        get
        {
            Vector2Int position = new Vector2Int(-this.boardSize.x / 2, -this.boardSize.y / 2);
            return new  RectInt(position, this.boardSize);
        }
    }

    private void Awake()
    {
        this.tilemap =  GetComponentInChildren<Tilemap>();
        this.activePiece = GetComponentInChildren<Piece>();


        for (int i = 0; i < this.tetrominoes.Length; i++ ) 
        {
            this.tetrominoes[i].Initialize();
        }
    }

    private void Start()
    {
        SpawnPiece();
        Time.timeScale = 1f;
        scoreUITextGO = GameObject.FindGameObjectWithTag("ScoreTextTag"); // get the score text tag
    }

    public void SpawnPiece()
    {
        int random = Random.Range(0, this.tetrominoes.Length);
        TetrominoData data = this.tetrominoes[random];

        this.activePiece.Initialize(this, this.spawnPosition, data);


        if (IsValidPosition(this.activePiece, this.spawnPosition))
        {
            Set(this.activePiece);
        } else
        {
            GameOver();
            // Time.timeScale = 0f;
        }
    }

    private void GameOver()
    {
        this.tilemap.ClearAllTiles();

        scoreUITextGO.GetComponent<GameScore>().Score = 0;
        // TextTime.GetComponent<TimeCounter>().TextTimer = 0;
        
        LevelLoader.instance.youLose();
    }

    public void Set(Piece piece)
    {
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + piece.position;
            this.tilemap.SetTile(tilePosition, piece.data.tile);
        }
    }

    public void Clear(Piece piece)
    {
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + piece.position;
            this.tilemap.SetTile(tilePosition, null);
        }
    }

    public bool IsValidPosition(Piece piece, Vector3Int position)
    {
        RectInt bounds = this.Bounds;

        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + position;

            if (!bounds.Contains((Vector2Int)tilePosition))
            {
                return false;
            }

            if (this.tilemap.HasTile(tilePosition))
            {
                return false;
            }
        }

        return true;
    }

    public void ClearLines()
    {
        RectInt bounds = this.Bounds;
        int row = bounds.yMin;

        while (row < bounds.yMax)
        {
            if (IsLineFull(row))
            {
                LineClear(row);
                GameObject.Find ("suara full").GetComponent<AudioSource> ().Play();

                //add 100 points to the score
                scoreUITextGO.GetComponent<GameScore>().Score += 100;
            } else {
                row++;
            }
        }
    }

    private bool IsLineFull(int row)
    {
        RectInt bounds = this.Bounds;

        for (int col = bounds.xMin; col < bounds.xMax; col++)
        {
            Vector3Int position = new Vector3Int(col, row, 0);

            if (!this.tilemap.HasTile(position))
            {
                return false;
            }
        }

        return true;
    }

    private void LineClear(int row)
    {
        RectInt bounds = this.Bounds;

        for (int col = bounds.xMin; col < bounds.xMax; col++)
        {
            Vector3Int position = new Vector3Int(col, row, 0);
            this.tilemap.SetTile(position, null);
        }

        while (row < bounds.yMax)
        {
            for (int col = bounds.xMin; col < bounds.xMax; col++)
            {
                Vector3Int position = new Vector3Int(col, row + 1, 0);
                TileBase above = this.tilemap.GetTile(position);

                position = new Vector3Int(col, row, 0);
                this.tilemap.SetTile(position, above);
            }

            row++;
        }
    }
}
