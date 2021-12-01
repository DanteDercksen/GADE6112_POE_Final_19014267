using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    [Serializable]
    class Map
    {
        Tile[,] gameMap;
        public Tile[,] GameMap
        {
            get { return gameMap; }
        }
        Hero player;
        public Hero Player
        {
            get { return player; }
        }

        Enemy[] enemies;
        public Enemy[] Enemies
        {
            get { return enemies; }
        }

        Item[] items;

        int width;
        int height;
        
        Random rand = new Random();

        public Map(int minHeight, int maxHeight, int minWidth, int maxWidth, int numEnemies, int numGold, int numWeapons)
        {

            height = rand.Next(minHeight, maxHeight + 1);
            width = rand.Next(minWidth, maxWidth + 1);

            gameMap = new Tile[width, height];
            enemies = new Enemy[numEnemies];

            items = new Item[numGold + numWeapons];

            InitializeMap();

            player = (Hero)Create(TileType.Hero);

            for(int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = (Enemy)Create(TileType.Enemy);
            }

            for(int i = 0; i < items.Length; i++)
            {
                int w = rand.Next(2);
                if (w == 0)
                {
                    items[i] = (Item)Create(TileType.Weapon);
                }
                else
                {
                    items[i] = (Item)Create(TileType.Gold);
                }
            }

            UpdateVision();
        }

        public void UpdateVision()
        {
            UpdateCharacterVision(player);

            foreach(Enemy e in enemies)
            {
                UpdateCharacterVision(e);
            }
        }

        private void UpdateCharacterVision(Character character)
        {
            Tile tileUp = null;
            Tile tileDown = null;
            Tile tileLeft = null;
            Tile tileRight = null;

            if (character.Y - 1 >= 0) // up -y
            {
                tileUp = gameMap[character.X, character.Y - 1];
            }
            if (character.Y + 1 < height) // down +y
            {
                tileDown = gameMap[character.X, character.Y + 1];
            }
            if (character.X - 1 >= 0) // left -x
            {
                tileLeft = gameMap[character.X - 1, character.Y];
            }
            if (character.Y + 1 < width) // right +x
            {
                tileRight = gameMap[character.X + 1, character.Y];
            }

            character.Setvision(tileUp, tileDown, tileLeft, tileRight);
        }

        private void InitializeMap()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if(x == 0 || x == width - 1 || y == 0 || y == height - 1)
                    {
                        gameMap[x, y] = new Obstacle(x, y);
                    }
                    else
                    {
                        gameMap[x, y] = new EmptyTile(x, y);
                    }
                }
            }
        }

        private Tile Create(TileType type)
        {
            int X = rand.Next(1, width);
            int Y = rand.Next(1, height);

            while (gameMap[X, Y].TileT != TileType.EmptyTile)
            {
              X = rand.Next(1, width);
              Y = rand.Next(1, height);
            }
            if (type == TileType.Hero)
            {
                gameMap[X, Y] = new Hero(X, Y, 10);
                return gameMap[X, Y];
            }
            else if (type == TileType.Enemy)
            {
                int random1 = rand.Next(0, 2);
                if (random1 == 0)
                {
                    gameMap[X, Y] = new Goblin(X, Y);
                }
                else if (random1 == 1)
                {
                    gameMap[X, Y] = new Mage(X, Y);
                }
                else
                {
                    gameMap[X, Y] = new Leader(X, Y);
                }
                return gameMap[X, Y];
            }
            else if (type == TileType.Gold)
            {
                gameMap[X, Y] = new Gold(X, Y);
                return gameMap[X, Y];
            }
            else if (type == TileType.Weapon)
            {
                int rand1 = rand.Next(0, 4);
                //Dagger
                if (rand1 == 0)
                {
                    gameMap[X, Y] = new MeleeWeapon(MeleeTypes.DAGGER, X, Y);
                }
                //Longsword
                else if (rand1 == 1)
                {
                    gameMap[X, Y] = new MeleeWeapon(MeleeTypes.LONGSWORD, X, Y);
                }
                //Rifle
                else if (rand1 == 2)
                {
                    gameMap[X, Y] = new RangedWeapon(RangedTypes.RIFLE, X, Y);
                }
                //Longbow
                else
                {
                    gameMap[X, Y] = new RangedWeapon(RangedTypes.LONGBOW, X, Y);
                }
                return gameMap[X, Y];
            }
            else if (type == TileType.EmptyTile)
            {
                gameMap[X, Y] = new EmptyTile(X,Y);
                return gameMap[X,Y];
            }
            else
            {
                return null;
            }
        }

        public void Update()
        {
            InitializeMap();

            

            gameMap[player.X, player.Y] = player;

            for (int z = 0; z < enemies.Length; z++)
            {
                Enemy currentEnemy = enemies[z];
                gameMap[currentEnemy.X, currentEnemy.Y] = enemies[z];
            }

            for(int i = 0; i < items.Length; i++)
            {
                if(items[i] != null)
                {
                    Item item = items[i];
                    gameMap[item.X, item.Y] = items[i];
                }
                
            }

            UpdateVision();
        }
        public Item GetItemAtPosition(int x, int y)
        {
            for(int i = 0; i < items.Length; i++)
            {
                if(items[i] == null)
                {
                    continue;
                }
                if(items[i].X == x && items[i].Y == y)
                {
                    Item item = items[i];
                    items[i] = null;
                    return item;
                }
            }
            return null;
        }

        public override string ToString()
        {
            string mapString = "";

            if (player.HP <= 0)
            {

                return "THE HERO DIED!\n" +
                    "YOU LOSE";
            }
            for (int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    TileType currentType = gameMap[x, y].TileT;
                    if (Player.X == x && Player.Y == y)
                    {
                        mapString += 'H';
                        continue;
                    }
                    if (currentType == TileType.Enemy)
                    {
                        Enemy enemy = (Enemy)gameMap[x, y];
                        if (enemy.isDead())
                        {
                            mapString += "\u2020";
                        }
                        else
                        {
                            if(enemy is Goblin) 
                            {
                                mapString += 'G';
                            }
                            else if(enemy is Mage)
                            {
                                mapString += 'M';
                            }
                            else if (enemy is Leader)
                            {
                                mapString += 'L';
                            }
                        }
                    }
                    else if(currentType == TileType.Item)
                    {
                        if(gameMap[x, y]is Gold)
                        {
                            Gold gold = (Gold)gameMap[x, y];
                            mapString += gold.GoldAmount;
                        }

                    }
                    else if (currentType == TileType.Weapon)
                    {
                        if (gameMap[x, y] is MeleeWeapon)
                        {
                            MeleeWeapon meleeWeapon = (MeleeWeapon)gameMap[x, y];
                            if (meleeWeapon.ToString() == "Dagger")
                            {
                                mapString += 'D';
                            }
                            else if (meleeWeapon.ToString() == "Longsword")
                            {
                                mapString += 'S';
                            }
                            else
                            {
                                mapString += '0';
                            }

                        }
                        else if (gameMap[x, y] is RangedWeapon)
                        {
                            RangedWeapon rangedWeapon = (RangedWeapon)gameMap[x, y];
                            if (rangedWeapon.ToString() == "Rifle")
                            {
                                mapString += 'R';
                            }
                            else if (rangedWeapon.ToString() == "Longbow")
                            {
                                mapString += 'B';
                            }
                            else
                            {
                                mapString += '0';
                            }
                        }
                    }
                    else if (currentType == TileType.EmptyTile)
                    {
                        mapString += '.';
                    }
                    else if (currentType == TileType.Obstacle)
                    {
                        mapString += 'X';
                    }
                }
                mapString += "\n";
            }
            return mapString;
        }
    }
}
