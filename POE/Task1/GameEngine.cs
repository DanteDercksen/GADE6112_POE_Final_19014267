using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace Task1
{
    class GameEngine
    {
        const string SERIALIZED_FILE_NAME = "Game.txt";
        public Map mapVariable;

        public string View
        {
            get { return mapVariable.ToString(); }
        }

        public string PlayerStats
        {
            get { return mapVariable.Player.ToString(); }
        }
        public GameEngine()
        {
            mapVariable = new Map(10, 15, 10, 15, 6, 3);
        }

        public bool MovePlayer(MovementEnum direction)
        {
            MovementEnum allowedMove = mapVariable.Player.ReturnMove(direction);
            Debug.WriteLine(allowedMove);
            mapVariable.Player.Move(allowedMove);

            Item item = mapVariable.GetItemAtPosition(mapVariable.Player.X, mapVariable.Player.Y);

            mapVariable.Update();

            if (allowedMove == MovementEnum.NO_MOVEMENT)
            {
                return false;
            }

            return true;
        }

        public string PlayerAttack(AttackDirection direction)
        {
            int visionIndex = (int)direction;
            string failMessage = "Hero attack failed";

            if (mapVariable.Player.Vision[visionIndex].TileT == TileType.Enemy)
            {
                Enemy enemy = (Enemy)mapVariable.Player.Vision[visionIndex];
                if (enemy.isDead())
                {
                    return failMessage;
                }

                mapVariable.Player.Attack(enemy);

                mapVariable.Update();

                return "Hero attacked enemy \n" +
                    "Enemy HP: " + enemy.HP + "/" + enemy.MaxHP;
            }
            return failMessage;
        }

        public string DisplayPlayerStats()
        {
            return mapVariable.Player.ToString();
        }

        public void MoveEnemies()
        {

            for (int i = 0; i < mapVariable.Enemies.Length; i++)
            {

                Random rand = new Random();
                int random1 = rand.Next(1, 5);
                MovementEnum dir;

                if (random1 == 1)
                {
                    dir = MovementEnum.UP;
                }
                else if (random1 == 2)
                {
                    dir = MovementEnum.DOWN;
                }
                else if (random1 == 3)
                {
                    dir = MovementEnum.LEFT;
                }
                else
                {
                    dir = MovementEnum.RIGHT;
                }


                MovementEnum allowedMove = mapVariable.Enemies[i].EnemyReturnMove(dir);
                Debug.WriteLine(allowedMove);
                mapVariable.Enemies[i].Move(allowedMove);
                mapVariable.Update();
            }
        }

        public void EnemyAttacks()
        {
            for (int i = 0; i < mapVariable.Enemies.Length; i++)
            {
                if (mapVariable.Enemies[i] is Goblin)
                {
                    if (mapVariable.Enemies[i].isDead())
                    {
                        continue;
                    }
                    if (mapVariable.Enemies[i].CheckRange(mapVariable.Player))
                    {
                        mapVariable.Enemies[i].Attack(mapVariable.Player);
                    }
                }
                else if (mapVariable.Enemies[i] is Mage)
                {
                    if (mapVariable.Enemies[i].isDead())
                    {
                        continue;
                    }
                    //Player
                    if(mapVariable.Enemies[i].CheckRange(mapVariable.Player) == true)
                    {
                        mapVariable.Enemies[i].Attack(mapVariable.Player);
                    }
                    //Enemies
                    for (int z = 0; z < mapVariable.Enemies.Length; z++)
                    {
                        if(mapVariable.Enemies[i] == mapVariable.Enemies[z])
                        {
                            continue;
                        }
                        else
                        {
                            if (mapVariable.Enemies[i].CheckRange(mapVariable.Enemies[z]) == true)
                            {
                                if (mapVariable.Enemies[z].isDead())
                                {
                                    continue;
                                }
                                else
                                {
                                    mapVariable.Enemies[i].Attack(mapVariable.Enemies[z]);
                                    
                                }
                            }
                        }
                    }
                    }
                    
                {

                }
            }
        }

        public void Save()
        {     
            FileStream outFile = new FileStream(
                SERIALIZED_FILE_NAME, FileMode.Create, FileAccess.Write
                );

            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(outFile, mapVariable);

            outFile.Close();
        }

        public void Load()
        {
            FileStream inFile = new FileStream(
                SERIALIZED_FILE_NAME, FileMode.Open, FileAccess.Read
);
            BinaryFormatter bf = new BinaryFormatter();

            mapVariable = (Map)bf.Deserialize(inFile);

            inFile.Close();
        }
    }
}
    
