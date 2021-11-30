using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Task1
{
    public partial class frmGameMap : Form
    {
        GameEngine map1;
        string controlsText;

        public frmGameMap()
        {
            map1 = new GameEngine();
            InitializeComponent();
        }

        private void frmGameMap_Load(object sender, EventArgs e)
        {
            lblDisplay.Text = map1.View;
            lblPlayerStats.Text = map1.PlayerStats;
            lblControls.Text = MapControlsText();
        }
       
        private void frmGameMap_KeyPress(object sender, KeyPressEventArgs e)
        {
            Debug.WriteLine(e.KeyChar.ToString() + " pressed.");
            if(e.KeyChar == 'w')
            {
                MoveUp();
            }else if(e.KeyChar == 'a')
            {
                MoveLeft();
            }else if(e.KeyChar == 's')
            {
                MoveDown();
            }else if(e.KeyChar == 'd')
            {
                MoveRight();
            }else if(e.KeyChar == '1')
            {
                AttackUp();
            }else if(e.KeyChar == '2')
            {
                AttackLeft();
            }else if(e.KeyChar == '3')
            {
                AttackDown();
            }else if(e.KeyChar == '4')
            {
                AttackRight();
            }

            else if(e.KeyChar == 'n')
            {
                map1.Save();
            }

            else if(e.KeyChar == 'm')
            {
                map1.Load();
                lblPlayerStats.Text = map1.PlayerStats;
                lblDisplay.Text = map1.View;
            }
        }

        private void MoveUp()
        {
            map1.MovePlayer(MovementEnum.UP);
            map1.MoveEnemies();
            map1.EnemyAttacks();
            lblPlayerStats.Text = map1.PlayerStats;
            lblDisplay.Text = map1.View;

        }
        private void MoveLeft()
        {
            map1.MovePlayer(MovementEnum.LEFT);
            map1.MoveEnemies();
            map1.EnemyAttacks();
            lblPlayerStats.Text = map1.PlayerStats;
            lblDisplay.Text = map1.View;

        }
        private void MoveDown()
        {
            map1.MovePlayer(MovementEnum.DOWN);
            map1.MoveEnemies();
            map1.EnemyAttacks();
            lblPlayerStats.Text = map1.PlayerStats;
            lblDisplay.Text = map1.View;

        }
        private void MoveRight()
        {
            map1.MovePlayer(MovementEnum.RIGHT);
            map1.MoveEnemies();
            map1.EnemyAttacks();
            lblPlayerStats.Text = map1.PlayerStats;
            lblDisplay.Text = map1.View;
        }
        private void AttackUp()
        {
            lblBattleInfo.Text = map1.PlayerAttack(AttackDirection.UP);
            map1.EnemyAttacks();
            lblPlayerStats.Text = map1.PlayerStats;
            lblDisplay.Text = map1.View;

        }
        private void AttackLeft()
        {
            lblBattleInfo.Text = map1.PlayerAttack(AttackDirection.LEFT);
            map1.EnemyAttacks();
            lblPlayerStats.Text = map1.PlayerStats;
            lblDisplay.Text = map1.View;

        }
        private void AttackDown()
        {
            lblBattleInfo.Text = map1.PlayerAttack(AttackDirection.DOWN);
            map1.EnemyAttacks();
            lblPlayerStats.Text = map1.PlayerStats;
            lblDisplay.Text = map1.View;

        }
        private void AttackRight()
        {
            lblBattleInfo.Text = map1.PlayerAttack(AttackDirection.RIGHT);
            map1.EnemyAttacks();
            lblPlayerStats.Text = map1.PlayerStats;
            lblDisplay.Text = map1.View;

        }

        private string MapControlsText()
        {
            string text = "Move Controls:\n" +
                "UP: 'W'\n" +
                "DOWN: 'S'\n" +
                "LEFT: 'A'\n" +
                "RIGHT: 'D'\n" +
                "\n" +
                "Attack Controls:\n" +
                "UP: '1'\n" +
                "DOWN: '2'\n" +
                "LEFT: '3'\n" +
                "RIGHT: '4\n'" +
                "\n" +
                "To Save: 'N'\n" +
                "To Load: 'M'";

            return text;
        }

    }
}
