namespace Task1
{
    partial class frmGameMap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDisplay = new System.Windows.Forms.Label();
            this.lblPlayerStats = new System.Windows.Forms.Label();
            this.lblBattleInfo = new System.Windows.Forms.Label();
            this.lblControls = new System.Windows.Forms.Label();
            this.lblShop = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDisplay
            // 
            this.lblDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDisplay.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplay.Location = new System.Drawing.Point(11, 9);
            this.lblDisplay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDisplay.Name = "lblDisplay";
            this.lblDisplay.Size = new System.Drawing.Size(254, 327);
            this.lblDisplay.TabIndex = 0;
            this.lblDisplay.Text = "<<MAP GOES HERE>>";
            this.lblDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlayerStats
            // 
            this.lblPlayerStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPlayerStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerStats.Location = new System.Drawing.Point(280, 9);
            this.lblPlayerStats.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPlayerStats.Name = "lblPlayerStats";
            this.lblPlayerStats.Size = new System.Drawing.Size(155, 156);
            this.lblPlayerStats.TabIndex = 5;
            this.lblPlayerStats.Text = "<<STATS GO HERE>>";
            this.lblPlayerStats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBattleInfo
            // 
            this.lblBattleInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBattleInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBattleInfo.Location = new System.Drawing.Point(450, 9);
            this.lblBattleInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBattleInfo.Name = "lblBattleInfo";
            this.lblBattleInfo.Size = new System.Drawing.Size(155, 327);
            this.lblBattleInfo.TabIndex = 6;
            this.lblBattleInfo.Text = "<<BATTLE INFO GOES HERE>>";
            this.lblBattleInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblControls
            // 
            this.lblControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblControls.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControls.Location = new System.Drawing.Point(618, 9);
            this.lblControls.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblControls.Name = "lblControls";
            this.lblControls.Size = new System.Drawing.Size(155, 327);
            this.lblControls.TabIndex = 7;
            this.lblControls.Text = "<<CONTROLS GO HERE>>";
            this.lblControls.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblShop
            // 
            this.lblShop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShop.Location = new System.Drawing.Point(280, 180);
            this.lblShop.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblShop.Name = "lblShop";
            this.lblShop.Size = new System.Drawing.Size(155, 156);
            this.lblShop.TabIndex = 8;
            this.lblShop.Text = "<<SHOP GOES HERE>>";
            this.lblShop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmGameMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 344);
            this.Controls.Add(this.lblShop);
            this.Controls.Add(this.lblControls);
            this.Controls.Add(this.lblBattleInfo);
            this.Controls.Add(this.lblPlayerStats);
            this.Controls.Add(this.lblDisplay);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmGameMap";
            this.Text = "Game Map";
            this.Load += new System.EventHandler(this.frmGameMap_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmGameMap_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDisplay;
        private System.Windows.Forms.Label lblPlayerStats;
        private System.Windows.Forms.Label lblBattleInfo;
        private System.Windows.Forms.Label lblControls;
        private System.Windows.Forms.Label lblShop;
    }
}

