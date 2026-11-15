using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileGenerator : MonoBehaviour
{
    public int Type;
    public Tile[] roof;
    public Tile[] OOTiles;
    public Tile[] WBUn;
    public Tile[] WBBl;
    public Tile[] WBGr;
    public Tile[] WBOr;
    public Tile DF2, DB2, WallR, WallL, Lift, FNCTiles, FNCUn, FER, FEL, RER, REL, floor, WH, DT;
    public Tile DBBl, DFBl, WFBl;
    public Tile DBGr, DFGr, WFGr;
    public Tile DBOr, DFOr, WFOr;
    public Tile DBUn, DFUn;
    private Vector3Int TheTile = new Vector3Int(0,0,0);
    [Range(2f, 200f)]
    public int height, width;
    private int rr, walls, dt, lofdt;
    private List<int> floors;
    private bool a = false;
    public Tilemap WB, DB, DFNWF, FNC, OO;
    void Start()
    {
        for (int h = 0; h < height; h++)
        {
            for (int w = 0; w < width; w++)
            {
                TheTile = new Vector3Int(w, h, 0);
                FNC.SetTile(TheTile, FNCTiles);
                rr = (int)Random.Range(0.0f, WBBl.Length);
                WB.SetTile(TheTile, WBBl[rr]);
                rr = (int)Random.Range(0.0f, 2.0f);
                if (rr == 0.0f)
                {
                    DB.SetTile(TheTile, DBBl);
                    TheTile = new Vector3Int(w, h, 0);
                    DFNWF.SetTile(TheTile, DFBl);
                }
                else
                {

                }
            }
        }
            for (int h = 0; h < height; h++)
            {
                TheTile = new Vector3Int(0, h, 0);
                DFNWF.SetTile(TheTile, DFBl);
                DB.SetTile(TheTile, DBBl);
                TheTile = new Vector3Int(width - 1, h, 0);
                DFNWF.SetTile(TheTile, DF2);
                DB.SetTile(TheTile, DB2);
                TheTile = new Vector3Int(width + 1, h, 0);
                DFNWF.SetTile(TheTile, WallR);
                TheTile = new Vector3Int(width, h, 0);
                WB.SetTile(TheTile, Lift);
                TheTile = new Vector3Int(-2, h, 0);
                DFNWF.SetTile(TheTile, WallL);
                TheTile = new Vector3Int(-1, h, 0);
                WB.SetTile(TheTile, Lift);
            }
        if (Type == 1)
        {
            TheTile = new Vector3Int(-2, -1, 0);
            WB.SetTile(TheTile, FEL);
            TheTile = new Vector3Int(width + 1, -1, 0);
            WB.SetTile(TheTile, FER);
            TheTile = new Vector3Int(-2, height, 0);
            WB.SetTile(TheTile, REL);
            TheTile = new Vector3Int(width + 1, height, 0);
            WB.SetTile(TheTile, RER);
        }
        if (Type == 2)
        {
            TheTile = new Vector3Int(0, -1, 0);
            DFNWF.SetTile(TheTile, DFUn);
            DB.SetTile(TheTile, DBUn);
            TheTile = new Vector3Int(width - 1, -1, 0);
            DFNWF.SetTile(TheTile, DF2);
            DB.SetTile(TheTile, DB2);
            TheTile = new Vector3Int(-2, -2, 0);
            WB.SetTile(TheTile, FEL);
            TheTile = new Vector3Int(width + 1, -2, 0);
            WB.SetTile(TheTile, FER);
            TheTile = new Vector3Int(-2, height, 0);
            WB.SetTile(TheTile, REL);
            TheTile = new Vector3Int(width + 1, height, 0);
            WB.SetTile(TheTile, RER);
            TheTile = new Vector3Int(width + 1, -1, 0);
            DFNWF.SetTile(TheTile, WallR);
            TheTile = new Vector3Int(width, -1, 0);
            WB.SetTile(TheTile, Lift);
            TheTile = new Vector3Int(-2, -1, 0);
            DFNWF.SetTile(TheTile, WallL);
            TheTile = new Vector3Int(-1, -1, 0);
            WB.SetTile(TheTile, Lift);
        }
        for (int w = -1; w < width + 1; w++)
        {
            if(Type == 1)
            TheTile = new Vector3Int(w, -1, 0);
            if (Type == 2)
            TheTile = new Vector3Int(w, -2, 0);
            WB.SetTile(TheTile, floor);
            rr = (int)Random.Range(0.0f, roof.Length);
            TheTile = new Vector3Int(w, height, 0);
            WB.SetTile(TheTile, roof[rr]);
        }
        if (width > 3)
        {
            dt = (int)Random.Range(0, height / 3);
            for (int w = 0; w < dt; w++)
            {
                rr = (int)Random.Range(0.0f, height);
                for (int b = 0; b < floors.Count; b++)
                {
                    if (floors[b] == rr)
                    {
                        a = true;
                        w = w - 1;
                    }
                }
                if (!a)
                {
                    floors.Add(rr);
                    if (width > 6)
                        lofdt = (int)Random.Range(1f, 3f);
                    else
                        lofdt = 1;
                    rr = (int)Random.Range(1 + lofdt, width - 1);
                    TheTile = new Vector3Int(rr, floors[w], 0);
                    DFNWF.SetTile(TheTile, WFBl);
                    for (int b = 0; b < lofdt; b++)
                    {
                        TheTile = new Vector3Int(rr - 1 - b, floors[w], 0);
                        WB.SetTile(TheTile, DT);
                        DB.SetTile(TheTile, null);
                        DFNWF.SetTile(TheTile, null);
                        FNC.SetTile(TheTile, null);
                        OO.SetTile(TheTile, null);
                    }
                }
                a = false;
            }
        }

        walls = (int)Random.Range(0, height / 2) - dt;
        for (int w = 0; w < walls; w++)
        {
            rr = (int)Random.Range(0.0f, height);
            for (int b = 0; b < floors.Count; b++)
            {
                if(floors[b] == rr)
                {
                    a = true;
                    w = w - 1;
                }
            }
              if (!a)
              {
                floors.Add(rr);
                rr = (int)Random.Range(1, width - 1);
                TheTile = new Vector3Int(rr, floors[w], 0);
                DFNWF.SetTile(TheTile, WFBl);
              }
             a = false;
        }
        if(Type == 2)
        {
            for (int w = 0; w < width; w++)
            {
                TheTile = new Vector3Int(w, -1, 0);
                FNC.SetTile(TheTile, FNCUn);
                rr = (int)Random.Range(0.0f, WBUn.Length);
                WB.SetTile(TheTile, WBUn[rr]);
                rr = (int)Random.Range(0.0f, 2.0f);
                if (w < width - 1)
                {
                    if (rr == 0.0f)
                    {
                        DB.SetTile(TheTile, DBUn);
                        TheTile = new Vector3Int(w, -1, 0);
                        DFNWF.SetTile(TheTile, DFUn);
                    }
                    else
                    {

                    }
                }
            }
        }
    }
}
