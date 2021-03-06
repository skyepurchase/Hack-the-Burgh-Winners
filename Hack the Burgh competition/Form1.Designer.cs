
namespace Hack_the_Burgh_competition
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnStats = new System.Windows.Forms.Button();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnChallenges = new System.Windows.Forms.Button();
            this.btnTraining = new System.Windows.Forms.Button();
            this.pnlTraining = new System.Windows.Forms.Panel();
            this.btnConcept2 = new System.Windows.Forms.Button();
            this.btnConcept1 = new System.Windows.Forms.Button();
            this.btnTerminologies = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlInformation = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblInfoTitle = new System.Windows.Forms.Label();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlTraining.SuspendLayout();
            this.pnlInformation.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ravie", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(544, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(725, 57);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to (game name)";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.White;
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.Font = new System.Drawing.Font("Led Italic Font", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnStart.Location = new System.Drawing.Point(525, 180);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(243, 73);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.White;
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.Font = new System.Drawing.Font("Led Italic Font", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSettings.Location = new System.Drawing.Point(525, 412);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(243, 73);
            this.btnSettings.TabIndex = 3;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.BackColor = System.Drawing.Color.White;
            this.btnQuit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuit.Font = new System.Drawing.Font("Led Italic Font", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnQuit.Location = new System.Drawing.Point(525, 528);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(243, 73);
            this.btnQuit.TabIndex = 4;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = false;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnStats
            // 
            this.btnStats.BackColor = System.Drawing.Color.White;
            this.btnStats.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStats.Font = new System.Drawing.Font("Led Italic Font", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnStats.Location = new System.Drawing.Point(525, 296);
            this.btnStats.Name = "btnStats";
            this.btnStats.Size = new System.Drawing.Size(243, 73);
            this.btnStats.TabIndex = 2;
            this.btnStats.Text = "Stats";
            this.btnStats.UseVisualStyleBackColor = false;
            this.btnStats.Click += new System.EventHandler(this.btnStats_Click);
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.btnStart);
            this.pnlMenu.Controls.Add(this.btnSettings);
            this.pnlMenu.Controls.Add(this.btnQuit);
            this.pnlMenu.Controls.Add(this.btnStats);
            this.pnlMenu.Location = new System.Drawing.Point(235, 179);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(1261, 791);
            this.pnlMenu.TabIndex = 5;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.White;
            this.btnBack.Font = new System.Drawing.Font("Led Italic Font", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnBack.Location = new System.Drawing.Point(1439, 1026);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(243, 73);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnChallenges);
            this.panel2.Controls.Add(this.btnTraining);
            this.panel2.Location = new System.Drawing.Point(238, 179);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1258, 791);
            this.panel2.TabIndex = 6;
            this.panel2.Visible = false;
            // 
            // btnChallenges
            // 
            this.btnChallenges.BackColor = System.Drawing.Color.White;
            this.btnChallenges.Font = new System.Drawing.Font("Led Italic Font", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnChallenges.Location = new System.Drawing.Point(442, 410);
            this.btnChallenges.Name = "btnChallenges";
            this.btnChallenges.Size = new System.Drawing.Size(336, 73);
            this.btnChallenges.TabIndex = 1;
            this.btnChallenges.Text = "Challenges";
            this.btnChallenges.UseVisualStyleBackColor = false;
            // 
            // btnTraining
            // 
            this.btnTraining.BackColor = System.Drawing.Color.White;
            this.btnTraining.Font = new System.Drawing.Font("Led Italic Font", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnTraining.Location = new System.Drawing.Point(442, 261);
            this.btnTraining.Name = "btnTraining";
            this.btnTraining.Size = new System.Drawing.Size(336, 73);
            this.btnTraining.TabIndex = 0;
            this.btnTraining.Text = "Training";
            this.btnTraining.UseVisualStyleBackColor = false;
            this.btnTraining.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnlTraining
            // 
            this.pnlTraining.Controls.Add(this.btnConcept2);
            this.pnlTraining.Controls.Add(this.btnConcept1);
            this.pnlTraining.Controls.Add(this.btnTerminologies);
            this.pnlTraining.Controls.Add(this.label2);
            this.pnlTraining.Location = new System.Drawing.Point(238, 179);
            this.pnlTraining.Name = "pnlTraining";
            this.pnlTraining.Size = new System.Drawing.Size(1258, 788);
            this.pnlTraining.TabIndex = 7;
            this.pnlTraining.Visible = false;
            // 
            // btnConcept2
            // 
            this.btnConcept2.BackColor = System.Drawing.Color.White;
            this.btnConcept2.Font = new System.Drawing.Font("Led Italic Font", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnConcept2.Location = new System.Drawing.Point(64, 348);
            this.btnConcept2.Name = "btnConcept2";
            this.btnConcept2.Size = new System.Drawing.Size(311, 54);
            this.btnConcept2.TabIndex = 3;
            this.btnConcept2.Text = "Concept 2";
            this.btnConcept2.UseVisualStyleBackColor = false;
            this.btnConcept2.Click += new System.EventHandler(this.btnConcept2_Click);
            // 
            // btnConcept1
            // 
            this.btnConcept1.BackColor = System.Drawing.Color.White;
            this.btnConcept1.Font = new System.Drawing.Font("Led Italic Font", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnConcept1.Location = new System.Drawing.Point(64, 236);
            this.btnConcept1.Name = "btnConcept1";
            this.btnConcept1.Size = new System.Drawing.Size(311, 54);
            this.btnConcept1.TabIndex = 2;
            this.btnConcept1.Text = "Concept 1";
            this.btnConcept1.UseVisualStyleBackColor = false;
            this.btnConcept1.Click += new System.EventHandler(this.btnConcept1_Click);
            // 
            // btnTerminologies
            // 
            this.btnTerminologies.BackColor = System.Drawing.Color.White;
            this.btnTerminologies.Font = new System.Drawing.Font("Led Italic Font", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnTerminologies.Location = new System.Drawing.Point(64, 124);
            this.btnTerminologies.Name = "btnTerminologies";
            this.btnTerminologies.Size = new System.Drawing.Size(311, 54);
            this.btnTerminologies.TabIndex = 1;
            this.btnTerminologies.Text = "Terminologies";
            this.btnTerminologies.UseVisualStyleBackColor = false;
            this.btnTerminologies.Click += new System.EventHandler(this.btnTerminologies_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rockwell", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(445, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(419, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "Pick what you would like to learn";
            // 
            // pnlInformation
            // 
            this.pnlInformation.AutoScroll = true;
            this.pnlInformation.Controls.Add(this.lblInfo);
            this.pnlInformation.Controls.Add(this.lblInfoTitle);
            this.pnlInformation.Location = new System.Drawing.Point(238, 179);
            this.pnlInformation.Name = "pnlInformation";
            this.pnlInformation.Size = new System.Drawing.Size(1258, 791);
            this.pnlInformation.TabIndex = 8;
            this.pnlInformation.Visible = false;
            this.pnlInformation.VisibleChanged += new System.EventHandler(this.pnlInformation_VisibleChanged);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Rockwell", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(64, 152);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(378, 31);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "This will show the information";
            // 
            // lblInfoTitle
            // 
            this.lblInfoTitle.AutoSize = true;
            this.lblInfoTitle.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoTitle.Location = new System.Drawing.Point(467, 30);
            this.lblInfoTitle.Name = "lblInfoTitle";
            this.lblInfoTitle.Size = new System.Drawing.Size(379, 39);
            this.lblInfoTitle.TabIndex = 0;
            this.lblInfoTitle.Text = "This will show the tittle";
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.label5);
            this.pnlSettings.Controls.Add(this.trackBar1);
            this.pnlSettings.Controls.Add(this.checkBox1);
            this.pnlSettings.Controls.Add(this.label4);
            this.pnlSettings.Controls.Add(this.label3);
            this.pnlSettings.Location = new System.Drawing.Point(235, 179);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(1258, 791);
            this.pnlSettings.TabIndex = 9;
            this.pnlSettings.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Rockwell", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(593, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 31);
            this.label3.TabIndex = 0;
            this.label3.Text = "Settings";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Rockwell", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(69, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(229, 31);
            this.label4.TabIndex = 1;
            this.label4.Text = "Volume Controls:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBox1.Location = new System.Drawing.Point(127, 175);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(118, 29);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "On / Off";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // trackBar1
            // 
            this.trackBar1.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.trackBar1.Location = new System.Drawing.Point(127, 282);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(251, 90);
            this.trackBar1.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Rockwell", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(122, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(191, 31);
            this.label5.TabIndex = 5;
            this.label5.Text = "Adjust volume";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1773, 1161);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.pnlInformation);
            this.Controls.Add(this.pnlTraining);
            this.Controls.Add(this.panel2);
            this.Name = "Form1";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlMenu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pnlTraining.ResumeLayout(false);
            this.pnlTraining.PerformLayout();
            this.pnlInformation.ResumeLayout(false);
            this.pnlInformation.PerformLayout();
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnStats;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnChallenges;
        private System.Windows.Forms.Button btnTraining;
        private System.Windows.Forms.Panel pnlTraining;
        private System.Windows.Forms.Button btnConcept2;
        private System.Windows.Forms.Button btnConcept1;
        private System.Windows.Forms.Button btnTerminologies;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlInformation;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblInfoTitle;
        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

