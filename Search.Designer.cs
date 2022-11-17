namespace FantasyFootballFriend {
    partial class Search {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.uxPlayerList = new System.Windows.Forms.ListView();
            this.uxPlayerIdColumn = new System.Windows.Forms.ColumnHeader();
            this.uxPlayerNameColumn = new System.Windows.Forms.ColumnHeader();
            this.uxTeamColumn = new System.Windows.Forms.ColumnHeader();
            this.uxPositionColumn = new System.Windows.Forms.ColumnHeader();
            this.uxPlayerButton = new System.Windows.Forms.Button();
            this.uxOffensiveButton = new System.Windows.Forms.Button();
            this.uxEspnButton = new System.Windows.Forms.Button();
            this.uxDefensiveButton = new System.Windows.Forms.Button();
            this.uxSubmitButton = new System.Windows.Forms.Button();
            this.uxTeamComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // uxPlayerList
            // 
            this.uxPlayerList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.uxPlayerIdColumn,
            this.uxPlayerNameColumn,
            this.uxTeamColumn,
            this.uxPositionColumn});
            this.uxPlayerList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.uxPlayerList.FullRowSelect = true;
            this.uxPlayerList.GridLines = true;
            this.uxPlayerList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.uxPlayerList.Location = new System.Drawing.Point(12, 12);
            this.uxPlayerList.Name = "uxPlayerList";
            this.uxPlayerList.RightToLeftLayout = true;
            this.uxPlayerList.Size = new System.Drawing.Size(893, 579);
            this.uxPlayerList.TabIndex = 0;
            this.uxPlayerList.UseCompatibleStateImageBehavior = false;
            this.uxPlayerList.View = System.Windows.Forms.View.Details;
            // 
            // uxPlayerIdColumn
            // 
            this.uxPlayerIdColumn.Text = "PlayerId";
            this.uxPlayerIdColumn.Width = 50;
            // 
            // uxPlayerNameColumn
            // 
            this.uxPlayerNameColumn.Text = "PlayerName";
            this.uxPlayerNameColumn.Width = 140;
            // 
            // uxTeamColumn
            // 
            this.uxTeamColumn.Text = "Team";
            // 
            // uxPositionColumn
            // 
            this.uxPositionColumn.Text = "Position";
            // 
            // uxPlayerButton
            // 
            this.uxPlayerButton.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxPlayerButton.Location = new System.Drawing.Point(1298, 245);
            this.uxPlayerButton.Name = "uxPlayerButton";
            this.uxPlayerButton.Size = new System.Drawing.Size(164, 104);
            this.uxPlayerButton.TabIndex = 1;
            this.uxPlayerButton.Text = "Search Player";
            this.uxPlayerButton.UseVisualStyleBackColor = true;
            this.uxPlayerButton.Click += new System.EventHandler(this.uxPlayerButton_Click);
            // 
            // uxOffensiveButton
            // 
            this.uxOffensiveButton.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxOffensiveButton.Location = new System.Drawing.Point(1298, 25);
            this.uxOffensiveButton.Name = "uxOffensiveButton";
            this.uxOffensiveButton.Size = new System.Drawing.Size(164, 104);
            this.uxOffensiveButton.TabIndex = 2;
            this.uxOffensiveButton.Text = "Search Offensive";
            this.uxOffensiveButton.UseVisualStyleBackColor = true;
            this.uxOffensiveButton.Click += new System.EventHandler(this.uxOffensiveButton_Click);
            // 
            // uxEspnButton
            // 
            this.uxEspnButton.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxEspnButton.Location = new System.Drawing.Point(1298, 355);
            this.uxEspnButton.Name = "uxEspnButton";
            this.uxEspnButton.Size = new System.Drawing.Size(164, 104);
            this.uxEspnButton.TabIndex = 3;
            this.uxEspnButton.Text = "Search ESPN";
            this.uxEspnButton.UseVisualStyleBackColor = true;
            this.uxEspnButton.Click += new System.EventHandler(this.uxEspnButton_Click);
            // 
            // uxDefensiveButton
            // 
            this.uxDefensiveButton.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uxDefensiveButton.Location = new System.Drawing.Point(1298, 135);
            this.uxDefensiveButton.Name = "uxDefensiveButton";
            this.uxDefensiveButton.Size = new System.Drawing.Size(164, 104);
            this.uxDefensiveButton.TabIndex = 4;
            this.uxDefensiveButton.Text = "Search Defensive";
            this.uxDefensiveButton.UseVisualStyleBackColor = true;
            this.uxDefensiveButton.Click += new System.EventHandler(this.uxDefensiveButton_Click);
            // 
            // uxSubmitButton
            // 
            this.uxSubmitButton.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.uxSubmitButton.Location = new System.Drawing.Point(925, 487);
            this.uxSubmitButton.Name = "uxSubmitButton";
            this.uxSubmitButton.Size = new System.Drawing.Size(537, 104);
            this.uxSubmitButton.TabIndex = 5;
            this.uxSubmitButton.Text = "Submit";
            this.uxSubmitButton.UseVisualStyleBackColor = true;
            // 
            // uxTeamComboBox
            // 
            this.uxTeamComboBox.FormattingEnabled = true;
            this.uxTeamComboBox.Items.AddRange(new object[] {
            "ARI",
            "ATL",
            "BAL",
            "BUF",
            "CAR",
            "CHI",
            "CIN",
            "CLE",
            "DAL",
            "DEN",
            "DET",
            "GNB",
            "HOU",
            "IND",
            "JAX",
            "KAN",
            "LAC",
            "LAR",
            "LVR",
            "MIA",
            "MIN",
            "NOR",
            "NWE",
            "NYG",
            "NYJ",
            "PHI",
            "PIT",
            "SEA",
            "SFO",
            "TAM",
            "TEN",
            "WAS"});
            this.uxTeamComboBox.Location = new System.Drawing.Point(1158, 25);
            this.uxTeamComboBox.Name = "uxTeamComboBox";
            this.uxTeamComboBox.Size = new System.Drawing.Size(121, 23);
            this.uxTeamComboBox.TabIndex = 6;
            this.uxTeamComboBox.Text = "Select Team";
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 603);
            this.Controls.Add(this.uxTeamComboBox);
            this.Controls.Add(this.uxSubmitButton);
            this.Controls.Add(this.uxDefensiveButton);
            this.Controls.Add(this.uxEspnButton);
            this.Controls.Add(this.uxOffensiveButton);
            this.Controls.Add(this.uxPlayerButton);
            this.Controls.Add(this.uxPlayerList);
            this.Name = "Search";
            this.Text = "Search";
            this.ResumeLayout(false);

        }

        #endregion

        private ListView uxPlayerList;
        private Button uxPlayerButton;
        private Button uxOffensiveButton;
        private Button uxEspnButton;
        private Button uxDefensiveButton;
        private ColumnHeader uxPlayerIdColumn;
        private ColumnHeader uxPlayerNameColumn;
        private ColumnHeader uxTeamColumn;
        private ColumnHeader uxPositionColumn;
        private Button uxSubmitButton;
        private ComboBox uxTeamComboBox;
    }
}